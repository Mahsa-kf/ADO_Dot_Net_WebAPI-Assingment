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
            Teacher SelectedTeacher = teacherDataController.GetTeacher(id);
            ActionResult result = View(SelectedTeacher);
            return result;
        }

        //Get : /Teacher/ Update/{id}
        public ActionResult Update( int id)
        {
            TeacherDataController teacherDataController = new TeacherDataController();
            Teacher SelectedTeacher = teacherDataController.GetTeacher(id);
            return View(SelectedTeacher);
        }


        /// <summary>
        /// Receives a POST request containing information about an existing teacher in the system, with new values.
        /// </summary>
        /// <param name="id">Id of the Teacher to update</param>
        /// <param name="Teacherfname"> The teacher's first name</param>
        /// <param name="Teacherlname">The teacher's last name</param>
        /// <param name="Employeenumber">The teacher's employee number</param>
        /// <param name="Hiredate">The teacher's hire date</param>
        /// <param name="Salary">The teacher's salary</param>
        /// <returns>A dynamic webpage which provides the current information of the teacher</returns>
        /// <example>
        /// POST : /Teacher/Update/3
        /// FORM DATA / POST DATA / REQUEST BODY 
        /// {
        ///	"Teacherfname":"Linda",
        ///	"Teacherlname":"Fard"
        ///	}
        /// </example>
        [HttpPost]
        public ActionResult Update(int id, string Teacherfname, string Teacherlname, string Employeenumber, DateTime Hiredate, decimal Salary)
        {
            Teacher teacher = new Teacher();

            teacher.Teacherid = id;
            teacher.Teacherfname = Teacherfname;
            teacher.Teacherlname = Teacherlname;
            teacher.Employeenumber = Employeenumber;
            teacher.Hiredate= Hiredate;
            teacher.Salary = Salary;

            TeacherDataController teacherDataController = new TeacherDataController();
            teacherDataController.UpdateTeacher(teacher);

            return RedirectToAction("Show/" + id);
        }
    }
} 

