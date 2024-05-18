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
    public class ClassesDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Returns a list of Classes in the system
        /// </summary>
        /// <returns>
        /// A list of Classes with all the details
        /// </returns>
        /// <example>GET api/ClassesData/ListClasses</example>
        [HttpGet]
        [Route("api/ClassesData/ListClasses")]
        public IEnumerable<Classes> ListClasses()
        {
            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from classes";

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Classes> ClassesList = new List<Classes> { };

            while (ResultSet.Read())
            {
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string ClassCode = ResultSet["classcode"].ToString();
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                string ClassName = ResultSet["classname"].ToString();
                DateTime StartDate = Convert.ToDateTime(ResultSet["startdate"]);
                DateTime FinishDate = Convert.ToDateTime(ResultSet["finishdate"]);

                Classes Class = new Classes();

                Class.classId = ClassId;
                Class.classCode = ClassCode;
                Class.teacherId = TeacherId;
                Class.className = ClassName;
                Class.startDate = StartDate;
                Class.finishDate = FinishDate;

                ClassesList.Add(Class);
            }

            Conn.Close();

            return ClassesList;
        }

        /// <summary>
        /// Finds a class in the system given an ID
        /// </summary>
        /// <param name="id">The class id primary key</param>
        /// <returns>A classes object</returns>
        /// <example>GET api/ClassesData/FindClass/5</example>
        [HttpGet]
        [Route("api/ClassData/FindClass/{id}")]
        public Classes FindClass(int id)
        {
            Classes Class = new Classes();

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from classes where classid = @id ";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.Prepare();

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                int ClassId = Convert.ToInt32(ResultSet["classid"]);
                string ClassCode = ResultSet["classcode"].ToString();
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                string ClassName = ResultSet["classname"].ToString();
                DateTime StartDate = Convert.ToDateTime(ResultSet["startdate"]);
                DateTime FinishDate = Convert.ToDateTime(ResultSet["finishdate"]);

                Class.classId = ClassId;
                Class.classCode = ClassCode;
                Class.teacherId = TeacherId;
                Class.className = ClassName;
                Class.startDate = StartDate;
                Class.finishDate = FinishDate;
            }

            return Class;
        }
    }
}
