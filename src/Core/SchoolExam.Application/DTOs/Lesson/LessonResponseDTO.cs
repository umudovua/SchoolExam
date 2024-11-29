using SchoolExam.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Application.DTOs.Lesson
{
	public class LessonResponseDTO:BaseDTO
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public string TeacherFullName { get; set; }
		public decimal ClassRoom { get; set; }
	}
}
