using SchoolExam.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Domain.Entities
{
	public class ClassRoom:BaseEntity
	{
		public decimal Number { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Student> Students { get; set; }
		public virtual ICollection<Lesson> Lessons { get; set; }
	}
}
