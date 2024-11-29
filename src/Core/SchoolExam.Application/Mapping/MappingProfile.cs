using AutoMapper;
using SchoolExam.Application.DTOs.ClassRoom;
using SchoolExam.Application.DTOs.Exam;
using SchoolExam.Application.DTOs.Lesson;
using SchoolExam.Application.DTOs.Student;
using SchoolExam.Application.DTOs.Teacher;
using SchoolExam.Domain.Entities;

namespace SchoolExam.Application.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Student, StudentCreateDTO>().ReverseMap();
			CreateMap<Student, StudentResponseDTO>().ReverseMap();

			CreateMap<Lesson, LessonCreateDTO>().ReverseMap();
			CreateMap<Lesson, LessonResponseDTO>().ReverseMap();

			CreateMap<Domain.Entities.Exam, ExamCreateDTO>().ReverseMap();
			CreateMap<Domain.Entities.Exam, ExamResponseDTO>().ReverseMap();

			CreateMap<Teacher, TeacherCreateDTO>().ReverseMap();
			CreateMap<Teacher, TeacherResponseDTO>().ReverseMap();

			CreateMap<ClassRoom, ClassRoomCreateDTO>().ReverseMap();
			CreateMap<ClassRoom, ClassRoomResponseDTO>().ReverseMap();
		}
	}
}
