using SchoolExam.Application.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Application.DTOs.Teacher
{
    public class TeacherCreateDTO : BaseDTO
    {
        int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
