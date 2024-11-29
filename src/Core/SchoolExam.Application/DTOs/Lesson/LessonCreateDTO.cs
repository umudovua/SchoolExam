using SchoolExam.Application.DTOs.Base;
using SchoolExam.Application.DTOs.ClassRoom;
using SchoolExam.Application.DTOs.Teacher;

namespace SchoolExam.Application.DTOs.Lesson
{
	public class LessonCreateDTO: BaseDTO
	{
		public LessonCreateDTO()
		{
			Teachers = new List<TeacherResponseDTO>();
			ClassRooms = new List<ClassRoomResponseDTO>();
		}
		public string Code { get; set; }
		public string Name { get; set; }
		public int TeacherId { get; set; }
		public int ClassRoomId { get; set; }

		public ICollection<TeacherResponseDTO> Teachers { get; set; }
		public ICollection<ClassRoomResponseDTO> ClassRooms { get; set; }
	}
}
