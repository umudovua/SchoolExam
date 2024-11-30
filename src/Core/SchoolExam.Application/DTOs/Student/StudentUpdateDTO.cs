using SchoolExam.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Application.DTOs.Student
{
	public class StudentUpdateDTO:BaseDTO
	{
		[Required(ErrorMessage = "This input cannot be empty")]
		[StringLength(30, ErrorMessage = "30")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "This input cannot be empty")]
		[StringLength(30, ErrorMessage = "30")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "This input cannot be empty")]
		public double Number { get; set; }
		[Required(ErrorMessage = "This input cannot be empty")]
		public int ClassRoomId { get; set; }
	}
}
