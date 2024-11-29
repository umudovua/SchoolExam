using SchoolExam.Application.Interfaces.Repositories;
using SchoolExam.Domain.Entities;
using SchoolExam.Persistence.Context;

namespace SchoolExam.Infrastructure.Repositories
{
	public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AppDbContext examDBContext) : base(examDBContext)
        {
        }
    }
}
