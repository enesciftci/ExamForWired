using ExamForWired.Data.Models;
using System;

namespace ExamForWired.Business.Service
{
    public abstract class BaseService
    {
        public ExamForWiredDbContext ExamForWiredDbContext { get { return _examForWiredDbContext; } }


        private readonly ExamForWiredDbContext _examForWiredDbContext;
        public BaseService(ExamForWiredDbContext examForWiredDbContext)
        {
            _examForWiredDbContext = examForWiredDbContext;
        }
    }
}
