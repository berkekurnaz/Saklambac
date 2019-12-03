using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saklambac_School_App.Models
{
    public class Student
    {

        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Number { get; set; }
        public int Class { get; set; }
        public double Grade { get; set; }
        public string TeacherName { get; set; }

        public Student()
        {
                
        }

    }
}
