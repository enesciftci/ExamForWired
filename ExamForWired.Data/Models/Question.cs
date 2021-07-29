using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamForWired.Data.Models
{
    public class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ExamId { get; set; }
        public string Content { get; set; }
        [InverseProperty("Question")]
        public ICollection<Answer> Answers { get; set; }
        [ForeignKey("ExamId")]
        [InverseProperty("Questions")]
        public virtual Exam Exam{ get; set; }
    }
}
