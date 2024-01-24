using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.DTO.Question;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuestionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPut]
        public IActionResult Update(int id, QuestionPutDto dto)
        {
            var options = _context.Questions.FirstOrDefault(x => x.Id == id);

            if (options == null) return NotFound();

            options.Name = dto.Name;
            options.Points = dto.Points;

            _context.Update(options);
            _context.SaveChanges();

            return Ok();
        }
    }
}
