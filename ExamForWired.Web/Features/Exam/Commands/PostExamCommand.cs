using ExamForWired.Models;
using MediatR;

namespace ExamForWired.Web.Features.Exam.Commands
{
    public class PostExamCommand : IRequest
    {
        public ExamModel ExamModel { get; set; }
        public PostExamCommand(ExamModel examModel)
        {
            ExamModel = examModel;
        }
    }
}
