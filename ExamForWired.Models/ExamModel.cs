using System;
using System.Collections.Generic;

namespace ExamForWired.Models
{
    public class ExamModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PubDate { get; set; }
        public List<QuestionModel> Questions { get; set; }
    }
}
