
using SchoolExam.Application.DTOs.Lesson;

namespace SchoolExam.Application.Interfaces.Services
{
    public interface ILessonService
    {
        public ICollection<LessonResponseDTO> GetAll();
        public Task<LessonCreateDTO> GetById(int id);
        public Task<bool> Add(LessonCreateDTO addDTO);
        public Task<bool> Update(LessonCreateDTO addDTO);
        public Task<bool> Delete(int id);
        public LessonCreateDTO Initialize(LessonCreateDTO model);
    }
}
