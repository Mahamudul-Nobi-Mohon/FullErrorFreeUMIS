using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagementSystem.Models
{
    public class CourseAssaign
    {
        public string Department { get; set; }
        public int Teacher { get; set; }
        public double CreditToBeTaken { get; set; }
        public double RemainingCredit { get; set; }
        public string CourseID { get; set; }
        public string Name { get; set; }
        public double Credit { get; set; }

        }

}