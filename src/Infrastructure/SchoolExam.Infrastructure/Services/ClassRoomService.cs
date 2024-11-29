using AutoMapper;
using SchoolExam.Application.DTOs.ClassRoom;
using SchoolExam.Application.Exeptions;
using SchoolExam.Application.Interfaces.Repositories;
using SchoolExam.Application.Interfaces.Services;
using SchoolExam.Domain.Entities;

namespace SchoolExam.Infrastructure.Services
{
	public class ClassRoomService : IClassRoomService
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IMapper _mapper;
        public ClassRoomService(IClassRoomRepository classRoomRepository, IMapper mapper)
        {
            _classRoomRepository = classRoomRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(ClassRoomCreateDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<ClassRoom>(addDTO);
                await _classRoomRepository.AddAsync(entity);
				return await _classRoomRepository.SaveAsync();
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
                var model = await _classRoomRepository.GetByIdAsync(id);
				_classRoomRepository.Remove(model);
				return await _classRoomRepository.SaveAsync();
			}
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public ICollection<ClassRoomResponseDTO> GetAll()
        {
            try
            {
                var listDto = _classRoomRepository.GetAll().Select(s=> new ClassRoomResponseDTO { Id=s.Id,Name =s.Name,Number=s.Number});
                return listDto.ToList();
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public async Task<ClassRoomCreateDTO> GetById(int id)
        {
            try
            {
                var entity =await _classRoomRepository.GetByIdAsync(id);
                return _mapper.Map<ClassRoomCreateDTO>(entity);
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }

        public async Task<bool> Update(ClassRoomCreateDTO addDTO)
        {
            try
            {
                var entity = _mapper.Map<ClassRoom>(addDTO);
                _classRoomRepository.Update(entity);

				return await _classRoomRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new CustomApplicationExeption(ex.Message); ;
            }
        }
    }
}
