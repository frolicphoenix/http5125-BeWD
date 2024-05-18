using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using Project_N01543896.Models;

namespace Project_N01543896.Controllers
{
    public class StudentDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Returns a list of Students in the system
        /// </summary>
        /// <returns>
        /// A list of Students with all the details
        /// </returns>
        /// <example>GET api/StudentData/ListStudents</example>
        [HttpGet]
        [Route("api/StudentData/ListStudents")]
        public IEnumerable<Student> ListStudents()
        {
            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from students";

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Student> StudentsList = new List<Student> { };

            while (ResultSet.Read())
            {
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string StudentFName = ResultSet["studentfname"].ToString();
                string StudentLName = ResultSet["studentlname"].ToString();
                string StudentNumber = ResultSet["studentnumber"].ToString();
                DateTime EnrolDate = Convert.ToDateTime(ResultSet["enroldate"]);

                Student Student = new Student();

                Student.studentId = StudentId;
                Student.studentFName = StudentFName;
                Student.studentLName = StudentLName;
                Student.studentNumber = StudentNumber;
                Student.enrolDate = EnrolDate;

                StudentsList.Add(Student);
            }

            Conn.Close();

            return StudentsList;
        }

        /// <summary>
        /// Finds a student in the system given an ID
        /// </summary>
        /// <param name="id">The student id primary key</param>
        /// <returns>A student object</returns>
        [HttpGet]
        [Route("api/StudentData/FindStudent/{id}")]
        public Student FindStudent(int id)
        {
            Student Student = new Student();

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from students where studentid = @id ";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.Prepare();

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);
                string StudentFName = ResultSet["studentfname"].ToString();
                string StudentLName = ResultSet["studentlname"].ToString();
                string StudentNumber = ResultSet["studentnumber"].ToString();
                DateTime EnrolDate = Convert.ToDateTime(ResultSet["enroldate"]);

                Student.studentId = StudentId;
                Student.studentFName = StudentFName;
                Student.studentLName = StudentLName;
                Student.studentNumber = StudentNumber;
                Student.enrolDate = EnrolDate;
            }

            return Student;
        }
    }
}
