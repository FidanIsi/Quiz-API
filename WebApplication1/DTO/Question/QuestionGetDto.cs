using FluentValidation;
using WebApplication1.DTO.Option;
using WebApplication1.Entities;

namespace WebApplication1.DTO.Question
{
    public class QuestionGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Points { get; set; }
        public List<OptionGetDto>? OptionGetDtos { get; set; }
    }

    public class QuestionGetDtoValidator : AbstractValidator<QuestionGetDto>
    {
        public QuestionGetDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Points).GreaterThanOrEqualTo(0).WithMessage("Points must be greater than or equal to 0");
            RuleForEach(x => x.OptionGetDtos).SetValidator(new OptionGetDtoValidator());
        }
    }
}
