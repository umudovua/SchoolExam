using SchoolExam.Domain.Entities.Base;
using SchoolExam.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Domain.Entities
{
	public class Student:BaseEntity,IPerson
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public double Number { get; set; }
		public int ClassRoomId { get; set; }
		public ClassRoom ClassRoom { get; set; }

		public virtual ICollection<Exam> Exams { get; set; }
	}
}
