
using SchoolExam.Application.DTOs.Exam;

namespace SchoolExam.Application.Interfaces.Services
{
    public interface IExamService
    {
        public ICollection<ExamResponseDTO> GetAll();
        public ExamResponseDTO GetById(int id);
        public bool Add(ExamCreateDTO addDTO);
        public Task<bool> Update(ExamUpdateDTO update);
        public Task<bool> Delete(int id);
    }
}
