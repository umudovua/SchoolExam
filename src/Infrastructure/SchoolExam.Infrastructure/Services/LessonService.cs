using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolExam.Application.DTOs.Lesson;
using SchoolExam.Application.Exeptions;
using SchoolExam.Application.Interfaces.Repositories.Base;
using SchoolExam.Application.Interfaces.Services;
using SchoolExam.Domain.Entities;

namespace SchoolExam.Infrastructure.Services
{
	public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lesson;
        private readonly IClassRoomService _classRoomService;
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        public LessonService(ILessonRepository lesson, IMapper mapper, IClassRoomService classRoom, ITeacherService teacher)
        {
            _lesson = lesson;
            _mapper = mapper;
            _classRoomService = classRoom;
            _teacherService = teacher;
        }

        public async Task<bool> Add(LessonCreateDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<Lesson>(addDTO);
                await _lesson.AddAsync(entity);
				return await _lesson.SaveAsync();

			}
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _lesson.RemoveAsync(id);
                return await _lesson.SaveAsync();
            }
            catch (Exception ex)
            {

                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public ICollection<LessonResponseDTO> GetAll()
        {
            try
            {
                var listIndexDto = _lesson.GetAll().Include(s=>s.Teacher)
                                          .Include(s=>s.ClassRoom)
                                          .Select(s => new LessonResponseDTO 
                                          { Id=s.Id,Code = s.Code, 
                                              Name = s.Name,
                                              TeacherFullName = s.Teacher.FirstName,ClassRoom=s.ClassRoom.Number 
                                          });

                return listIndexDto.ToList();
            }
            catch (Exception ex)
            {

                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public async Task<LessonCreateDTO> GetById(int id)
        {
            try
            {
                var data =await _lesson.GetByIdAsync(id);

				var dto = _mapper.Map<LessonCreateDTO>(data);
                return dto;
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public LessonCreateDTO Initialize(LessonCreateDTO model)
        {
            model.ClassRooms = _classRoomService.GetAll();
            model.Teachers = _teacherService.GetAll();
           return model;
        }

        public Task<bool> Update(LessonCreateDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<Lesson>(addDTO);
                var result = _lesson.Update(entity);

                return _lesson.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }
    }
}
