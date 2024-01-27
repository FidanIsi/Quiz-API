using FluentValidation;

namespace WebApplication1.DTO.Option
{
    public class OptionPostDto
    {
        public string Name { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class OptionPostDtoValidator : AbstractValidator<OptionPostDto>
    {
        public OptionPostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.IsCorrect).NotNull().WithMessage("IsCorrect must not be null");
        }
    }
}
