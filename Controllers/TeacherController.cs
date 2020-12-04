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

        //GET : /Teacher/New
        public ActionResult New()
        {
            return View();
        }

        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create(string Teacherfname, string Teacherlname, string Employeenumber, DateTime Hiredate, decimal Salary)
        {
            Teacher newTeacher = new Teacher();
            newTeacher.Teacherfname = Teacherfname;
            newTeacher.Teacherlname = Teacherlname;
            newTeacher.Employeenumber = Employeenumber;
            newTeacher.Hiredate = Hiredate;
            newTeacher.Salary = Salary;

            TeacherDataController teacherDataController = new TeacherDataController();
            teacherDataController.AddTeacher(newTeacher);

            return RedirectToAction("List");
        }

        //GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            Teacher teacher = teacherDataController.GetTeacher(id);

            return View(teacher);
        }


        //POST : /teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            teacherDataController.DeleteTeacher(id);
            return RedirectToAction("List");
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

