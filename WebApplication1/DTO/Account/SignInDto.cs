using FluentValidation;

namespace WebApplication1.DTO.Account
{
    public class SignInDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class SignInDtoValidator : AbstractValidator<SignInDto>
    {
        public SignInDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("User name is required!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required!")
                .MinimumLength(3)
                .WithMessage("Should contain at least 3 characters!");
        }
    }
}
