using FluentValidation;

namespace WebApplication1.DTO.Option
{
    public class OptionGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OptionGetDtoValidator : AbstractValidator<OptionGetDto>
    {
        public OptionGetDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
