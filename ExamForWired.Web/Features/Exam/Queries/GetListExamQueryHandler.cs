using AutoMapper;
using ExamForWired.Business.Service;
using ExamForWired.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExamForWired.Web.Features.Exam.Queries
{
    public class GetListExamQueryHandler : IRequestHandler<GetListExamQuery, List<ExamModel>>
    {
        private readonly Lazy<IExamService> _examService;
        private readonly IMapper _mapper;
        public GetListExamQueryHandler(
            Lazy<IExamService> examService,
            IMapper mapper)
        {
            _examService = examService;
            _mapper = mapper;
        }
        public async Task<List<ExamModel>> Handle(GetListExamQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<ExamModel>>(await _examService.Value.GetList());
        }
    }
}
