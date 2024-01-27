using WebApplication1.DTO.Account;

namespace WebApplication1.Services
{
    public interface IAuthService
    {
        Task<(int, string)> SignUp(SignUpDto dto, string role);
        Task<(int, string)> SignIn(SignInDto dto);
    }
}
