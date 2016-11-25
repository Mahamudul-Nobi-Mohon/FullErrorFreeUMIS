using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagementSystem.Models
{
    public class Result
    {
        public int ID { get; set; }
        public int CoursesID { get; set; }
        public int Grade { get; set; }
    }
}