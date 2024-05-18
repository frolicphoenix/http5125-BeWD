using Project_N01543896.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_N01543896.ViewModels {
    public class TeacherClassViewData {
        public Teacher teacher;
        public IEnumerable<Classes> classes;
    }
}