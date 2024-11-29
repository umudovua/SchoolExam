using SchoolExam.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Application.DTOs.Student
{
    public class StudentResponseDTO : BaseDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public double Number { get; set; }
        public decimal ClassRoomNumber { get; set; }
    }
}
