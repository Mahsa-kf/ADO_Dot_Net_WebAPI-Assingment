using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using School.Models;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Student/List
        public ActionResult List()
        {
           StudentDataController StudentDataController = new StudentDataController();
            IEnumerable<Student> Students = StudentDataController.GetStudents();
            return View(Students);
        }

        //GET : /Student/Show/{id}
        public ActionResult show(int id)
        {
            StudentDataController studentDataController = new StudentDataController();
            Student student = studentDataController.GetStudent(id);
            ActionResult result = View(student);
            return result;
        }


    }
}

