using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagementSystem.Models
{
    public class ClassSchedule
    {
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string SchuduleInfo { get; set; }
    }
}