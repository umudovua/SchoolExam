
using SchoolExam.Application.DTOs.Student;

namespace SchoolExam.Application.Interfaces.Services
{
    public interface IStudentService
    {
        public ICollection<StudentResponseDTO> GetAll();
        public Task<StudentCreateDTO> GetById(int id);
        public Task<bool> Add(StudentCreateDTO addDTO);
        public Task<bool> Update(StudentCreateDTO addDTO);
        public Task<bool> Delete(int id);
        public StudentCreateDTO Initialize(StudentCreateDTO model);
    }
}
