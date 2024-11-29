using SchoolExam.Application.DTOs.Base;
using SchoolExam.Application.DTOs.ClassRoom;
using SchoolExam.Application.DTOs.Teacher;
using System.ComponentModel.DataAnnotations;

namespace SchoolExam.Application.DTOs.Lesson
{
	public class LessonCreateDTO
	{
		public LessonCreateDTO()
		{
			Teachers = new List<TeacherResponseDTO>();
			ClassRooms = new List<ClassRoomResponseDTO>();
		}
		[Required(ErrorMessage = "This input cannot be empty")]
		[Range(0, 99, ErrorMessage = "0-99")]
		public string Code { get; set; }

		[Required(ErrorMessage = "This input cannot be empty")]
		[StringLength(30, ErrorMessage = "30")]
		public string Name { get; set; }

		[Required(ErrorMessage = "This input cannot be empty")]
		public int TeacherId { get; set; }

		[Required(ErrorMessage = "This input cannot be empty")]
		public int ClassRoomId { get; set; }

		public ICollection<TeacherResponseDTO> Teachers { get; set; }
		public ICollection<ClassRoomResponseDTO> ClassRooms { get; set; }
	}
}
