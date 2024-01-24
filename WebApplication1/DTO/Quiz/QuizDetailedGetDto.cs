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
}
