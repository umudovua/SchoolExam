using SchoolExam.Application.Interfaces.Repositories;
using SchoolExam.Domain.Entities;
using SchoolExam.Persistence.Context;

namespace SchoolExam.Infrastructure.Repositories
{
	public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(AppDbContext examDBContext) : base(examDBContext)
        {
        }
    }
}
