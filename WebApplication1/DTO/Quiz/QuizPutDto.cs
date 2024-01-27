using FluentValidation;

namespace WebApplication1.DTO.Quiz
{
    public class QuizPutDto
    {
        public string Name { get; set; }
    }

    public class QuizPutDtoValidator : AbstractValidator<QuizPutDto>
    {
        public QuizPutDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
