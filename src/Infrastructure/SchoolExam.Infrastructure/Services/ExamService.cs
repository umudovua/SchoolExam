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
        public ExamService(IExamRepository examRepository, IMapper mapper, IStudentService studentService, ILessonService lessonService)
        {
            _examRepository = examRepository;
            _mapper = mapper;
            _studentService = studentService;
            _lessonService = lessonService;
        }
        public async Task<bool> Add(ExamCreateDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<Exam>(addDTO);
                await _examRepository.AddAsync(entity);
                return await _examRepository.SaveAsync();
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
                var value = _examRepository.GetAll().Include(s=>s.Lesson).Include(s=>s.Student).Select(s => new ExamResponseDTO
                {
                    Id= s.Id,
                    ResultGrade = s.ResultGrade,
                    ExamDate = s.ExamDate,
                    LessonName = s.Lesson.Name,
                    StudentFullName = s.Student.LastName
                });
                return value.ToList();

            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public ExamCreateDTO GetById(int id)
        {
            try
            {
                var entity = _examRepository.GetByIdAsync(id);
                return _mapper.Map<ExamCreateDTO>(entity);
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public ExamCreateDTO Initialize(ExamCreateDTO model)
        {
            model.Lessons = _lessonService.GetAll();
            model.Students = _studentService.GetAll();

           return model;
        }

        public async Task<bool> Update(ExamCreateDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<Exam>(addDTO);
                _examRepository.Update(entity);
                return await _examRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }
    }
}
