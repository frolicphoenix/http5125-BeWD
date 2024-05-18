using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_N01543896.Models;
using Project_N01543896.ViewModels;

namespace Project_N01543896.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Teacher/List
        public ActionResult List(string searchKey = null, decimal? salaryKey = null, decimal? salaryKey2 = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(searchKey);
            if (!string.IsNullOrEmpty(searchKey))
            {
                Teachers = controller.ListTeachers(searchKey);
            }
            else if (salaryKey.HasValue)
            {
                Teachers = controller.ListTeachersBySalary(salaryKey.Value, salaryKey2.Value);
            }
            return View(Teachers);
        }

        //GET : /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            ClassesDataController classesDataController = new ClassesDataController();
            IEnumerable<Classes> NewClassList = controller.FindCLassesByTeacher(id);

            TeacherClassViewData ViewModel = new TeacherClassViewData();
            ViewModel.teacher = NewTeacher;
            ViewModel.classes = NewClassList;

            return View(ViewModel);
        }

        //POST : /teacher/Add
        [HttpPost]
        public ActionResult Add(string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime HireDate, decimal Salary) {

            Debug.WriteLine("This is the Add teacher method");
            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);
            Debug.WriteLine(EmployeeNumber);
            Debug.WriteLine(HireDate);
            Debug.WriteLine(Salary);


            Teacher NewTeacher = new Teacher();
            NewTeacher.teacherFName = TeacherFname;
            NewTeacher.teacherLName = TeacherLname;
            NewTeacher.employeeNumber = EmployeeNumber;
            NewTeacher.hireDate = HireDate;
            NewTeacher.salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }

        //POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id) {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET : /Teacher/New
        public ActionResult New() {
            return View();
        }

        //GET : /Teacher/Ajax_New
        public ActionResult Ajax_New() {
            return View();

        }

        //GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id) {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }

        /// <summary>
        /// Routes to a dynamically generated "Teacher Update" Page. Gathers information from the database.
        /// </summary>
        /// <param name="id">Id of the Teacher</param>
        /// <returns>A dynamic "Update Teacher" webpage which provides the current information of the Teacher and asks the user for new information as part of a form.</returns>
        /// <example>GET : /Teacher /Update/5</example>
        public ActionResult Update(int id) {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }
        public ActionResult Ajax_Update(int id) {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }
        /// <summary>
        /// Receives a POST request containing information about an existing Teacher in the system, with new values. 
        /// Conveys this information to the API, and redirects to the "Teacher Show" page of our updated Teacher.
        /// </summary>
        /// <param name="id">Id of the Teacher to update</param>
        /// <param name="TeacherFname">The updated first name of the Teacher</param>
        /// <param name="TeacherLname">The updated last name of the Teacher</param>
        /// <param name="EmployeeNumber">The updated employee number of the Teacher.</param>
        /// <param name="HireDate">The updated hiring date of the Teacher.</param>
        /// <param name="Salary">The updated salary of the Teacher.</param>
        /// <returns>A dynamic webpage which provides the current information of the Teacher.</returns>
        /// <example>
        /// POST : /Teacher/Update/10
        /// FORM DATA / POST DATA / REQUEST BODY 
        /// {
        ///	"TeacherFname":"Vaibhav",
        ///	"TeacherLname":"Baria",
        ///	"EmployeeNumber":"T000",
        ///	"HireDate":"2024-10-23"
        ///	"Salary":"70"
        /// }
        /// </example>
        [HttpPost]
        public ActionResult Update(int id, string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime HireDate, decimal Salary) {
            Teacher TeacherInfo = new Teacher();
            TeacherInfo.teacherFName = TeacherFname;
            TeacherInfo.teacherLName = TeacherLname;
            TeacherInfo.employeeNumber = EmployeeNumber;
            TeacherInfo.hireDate = HireDate;
            TeacherInfo.salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, TeacherInfo);

            return RedirectToAction("Show/" + id);
        }
    }
}

