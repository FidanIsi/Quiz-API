using FluentValidation;
using WebApplication1.DTO.Question;

namespace WebApplication1.DTO.Quiz
{
    public class QuizPostDto
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<QuestionPostDto> QuestionPostDtos { get; set; }

    }

    public class QuizPostDtoValidator : AbstractValidator<QuizPostDto>
    {
        public QuizPostDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.CreationDate).NotEmpty().WithMessage("CreationDate is required");
            RuleFor(x => x.QuestionPostDtos).NotEmpty().WithMessage("Questions are required");
            RuleForEach(x => x.QuestionPostDtos).SetValidator(new QuestionPostDtoValidator());
        }
    }
}
