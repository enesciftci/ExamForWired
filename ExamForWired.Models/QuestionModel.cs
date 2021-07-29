using System.Collections.Generic;

namespace ExamForWired.Models
{
    public  class QuestionModel
    {
        public long Id { get; set; }
        public long ExamId { get; set; }
        public string Content { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}
