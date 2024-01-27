using FluentValidation;
using WebApplication1.DTO.Question;
using WebApplication1.Entities;

namespace WebApplication1.DTO.Quiz
{
    public class QuizDetailedGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<QuestionGetDto>? QuestionGetDtos { get; set; }
    }

    public class QuizDetailedGetDtoValidator : AbstractValidator<QuizDetailedGetDto>
    {
        public QuizDetailedGetDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.CreationDate).NotEmpty().WithMessage("CreationDate is required");
            RuleForEach(x => x.QuestionGetDtos).SetValidator(new QuestionGetDtoValidator());
        }
    }
}
