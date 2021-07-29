using AutoMapper;
using ExamForWired.Business.Service;
using ExamForWired.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExamForWired.Web.Features.Article.Queries
{
    public class GetArticleListQueryHandler : IRequestHandler<GetArticleListQuery, List<ArticleModel>>
    {
        private readonly Lazy<IArticleService> _articleService;
        private readonly IMapper _mapper;
        public GetArticleListQueryHandler(
            Lazy<IArticleService> articleService,
            IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }
        public Task<List<ArticleModel>> Handle(GetArticleListQuery request, CancellationToken cancellationToken)
        {
            var articleList = _articleService.Value.GetArticleListFromWired();
            return Task.FromResult(_mapper.Map<List<ArticleModel>>(articleList));
        }
    }
}
