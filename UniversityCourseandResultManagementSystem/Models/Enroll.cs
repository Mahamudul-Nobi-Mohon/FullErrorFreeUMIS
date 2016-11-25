using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagementSystem.Models
{
    public class Enroll
    {
        public int ID { get; set; }
        //int-string
        public int CourseIDs { get; set; }
        public DateTime Date { get; set; }
    }
}