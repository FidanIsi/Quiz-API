using WebApplication1.DTO.Question;

namespace WebApplication1.DTO.Quiz
{
    public class QuizPostDto
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<QuestionPostDto> QuestionPostDtos { get; set; }

    }
}
