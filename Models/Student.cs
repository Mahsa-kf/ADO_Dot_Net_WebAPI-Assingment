using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Student
    {
        // The following fields define a Student
        public int Studentid { get; set; }
        public string Studentfname { get; set; }
        public string Studentlname { get; set; }
        public string Studentnumber { get; set; }
        public DateTime Enroldate { get; set; }
    }
}
