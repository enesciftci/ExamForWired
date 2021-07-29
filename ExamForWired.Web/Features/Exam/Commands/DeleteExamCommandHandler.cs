using ExamForWired.Business.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExamForWired.Web.Features.Exam.Commands
{
    public class DeleteExamCommandHandler : AsyncRequestHandler<DeleteExamCommand>
    {
        private readonly Lazy<IExamService> _examService;
        public DeleteExamCommandHandler(Lazy<IExamService> examService)
        {
            _examService = examService;
        }

        protected override async Task Handle(DeleteExamCommand request, CancellationToken cancellationToken)
        {
            var exam = await _examService.Value.GetById(request.Id);
            await _examService.Value.Delete(exam);
        }
    }
}
