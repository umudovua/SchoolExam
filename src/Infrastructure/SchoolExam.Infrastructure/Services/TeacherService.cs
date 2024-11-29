using AutoMapper;
using SchoolExam.Application.DTOs.Teacher;
using SchoolExam.Application.Exeptions;
using SchoolExam.Application.Interfaces.Repositories;
using SchoolExam.Application.Interfaces.Services;
using SchoolExam.Domain.Entities;


namespace SchoolExam.Infrastructure.Services
{
	public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(TeacherCreateDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<Teacher>(addDTO);
                await _teacherRepository.AddAsync(entity);
                return await _teacherRepository.SaveAsync();
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
                await _teacherRepository.RemoveAsync(id);
                return await _teacherRepository.SaveAsync();

			}
            catch (Exception ex)
            {

                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public ICollection<TeacherResponseDTO> GetAll()
        {
            try
            {
                var listIndexDto = _teacherRepository.GetAll().Select(s => new TeacherResponseDTO { Id=s.Id,FirstName = s.FirstName, LastName = s.LastName });
                return listIndexDto.ToList();
            }
            catch (Exception ex)
            {

                throw new CustomApplicationExeption(ex.Message); ;
            }

        }

        public async Task<TeacherCreateDTO> GetById(int id)
        {
            try
            {
                var data = await _teacherRepository.GetByIdAsync(id);

				var dto = _mapper.Map<TeacherCreateDTO>(data);
                return dto;
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public async Task<bool> Update(TeacherCreateDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<Teacher>(addDTO);
                var result = _teacherRepository.Update(entity);
                return await _teacherRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }
    }
}
