using FluentValidation;

namespace WebApplication1.DTO.Account
{
    public class SignUpDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SignUpDtoValidator : AbstractValidator<SignUpDto>
    {
        public SignUpDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Invalid email address");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
