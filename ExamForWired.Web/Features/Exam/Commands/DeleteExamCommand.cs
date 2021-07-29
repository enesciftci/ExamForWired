using MediatR;

namespace ExamForWired.Web.Features.Exam.Commands
{
    public class DeleteExamCommand : IRequest
    {
        public long Id { get; set; }
        public DeleteExamCommand(long id)
        {
            Id = id;
        }
    }
}
