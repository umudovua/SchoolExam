using SchoolExam.Application.Interfaces.Repositories;
using SchoolExam.Domain.Entities;
using SchoolExam.Persistence.Context;

namespace SchoolExam.Infrastructure.Repositories
{
	public class ClassRoomRepository : Repository<ClassRoom>, IClassRoomRepository
    {
        public ClassRoomRepository(AppDbContext examDBContext) : base(examDBContext)
        {
        }
    }
}
