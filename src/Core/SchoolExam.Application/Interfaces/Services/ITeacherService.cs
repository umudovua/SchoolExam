

using SchoolExam.Application.DTOs.Teacher;

namespace SchoolExam.Application.Interfaces.Services
{
    public interface ITeacherService
    {
        public ICollection<TeacherResponseDTO> GetAll();
        public Task<TeacherCreateDTO> GetById(int id);
        public Task<bool> Add(TeacherCreateDTO addDTO);
        public Task<bool> Update(TeacherCreateDTO addDTO);
        public Task<bool> Delete(int id);
    }
}
