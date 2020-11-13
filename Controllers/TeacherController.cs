using School.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Teacher/List
        public ActionResult List()
        {
          TeacherDataController teacherDataController = new TeacherDataController();
            IEnumerable<Teacher> teachers = teacherDataController.GetTeachers();
            return View(teachers);
        }

        //GET : /teacher/Show/{id}
        public ActionResult show(int id)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            Teacher teacher = teacherDataController.GetTeacher(id);
            ActionResult result = View(teacher);
            return result;
        }


    }
} 

