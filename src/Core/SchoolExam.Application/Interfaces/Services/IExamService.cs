
using SchoolExam.Application.DTOs.Exam;

namespace SchoolExam.Application.Interfaces.Services
{
    public interface IExamService
    {
        public ICollection<ExamResponseDTO> GetAll();
        public ExamCreateDTO GetById(int id);
        public Task<bool> Add(ExamCreateDTO addDTO);
        public Task<bool> Update(ExamCreateDTO addDTO);
        public Task<bool> Delete(int id);
        public ExamCreateDTO Initialize(ExamCreateDTO model);
    }
}
