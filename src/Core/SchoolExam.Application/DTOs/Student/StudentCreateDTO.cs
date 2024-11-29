using SchoolExam.Application.DTOs.Base;
using SchoolExam.Application.DTOs.ClassRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Application.DTOs.Student
{
	public class StudentCreateDTO:BaseDTO
	{
		public StudentCreateDTO()
		{
			ClassRooms = new List<ClassRoomResponseDTO>();
		}
		public string Name { get; set; }
		public string LastName { get; set; }
		public decimal Number { get; set; }
		public int ClassRoomId { get; set; }
		public ICollection<ClassRoomResponseDTO> ClassRooms { get; set; }
	}
}
