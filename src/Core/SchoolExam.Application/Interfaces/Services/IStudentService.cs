
using SchoolExam.Application.DTOs.ClassRoom;
using SchoolExam.Application.DTOs.Student;

namespace SchoolExam.Application.Interfaces.Services
{
    public interface IStudentService
    {
        public ICollection<StudentResponseDTO> GetAll();
        public Task<StudentCreateDTO> GetById(int id);
        public bool Add(StudentCreateDTO addDTO);
        public Task<bool> Update(StudentUpdateDTO update);
        public Task<bool> Delete(int id);
    }
}
