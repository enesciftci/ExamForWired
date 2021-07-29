using System;

namespace ExamForWired.Models
{
    public  class ArticleModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PubDate{ get; set; }
        public string URL { get; set; }
    }
}
