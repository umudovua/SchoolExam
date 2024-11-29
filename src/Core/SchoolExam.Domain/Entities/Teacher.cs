using SchoolExam.Domain.Entities.Base;
using SchoolExam.Domain.Interfaces;

namespace SchoolExam.Domain.Entities
{
	public class Teacher:BaseEntity,IPerson
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Lesson Lesson { get; set; }
	}
}
