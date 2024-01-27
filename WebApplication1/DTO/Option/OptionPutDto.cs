using FluentValidation;

namespace WebApplication1.DTO.Option
{
    public class OptionPutDto
    {
        public string Name { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class OptionPutDtoValidator : AbstractValidator<OptionPutDto>
    {
        public OptionPutDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.IsCorrect).NotNull().WithMessage("IsCorrect must not be null");
        }
    }
}
