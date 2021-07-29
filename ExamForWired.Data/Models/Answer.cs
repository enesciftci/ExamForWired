using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamForWired.Data.Models
{
    public class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long QuestionId { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public string Content { get; set; }
        [InverseProperty("Answers")]
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}
