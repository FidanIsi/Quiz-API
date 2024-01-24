namespace WebApplication1.Entities
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
        public List<Option>? Options { get; set; }
    }
}
