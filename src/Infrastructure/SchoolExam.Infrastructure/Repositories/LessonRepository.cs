using SchoolExam.Application.Interfaces.Repositories.Base;
using SchoolExam.Domain.Entities;
using SchoolExam.Persistence.Context;

namespace SchoolExam.Infrastructure.Repositories
{
	public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(AppDbContext examDBContext) : base(examDBContext)
        {
        }
    }
}
