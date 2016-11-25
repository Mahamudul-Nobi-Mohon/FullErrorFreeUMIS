using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagementSystem.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }

        public Student()
        {
            
        }
        public Student(string name,string email,string contactNo,DateTime date,string address,string department)
        {
            Name = name;            
            Email = email;
            ContactNo = contactNo;
            Date = date;
            Address = address;
            Department = department;

        }
    }
}