using ExamForWired.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamForWired.Web.Features.Article.Queries
{
    public class GetArticleListQuery:IRequest<List<ArticleModel>>
    {
    }
}
