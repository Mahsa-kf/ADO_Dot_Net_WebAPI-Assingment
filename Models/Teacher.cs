using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Teacher
    {
        //The following fields define a teacher
        public int Teacherid { get; set; }
        public string Teacherfname { get; set; }
        public string Teacherlname { get; set; }
        public string Employeenumber { get; set; }
        public DateTime Hiredate { get; set; }
        public decimal Salary { get; set; }
    }
}