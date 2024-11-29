using SchoolExam.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Application.DTOs.ClassRoom
{
	public class ClassRoomCreateDTO
	{
		[Required(ErrorMessage = "This input cannot be empty")]
		[Range(0,99,ErrorMessage ="0-99")]
		public decimal Number { get; set; }
		[StringLength(30,ErrorMessage ="30")]
		[Required(ErrorMessage = "This input cannot be empty")]
		public string Name { get; set; }
	}
}
