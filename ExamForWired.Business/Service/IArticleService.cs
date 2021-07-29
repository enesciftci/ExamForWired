using ExamForWired.Models;
using System.Collections.Generic;

namespace ExamForWired.Business.Service
{
    public interface IArticleService
    {
        List<ArticleModel> GetArticleListFromWired();
    }
}
