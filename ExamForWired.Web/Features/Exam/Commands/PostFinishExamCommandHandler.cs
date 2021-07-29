using ExamForWired.Business.Service;
using ExamForWired.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExamForWired.Web.Features.Exam.Commands
{
    public class PostFinishExamCommandHandler : IRequestHandler<PostFinishExamCommand, List<AnswerModel>>
    {
        private readonly Lazy<IExamService> _examService;
        public PostFinishExamCommandHandler(Lazy<IExamService> examService)
        {
            _examService = examService;
        }

        public async Task<List<AnswerModel>> Handle(PostFinishExamCommand request, CancellationToken cancellationToken)
        {
            return await _examService.Value.GetAnswerListForFinishExam(request.AnswerModels);
        }
    }
}
