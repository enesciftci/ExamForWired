using AutoMapper;
using ExamForWired.Business.Service;
using ExamForWired.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExamForWired.Web.Features.Exam.Queries
{
    public class GetExamByIdQueryHandler : IRequestHandler<GetExamByIdQuery, ExamModel>
    {
        private readonly Lazy<IExamService> _examService;
        private readonly IMapper _mapper;
        public GetExamByIdQueryHandler(
            Lazy<IExamService> examService,
            IMapper mapper)
        {
            _examService = examService;
            _mapper = mapper;
        }
        public async Task<ExamModel> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            var exam = await _examService.Value.GetById(request.Id);
            return _mapper.Map<ExamModel>(exam);
        }
    }
}
