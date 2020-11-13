using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using School.Models;

namespace School.Controllers
{
    public class StudentDataController : ApiController
    {
        private SchoolDbContext dbContext = new SchoolDbContext();

        //This Controller Will access the Student table of our School database.
        /// <summary>
        /// Returns a list of Students in the system
        /// </summary>
        /// <example>GET api/StudentData/GetStudent</example>
        /// <returns>
        /// A list of students
        /// </returns>
        
        [HttpGet]
        [Route("api/StudentData/GetStudent")]
        public IEnumerable<Student> GetStudents()
        {
            string sqlQuery = "SELECT * FROM Students";
            IEnumerable<Student> result = GetStudentByQuey(sqlQuery);
            return result;
        }

        /// <summary>
        /// Return a student information  for a specific studentId
        /// </summary>
        /// <param name="id">The id of the student</param>
        /// <example>GET api/studentData/GetStudent/{id}</example>
        /// <returns>student information</returns>

        [HttpGet]
        [Route("api/StudentData/GetStudent/{id}")]
        public Student GetStudent(int id)
        {
            string sqlQuery = "SELECT * FROM students WHERE Studentid = " + id;
            IEnumerable<Student> result = GetStudentByQuey(sqlQuery);
            return result.FirstOrDefault();
        }

        /// <summary>
        /// Execute the input query and return the result
        /// </summary>
        /// <param name="query">The SQL query</param>
        /// <returns>list of Students</returns>       
        private List<Student> GetStudentByQuey(string query)
        {
            //Create an empty list of Students
            List<Student> students = new List<Student> { };

            MySqlConnection Conn = dbContext.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = query;

            //Executing the sql query and put the result into resultSet variable
            MySqlDataReader resultSet = cmd.ExecuteReader();

            //Loop Through Each Row the Result Set
            while (resultSet.Read())
            {
                //creating an instance of Student model
                Student newStudent = new Student();

                //set the values of the new Student object
                newStudent.Studentid = (int)resultSet["studentid"];
                newStudent.Studentfname = (string)resultSet["studentfname"];
                newStudent.Studentlname = (string)resultSet["studentlname"];
                newStudent.Studentnumber = (string)resultSet["studentnumber"];
                newStudent.Enroldate = (DateTime)resultSet["enroldate"];

                //Add the new Student to the List
                students.Add(newStudent);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of students
            return students;

        }
    }
}
