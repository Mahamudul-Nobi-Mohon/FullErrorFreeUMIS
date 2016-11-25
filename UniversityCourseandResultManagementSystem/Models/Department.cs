using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagementSystem.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Department()
        {
            
        }
        public Department(string code,string name)
        {
            Code = code;
            Name = name;
        }
    }
}