using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Account;
using WebApplication1.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using WebApplication1.Services;
using Microsoft.Win32;
using WebApplication1.DTO.User;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn(SignInDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var (status, message) = await _authService.SignIn(dto);
            if (status == 0)
                return BadRequest(message);
            return Ok(message);
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var (status, message) = await _authService.SignUp(dto, UserRoles.User);
            //var (status, message) = await _authService.SignUp(dto, UserRoles.Admin);
            if (status == 0)
            {
                return BadRequest(message);
            }
            return CreatedAtAction(nameof(SignUp), new { UserName = dto.UserName });
        }
    }
}
