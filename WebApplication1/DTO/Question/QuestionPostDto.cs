using WebApplication1.DTO.Option;

namespace WebApplication1.DTO.Question
{
    public class QuestionPostDto
    {
        public string Name { get; set; }
        public decimal Points { get; set; }
        public List<OptionPostDto> OptionPostDtos { get; set; }
    }
}
