using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.DTO.Option;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OptionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPut]
        public IActionResult Update (int id, OptionPutDto optionPutDto)
        {
            var options = _context.Options.FirstOrDefault(x => x.Id == id);

                if (options == null) return NotFound();

            options.Name = optionPutDto.Name;
            options.IsCorrect = optionPutDto.IsCorrect;

            _context.Update(options);
            _context.SaveChanges();

            return Ok();
        }
    }
}
