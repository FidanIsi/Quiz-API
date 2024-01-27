using AutoMapper;
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
        private readonly IMapper _mapper;


        public QuestionController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, QuestionPutDto dto)
        {
            var questionToUpdate = _context.Questions.FirstOrDefault(x => x.Id == id);

            if (questionToUpdate == null) return NotFound();

            _mapper.Map(dto, questionToUpdate);

            _context.Update(questionToUpdate);
            _context.SaveChanges();

            return Ok();
        }

    }
}
