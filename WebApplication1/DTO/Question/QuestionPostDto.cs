using FluentValidation;
using WebApplication1.DTO.Option;

namespace WebApplication1.DTO.Question
{
    public class QuestionPostDto
    {
        public string Name { get; set; }
        public decimal Points { get; set; }
        public List<OptionPostDto> OptionPostDtos { get; set; }
    }

    public class QuestionPostDtoValidator : AbstractValidator<QuestionPostDto>
    {
        public QuestionPostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Points).GreaterThanOrEqualTo(0).WithMessage("Points must be greater than or equal to 0");
            RuleFor(x => x.OptionPostDtos).NotEmpty().WithMessage("Options are required");
            RuleForEach(x => x.OptionPostDtos).SetValidator(new OptionPostDtoValidator());
        }
    }
}
