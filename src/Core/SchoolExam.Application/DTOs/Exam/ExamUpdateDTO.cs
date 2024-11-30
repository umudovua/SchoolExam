using SchoolExam.Application.DTOs.Base;
using SchoolExam.Application.DTOs.Lesson;
using SchoolExam.Application.DTOs.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Application.DTOs.Exam
{
	public class ExamUpdateDTO:BaseDTO
	{
		

		public DateTime ExamDate { get; set; }

		[Required(ErrorMessage = "This input cannot be empty")]
		[Range(0, 9, ErrorMessage = "0-9")]
		public double ResultGrade { get; set; }

		[Required(ErrorMessage = "This input cannot be empty")]
		public int LessonId { get; set; }

		[Required(ErrorMessage = "This input cannot be empty")]
		public int StudentId { get; set; }
	}
}
