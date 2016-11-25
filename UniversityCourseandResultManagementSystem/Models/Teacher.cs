using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagementSystem.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int Designation { get; set; }
        public string Department { get; set; }
        public double CreditToBeTaken { get; set; }

    }
}