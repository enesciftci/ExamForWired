using ExamForWired.Data.Models;
using ExamForWired.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamForWired.Business.Service
{
    public interface IExamService
    {
        Task<List<Exam>> GetList();
        Task Delete(Exam exam);
        Task<Exam> GetById(long id);
        Task Create(Exam exam);
        Task<List<AnswerModel>> GetAnswerListForFinishExam(List<AnswerModel> answerModels);
    }
}
