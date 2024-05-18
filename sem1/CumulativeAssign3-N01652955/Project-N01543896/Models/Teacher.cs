using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Project_N01543896.Models
{
    public class Teacher
    {
        public int teacherId;
        public string teacherName;
        public string teacherFName;
        public string teacherLName;
        public string employeeNumber;
        public DateTime hireDate;
        public decimal salary;

        public bool IsValid() {
            bool valid = true;

            if (teacherFName == null || teacherLName == null || employeeNumber == null || salary == 0) {
                valid = false;
            }
            Debug.WriteLine("The model validity is : " + valid);

            return valid;
        }
        public Teacher() { }
    }
}
