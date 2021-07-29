using AutoMapper;
using ExamForWired.Business.Service;
using ExamForWired.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace ExamForWired.Web.Features.Exam.Commands
{
    public class PostExamCommandHandler : AsyncRequestHandler<PostExamCommand>
    {
        private readonly Lazy<IExamService> _examService;
        private readonly IMapper _mapper;
        public PostExamCommandHandler(
            Lazy<IExamService> examService,
            IMapper mapper)
        {
            _examService = examService;
            _mapper = mapper;
        }
        protected override async Task Handle(PostExamCommand request, CancellationToken cancellationToken)
        {
            var exam = _mapper.Map<ExamModel,Data.Models.Exam>(request.ExamModel);
            await _examService.Value.Create(exam);
        }
    }
}
