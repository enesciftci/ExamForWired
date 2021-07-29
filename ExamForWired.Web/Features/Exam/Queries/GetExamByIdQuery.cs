using ExamForWired.Models;
using MediatR;

namespace ExamForWired.Web.Features.Exam.Queries
{
    public class GetExamByIdQuery:IRequest<ExamModel>
    {
        public long Id { get; set; }
        public GetExamByIdQuery(long id)
        {
            Id = id;
        }
    }
}
