using SchoolExam.Application.DTOs.Base;
using SchoolExam.Application.DTOs.Lesson;
using SchoolExam.Application.DTOs.Student;

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
		public decimal ResultGrade { get; set; }
		public int LessonId { get; set; }
		public int StudentId { get; set; }
		public ICollection<LessonResponseDTO> Lessons { get; set; }
		public ICollection<StudentResponseDTO> Students { get; set; }
	}
}
