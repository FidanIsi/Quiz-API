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
}
