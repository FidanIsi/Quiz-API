using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplication1.Data;
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

            return Ok();
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
    }
}
