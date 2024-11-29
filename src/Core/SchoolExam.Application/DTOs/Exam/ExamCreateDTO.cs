using SchoolExam.Application.DTOs.Base;
using SchoolExam.Application.DTOs.Lesson;
using SchoolExam.Application.DTOs.Student;
using System.ComponentModel.DataAnnotations;

namespace SchoolExam.Application.DTOs.Exam
{
	public class ExamCreateDTO : BaseDTO
	{
		public ExamCreateDTO()
		{
			Lessons = new List<LessonResponseDTO>();
			Students = new List<StudentResponseDTO>();
		}

		public DateTime ExamDate { get; set; }

		[Required(ErrorMessage = "This input cannot be empty")]
		[Range(0, 9, ErrorMessage = "0-9")]
		public decimal ResultGrade { get; set; }

		[Required(ErrorMessage = "This input cannot be empty")]
		public int LessonId { get; set; }

		[Required(ErrorMessage = "This input cannot be empty")]
		public int StudentId { get; set; }
		public ICollection<LessonResponseDTO> Lessons { get; set; }
		public ICollection<StudentResponseDTO> Students { get; set; }
	}
}
