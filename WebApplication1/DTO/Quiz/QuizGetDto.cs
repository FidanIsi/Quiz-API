using FluentValidation;

namespace WebApplication1.DTO.Quiz
{
    public class QuizGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
    }

    public class QuizGetDtoValidator : AbstractValidator<QuizGetDto>
    {
        public QuizGetDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.CreationTime).NotEmpty().WithMessage("CreationTime is required");
        }
    }
}
