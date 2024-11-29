using SchoolExam.Application.Interfaces.Repositories;
using SchoolExam.Domain.Entities;
using SchoolExam.Persistence.Context;

namespace SchoolExam.Infrastructure.Repositories
{
	public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext examDBContext) : base(examDBContext)
        {
        }
    }
}
