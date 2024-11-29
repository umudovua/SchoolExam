using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Application.Exeptions
{
    public class CustomApplicationExeption : Exception
    {
        public CustomApplicationExeption(string message) : base(message)
        {

        }

        public CustomApplicationExeption(Exception ex) :this(ex.Message )
        {

        }

        public CustomApplicationExeption()
        {
        }
    }
}
