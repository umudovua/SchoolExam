using SchoolExam.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Domain.Entities
{
	public class Exam:BaseEntity
	{
		public DateTime ExamDate { get; set; }
		public double ResultGrade { get; set; }
		public int LessonId { get; set; }
		public Lesson Lesson { get; set; }
		public int StudentId { get; set; }
		public Student Student { get; set; }
	}
}
