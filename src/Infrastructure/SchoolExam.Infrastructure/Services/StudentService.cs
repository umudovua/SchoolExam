using AutoMapper;
using SchoolExam.Application.DTOs.ClassRoom;
using SchoolExam.Application.DTOs.Student;
using SchoolExam.Application.Exeptions;
using SchoolExam.Application.Interfaces.Repositories;
using SchoolExam.Application.Interfaces.Services;
using SchoolExam.Domain.Entities;

namespace SchoolExam.Infrastructure.Services
{
	public class StudentService : IStudentService
	{
		private readonly IStudentRepository _studentRepository;
		private readonly IClassRoomService _classRoomService;
		private readonly IMapper _mapper;
		public StudentService(IStudentRepository studentRepository, IMapper mapper,
			IClassRoomService classRoomService)
		{
			_studentRepository = studentRepository;
			_mapper = mapper;
			_classRoomService = classRoomService;
		}
		public bool Add(StudentCreateDTO addDTO)
		{
			try
			{
				var entity = _mapper.Map<Student>(addDTO);
				_studentRepository.Add(entity);

				return _studentRepository.Save();
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
				await _studentRepository.RemoveAsync(id);
				return await _studentRepository.SaveAsync();
			}
			catch (Exception ex)
			{

				throw new CustomApplicationExeption(ex.Message); ;
			}
		}

		public ICollection<StudentResponseDTO> GetAll()
		{
			try
			{
				var datas = _studentRepository.GetAll()
								   .Select(s => new StudentResponseDTO
								   {
									   Id = s.Id,
									   Name = s.FirstName,
									   LastName = s.LastName,
									   Number = s.Number
								   }
								   );
				return datas.ToList();
			}
			catch (Exception ex)
			{

				throw new CustomApplicationExeption(ex.Message); ;
			}
		}

		public async Task<StudentCreateDTO> GetById(int id)
		{
			try
			{
				var data = await _studentRepository.GetByIdAsync(id);

				var dto = _mapper.Map<StudentCreateDTO>(data);
				return dto;
			}
			catch (Exception ex)
			{
				throw new CustomApplicationExeption(ex.Message); ;
			}
		}



		public async Task<bool> Update(StudentUpdateDTO update)
		{
			try
			{
				var student = await _studentRepository.GetByIdAsync(update.Id);

				if (student!=null)
				{
					student.FirstName = update.FirstName;
					student.LastName = update.LastName;
					student.Number = update.Number;
					student.ClassRoomId = update.ClassRoomId;
				}

				var result = _studentRepository.Update(student);
				return _studentRepository.Save();
			}
			catch (Exception ex)
			{
				throw new CustomApplicationExeption(ex.Message); ;
			}
		}
	}
}
