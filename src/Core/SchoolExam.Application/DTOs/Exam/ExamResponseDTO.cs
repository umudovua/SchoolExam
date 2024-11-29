using SchoolExam.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Application.DTOs.Exam
{
	public class ExamResponseDTO:BaseDTO
	{
		public DateTime ExamDate { get; set; }
        public double ResultGrade { get; set; }
		public string LessonName { get; set; }
		public string StudentFullName { get; set; }
	}
}
