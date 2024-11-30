using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolExam.Application.DTOs.Exam;
using SchoolExam.Application.Exeptions;
using SchoolExam.Application.Interfaces.Repositories;
using SchoolExam.Application.Interfaces.Services;
using SchoolExam.Domain.Entities;

namespace SchoolExam.Infrastructure.Services
{
	public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IStudentService _studentService;
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;
        public ExamService(IExamRepository examRepository, IMapper mapper, 
            IStudentService studentService, ILessonService lessonService)
        {
            _examRepository = examRepository;
            _mapper = mapper;
            _studentService = studentService;
            _lessonService = lessonService;
        }
        public  bool Add(ExamCreateDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<Exam>(addDTO);
                _examRepository.Add(entity);
                return  _examRepository.Save();
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }

        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _examRepository.RemoveAsync(id);
                return await _examRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public ICollection<ExamResponseDTO> GetAll()
        {
            try
            {
                var exams = _examRepository.GetAll().Include(s=>s.Lesson)
                    .Include(s=>s.Student).Select(s => new ExamResponseDTO
                                {
                                    Id= s.Id,
                                    ResultGrade = s.ResultGrade,
                                    ExamDate = s.ExamDate,
                                    LessonName = s.Lesson.Name,
                                    StudentFullName = $"{s.Student.FirstName} {s.Student.LastName}",
                                });
                return exams.ToList();

            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public  ExamResponseDTO GetById(int id)
        {
            try
            {
                var entity =  _examRepository.GetWhere(x=>x.Id==id)
                    .Include(s=>s.Student).Select(s => new ExamResponseDTO
				                {
					                Id = s.Id,
					                ResultGrade = s.ResultGrade,
					                ExamDate = s.ExamDate,
					                LessonName = s.Lesson.Name,
					                StudentFullName = $"{s.Student.FirstName} {s.Student.LastName}",
				                }).FirstOrDefault();
                
                return entity;
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }


        public async Task<bool> Update(ExamUpdateDTO update)
        {
            try
            {
                var exam = await _examRepository.GetByIdAsync(update.Id);
                if (exam is not null)
                {
                    exam.ExamDate = update.ExamDate;
                    exam.ResultGrade = update.ResultGrade;
                    exam.LessonId = update.LessonId;
                    exam.StudentId = update.StudentId;
                }
                _examRepository.Update(exam);
                return await _examRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }
    }
}
