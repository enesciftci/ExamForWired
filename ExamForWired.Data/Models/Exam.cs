using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamForWired.Data.Models
{
    public class Exam
    {
        public Exam()
        {
            Questions= new List<Question>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PubDate { get; set; }
        [InverseProperty("Exam")]
        public List<Question> Questions { get; set; }
    }
}
