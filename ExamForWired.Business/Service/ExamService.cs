using AutoMapper;
using AutoMapper.QueryableExtensions;
using ExamForWired.Data.Models;
using ExamForWired.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamForWired.Business.Service
{
    public class ExamService : BaseService, IExamService
    {
        private readonly IMapper _mapper;
        public ExamService(ExamForWiredDbContext examForWiredDbContext, IMapper mapper) : base(examForWiredDbContext)
        {
            _mapper = mapper;
        }
        public async Task<List<Exam>> GetList()
        {
            var examList = await ExamForWiredDbContext.Exams.ToListAsync();
            return examList;
        }

        public async Task Delete(Exam exam)
        {
            ExamForWiredDbContext.Exams.Remove(exam);
            await ExamForWiredDbContext.SaveChangesAsync();
        }

        public async Task<Exam> GetById(long id)
        {
            return await ExamForWiredDbContext.Exams
                            .AsNoTracking()
                            .Include(p => p.Questions)
                            .ThenInclude(p => p.Answers)
                            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Create(Exam exam)
        {
            using (await ExamForWiredDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await ExamForWiredDbContext.Exams.AddAsync(exam);
                    await ExamForWiredDbContext.SaveChangesAsync();
                    ExamForWiredDbContext.Database.CommitTransaction();
                }
                catch (Exception)
                {
                    ExamForWiredDbContext.Database.RollbackTransaction();
                    throw;
                }
            }
        }

        public async Task<List<AnswerModel>> GetAnswerListForFinishExam(List<AnswerModel> answerModels)
        {
            var answers = await ExamForWiredDbContext.Answers
                            .AsNoTracking()
                            .Where(p => answerModels.Select(x => x.Id).Contains(p.Id) && answerModels.Select(x => x.QuestionId).Contains(p.QuestionId))
                            .ToListAsync();
            
            return _mapper.Map<List<AnswerModel>>(answers);
        }
    }
}
