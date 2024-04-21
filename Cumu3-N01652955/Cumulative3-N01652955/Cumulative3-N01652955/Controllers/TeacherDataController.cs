using Cumulative3_N01652955.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using Mysqlx.Datatypes;
using System.Web.Http.Cors;

namespace Cumulative3_N01652955.Controllers
{
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Returns a list of Teachers in the system
        /// </summary>
        /// <returns>
        /// A list of teachers (first names and last names)
        /// </returns>
        /// <example>GET api/TeacherData/ListTeachers</example>
        /// <example>GET api/TeacherData/ListTeachers/eren</example>
        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{searchKey?}")]
        public IEnumerable<Teacher> ListTeachers(string searchKey = null)
        {

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText =
                "Select * from teachers where lower(teacherfname) like lower(@stringKey) "
                + "or lower(teacherlname) like lower(@stringKey) "
                + "or lower(concat(teacherfname, ' ', teacherlname)) like lower(@stringKey)";

            cmd.Parameters.AddWithValue("@stringKey", "%" + searchKey + "%");

            cmd.Prepare();

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Teacher> TeachersList = new List<Teacher> { };

            while (ResultSet.Read())
            {
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string EmployeeNumber = ResultSet["employeenumber"].ToString();
                DateTime HireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                decimal Salary = Convert.ToDecimal(ResultSet["salary"]);

                Teacher TeacherInstance = new Teacher();

                TeacherInstance.TeacherId = TeacherId;
                TeacherInstance.TeacherFname = TeacherFname;
                TeacherInstance.TeacherLname = TeacherLname;
                TeacherInstance.EmployeeNumber = EmployeeNumber;
                TeacherInstance.HireDate = HireDate;
                TeacherInstance.Salary = Salary;

                TeachersList.Add(TeacherInstance);
            }

            Conn.Close();

            return TeachersList;
        }

       
        /// <summary>
        /// Finds a teacher in the system given an ID
        /// </summary>
        /// <param name="id">The teachers primary key</param>
        /// <returns>A teacher object</returns>
        /// <example>GET api/TeacherData/FindTeacher/5</example>
        [HttpGet]
        [Route("api/TeacherData/FindTeacher/{id}")]
        public Teacher FindTeacher(int id)
        {
            Teacher Teacher = new Teacher();

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from teachers where TeacherID =  @id ";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.Prepare();

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                int TeacherId = Convert.ToInt32(ResultSet["TeacherID"]);
                string TeacherFname = ResultSet["TeacherFname"].ToString();
                string TeacherLname = ResultSet["TeacherLname"].ToString();
                string EmployeeNumber = ResultSet["EmployeeNumber"].ToString();
                DateTime HireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                decimal Salary = Convert.ToDecimal(ResultSet["salary"]);

                Teacher.TeacherId = TeacherId;
                Teacher.TeacherFname = TeacherFname;
                Teacher.TeacherLname = TeacherLname;
                Teacher.EmployeeNumber = EmployeeNumber;
                Teacher.HireDate = HireDate;
                Teacher.Salary = Salary;
            }

            return Teacher;
        }

        /// <summary>
        /// Adds a teacher to the MySQL Database.
        /// </summary>
        /// <param name="NewTeacher">An object with fields that map to the columns of the teachers's table.</param>
        /// <example>
        /// POST api/TeacherData/AddTeacher 
        /// FORM DATA / POST DATA / REQUEST BODY 
        /// {
        ///	"TeacherFname":"Pranjal",
        ///	"TeacherLname":"Lokhande",
        ///	"EmployeeNumber":"N0165",
        ///	"Hiredate":"2024-04-17"
        ///	"Salary":"69"
        /// }
        /// </example>
        [HttpPost]
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public void AddTeacher([FromBody] Teacher NewTeacher)
        {

            

            MySqlConnection Conn = School.AccessDatabase();

           /// Debug.WriteLine(NewTeacher.TeacherFname);

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();


            cmd.CommandText = "INSERT INTO teachers (teacherfname, teacherlname, employeenumber, hiredate, salary) values (@TeacherFname,@TeacherLname,@EmployeeNumber, @HireDate, @Salary)";
            cmd.Parameters.AddWithValue("@TeacherFname", NewTeacher.TeacherFname);
            cmd.Parameters.AddWithValue("@TeacherLname", NewTeacher.TeacherLname);
            cmd.Parameters.AddWithValue("@EmployeeNumber", NewTeacher.EmployeeNumber);
            cmd.Parameters.AddWithValue("@HireDate", NewTeacher.HireDate);
            cmd.Parameters.AddWithValue("@Salary", NewTeacher.Salary);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();

        }

        /// <summary>
        /// Deletes a teacher from the Database if the ID of that teacher exists.
        /// </summary>
        /// <param name="id">The ID of the Teacher.</param>
        /// <example>POST /api/TeacherData/Delete/3 
        /// redirects to Delete Confirmation page
        /// </example>
        [HttpPost]
        [Route("api/TeacherData/DeleteTeacher/{id}")]
        public void DeleteTeacher(int id)
        {
            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            //SQL query to remove the relation of associated teacher from the classes table
            MySqlCommand updateCmd = Conn.CreateCommand();

            updateCmd.CommandText = "UPDATE classes SET teacherid = NULL WHERE teacherid = @id";
            updateCmd.Parameters.AddWithValue("@id", id);
            updateCmd.Prepare();
            updateCmd.ExecuteNonQuery();

            //SQL query to delete the teacher
            MySqlCommand deleteCmd = Conn.CreateCommand();

            deleteCmd.CommandText = "Delete from teachers where teacherid=@id";

            deleteCmd.Parameters.AddWithValue("@id", id);
            deleteCmd.Prepare();

            deleteCmd.ExecuteNonQuery();

            Conn.Close();

        }

        /// <summary>
        /// Updates information of a teacher from the Database.
        /// </summary>
        /// <param name="id">The ID of the Teacher.</param>
        /// <example>POST /api/TeacherData/Update/3 
        /// redirects to teacher/show/3 and shows the updated teacher information
        /// </example>
        [HttpPost]
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        public void UpdateTeacher(int id, [FromBody] Teacher teacherInfo)
        {

            MySqlConnection conn = School.AccessDatabase();

            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "UPDATE teachers SET TeacherFname = @TeacherFname, TeacherLname = @TeacherLname, EmployeeNumber = @EmployeeNumber, HireDate = @HireDate, Salary = @Salary WHERE TeacherId = @TeacherId";
            cmd.Parameters.AddWithValue("@TeacherFname", teacherInfo.TeacherFname);
            cmd.Parameters.AddWithValue("@TeacherLname", teacherInfo.TeacherLname);
            cmd.Parameters.AddWithValue("@EmployeeNumber", teacherInfo.EmployeeNumber);
            cmd.Parameters.AddWithValue("@HireDate", teacherInfo.HireDate);
            cmd.Parameters.AddWithValue("@Salary", teacherInfo.Salary);
            cmd.Parameters.AddWithValue("@TeacherId", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
