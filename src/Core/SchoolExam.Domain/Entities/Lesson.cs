using SchoolExam.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Domain.Entities
{
	public class Lesson:BaseEntity
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public int ClassRoomId { get; set; }
		public ClassRoom ClassRoom { get; set; }
		public int TeacherId { get; set; }
		public Teacher Teacher { get; set; }

		public virtual ICollection<Exam> Exams { get; set; }
	}
}
