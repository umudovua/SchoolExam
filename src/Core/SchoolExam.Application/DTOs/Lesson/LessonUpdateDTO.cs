using SchoolExam.Application.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace SchoolExam.Application.DTOs.Lesson
{
	public class LessonUpdateDTO:BaseDTO
	{
		[Required(ErrorMessage = "This input cannot be empty")]
		[Range(0, 99, ErrorMessage = "0-99")]
		public string Code { get; set; }

		[Required(ErrorMessage = "This input cannot be empty")]
		[StringLength(30, ErrorMessage = "30")]
		public string Name { get; set; }

		//[Required(ErrorMessage = "This input cannot be empty")]
		public int TeacherId { get; set; }

		//[Required(ErrorMessage = "This input cannot be empty")]
		public int ClassRoomId { get; set; }
	}
}
