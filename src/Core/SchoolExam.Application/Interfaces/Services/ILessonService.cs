
using SchoolExam.Application.DTOs.Lesson;

namespace SchoolExam.Application.Interfaces.Services
{
    public interface ILessonService
    {
        public ICollection<LessonResponseDTO> GetAll();
        public Task<LessonCreateDTO> GetById(int id);
        public bool Add(LessonCreateDTO addDTO);
        public Task<bool> Update(LessonUpdateDTO update);
        public Task<bool> Delete(int id);
    }
}
