using AutoMapper;
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
        private readonly IMapper _mapper;


        public OptionController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, OptionPutDto optionPutDto)
        {
            var optionToUpdate = _context.Options.FirstOrDefault(x => x.Id == id);

            if (optionToUpdate == null) return NotFound();

            _mapper.Map(optionPutDto, optionToUpdate);

            _context.Update(optionToUpdate);
            _context.SaveChanges();

            return Ok();
        }

    }
}
