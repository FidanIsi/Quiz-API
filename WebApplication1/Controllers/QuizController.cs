using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Data;
using WebApplication1.DTO.Option;
using WebApplication1.DTO.Question;
using WebApplication1.DTO.Quiz;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuizController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var quizzes = _context.Quizzes
                .Select(q => new QuizGetDto
                {
                    Id = q.Id,
                    Name = q.Name,
                    CreationTime = q.CreationTime
                }).ToList();


            return Ok(quizzes);
        }

        [HttpGet("GetById/{quizId}")]
        public IActionResult GetById(int quizId)
        {
            var quiz = _context.Quizzes.Include(q=>q.Questions).ThenInclude(q=> q.Options).SingleOrDefault(x=>x.Id == quizId);

            if(quiz == null) return NotFound();

            var quizDetailedDto = new QuizDetailedGetDto
            {
                Id = quiz.Id,
                Name = quiz.Name,
                CreationDate = quiz.CreationTime,
                QuestionGetDtos = quiz.Questions.Select(q => new QuestionGetDto
                {
                    Id = q.Id,
                    Name = q.Name,
                    Points = q.Points,
                    OptionGetDtos = q.Options.Select(q => new OptionGetDto
                    {
                        Id = q.Id,
                        Name = q.Name,
                    }).ToList(),
                }).ToList()
            };

            return Ok(quizDetailedDto);
        }

        [HttpPut("Update /{quizId}")]
        public IActionResult Update(int quizId, QuizPutDto quizPutDto)
        {
            var existingQuiz = _context.Quizzes.Find(quizId);

            if (existingQuiz == null) return NotFound();

            existingQuiz.Name = quizPutDto.Name;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("Delete/{quizId}")]
        public IActionResult Delete(int quizId)
        {
            var quizToDelete = _context.Quizzes.Include(q => q.Questions).ThenInclude(q => q.Options).SingleOrDefault(q => q.Id == quizId);

            if (quizToDelete == null) return NotFound();

            _context.Quizzes.Remove(quizToDelete);

            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("Create")]
        public IActionResult Create(QuizPostDto quizPostDto)
        {
            var newQuiz = new Quiz
            {
                Name = quizPostDto.Name,
                CreationTime = quizPostDto.CreationDate,
                Questions = quizPostDto.QuestionPostDtos.Select(q => new Question
                {
                    Name = q.Name,
                    Points = q.Points,
                    Options = q.OptionPostDtos.Select(x => new Option
                    {
                        Name = x.Name,
                        IsCorrect = x.IsCorrect,
                    }).ToList(),
                }).ToList()
            };

            _context.Quizzes.Add(newQuiz);
            _context.SaveChanges();

            return Ok("Quiz created successfully");
        }

    }
}
