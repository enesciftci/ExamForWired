using ExamForWired.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamForWired.Web.Features.Exam.Commands
{
    public class PostFinishExamCommand:IRequest<List<AnswerModel>>
    {
        public List<AnswerModel> AnswerModels;
        public PostFinishExamCommand(List<AnswerModel> answerModels)
        {
            AnswerModels = answerModels;
        }
    }
}
