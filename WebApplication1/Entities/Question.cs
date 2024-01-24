﻿namespace WebApplication1.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Points { get; set; }
        public List<Option>? Options { get; set; }
        public int QuizId { get; set; }
        public Quiz? Quiz { get; set; }
    }
}
