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
    public class TeacherDataController : ApiController
    {
        //internal function that will be used by public functions
        private SchoolDbContext dbContext = new SchoolDbContext();

        //This Controller Will access the teacher table of our blog database.
        /// <summary>
        /// Returns a list of teachers in the system
        /// </summary>
        /// <example>GET api/teacherData/GetTeachers</example>
        /// <returns>
        /// A list of teachers
        /// </returns>
        [HttpGet]
        [Route("api/teacherData/GetTeachers")]
        public IEnumerable<Teacher> GetTeachers()
        {
            //SQL query
            string sqlQuery = "SELECT * FROM Teachers";

            //Execute the SQL query and get the list of teachers
            IEnumerable<Teacher> result = GetTeachersByQuery(sqlQuery);

            //Return the result
            return result;
        }

        /// <summary>
        /// Return a teacher information for a specific teacherId
        /// </summary>
        /// <param name="id">The id of the teacher</param>
        /// <example>GET api/teacherData/GetTeacher/{id}</example>
        /// <returns>teacher information</returns>
        [HttpGet]
        [Route("api/teacherData/GetTeacher/{id}")]
        public Teacher GetTeacher(int id)
        {
            //SQL query
            string sqlQuery = "SELECT * FROM Teachers WHERE teacherid = " + id;

            //Execute the SQL query and get the teacher
            IEnumerable<Teacher> result = GetTeachersByQuery(sqlQuery);

            //Convert IEnumerable<Teacher> whith item to Teacher and return it
            return result.FirstOrDefault();
        }

        /// <summary>
        /// Execute the input query and return the result
        /// </summary>
        /// <param name="query">The SQL query</param>
        /// <returns>list of teachers</returns>        
        private List<Teacher> GetTeachersByQuery(string query)
        {
            //Create an empty list of Teachers
            List<Teacher> teachers = new List<Teacher> { };

            MySqlConnection Conn = dbContext.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = query;

            //Gather Result Set of Query into a variable
            MySqlDataReader resultSet = cmd.ExecuteReader();

            //Loop Through Each Row the Result Set
            while (resultSet.Read())
            {
                //creating an instance of teacher model
                Teacher newTeacher = new Teacher();

                //set the values of the new Teacher object
                newTeacher.Teacherid = (int)resultSet["teacherid"];
                newTeacher.Teacherfname = (string)resultSet["teacherfname"];
                newTeacher.Teacherlname = (string)resultSet["teacherlname"];
                newTeacher.Employeenumber = (string)resultSet["employeenumber"];
                newTeacher.Hiredate = (DateTime)resultSet["hiredate"];
                newTeacher.Salary = (decimal)resultSet["salary"];

                //Add the new teacher to the List
                teachers.Add(newTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of teachers
            return teachers;
        }



    }
}
