namespace ExamForWired.Models
{
    public class AnswerModel
    {
        public long Id { get; set; }
        public long QuestionId { get; set; }
        public string Content { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}
