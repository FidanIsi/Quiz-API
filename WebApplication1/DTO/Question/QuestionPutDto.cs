using FluentValidation;

namespace WebApplication1.DTO.Question
{
    public class QuestionPutDto
    {
        public string Name { get; set; }
        public decimal Points { get; set; }
    }

    public class QuestionPutDtoValidator : AbstractValidator<QuestionPutDto>
    {
        public QuestionPutDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Points).GreaterThanOrEqualTo(0).WithMessage("Points must be greater than or equal to 0");
        }
    }
}
