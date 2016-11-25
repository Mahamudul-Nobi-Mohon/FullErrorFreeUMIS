using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagementSystem.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Credit { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public int Semester { get; set; }

        public Course()
        {
            
        }
        public Course(string code,string name,double credit,string descripton,string department,int semester)
        {
            Code = code;
            Name = name;
            Credit = credit;
            Description = descripton;
            Department = department;
            Semester = semester;
        }
    }
}