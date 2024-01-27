using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata.Ecma335;
using WebApplication1.Data;
using WebApplication1.DTO.Account;
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
        private readonly IMapper _mapper;

        public QuizController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var quizzes = _context.Quizzes
            .Select(q => _mapper.Map<QuizGetDto>(q))
            .ToList();

            return Ok(quizzes);
        }

        [HttpGet("GetById/{quizId}")]
        public IActionResult GetById(int quizId)
        {
            var quiz = _context.Quizzes.Include(q => q.Questions).ThenInclude(q => q.Options).SingleOrDefault(x => x.Id == quizId);

            if (quiz == null) return NotFound();

            var quizDetailedDto = _mapper.Map<QuizDetailedGetDto>(quiz);

            return Ok(quizDetailedDto);
        }


        [HttpPost("Create")]
        public IActionResult Create(QuizPostDto quizPostDto)
        {
            var newQuiz = _mapper.Map<Quiz>(quizPostDto);

            _context.Quizzes.Add(newQuiz);
            _context.SaveChanges();

            return Ok("Quiz created successfully");
        }


        [HttpPut("Update/{quizId}")]
        public IActionResult Update(int quizId, QuizPutDto quizPutDto)
        {
            var existingQuiz = _context.Quizzes.Find(quizId);

            if (existingQuiz == null) return NotFound();

            _mapper.Map(quizPutDto, existingQuiz);

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

    }
}
