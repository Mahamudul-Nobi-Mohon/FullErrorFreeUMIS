using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.DAL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.BLL
{
    public class CourseManager
    {
        CourseGateway courseGateway=new CourseGateway();

        public List<Department> GetDepartmentDropdownList()
        {
            return courseGateway.GetDepartmentDropdownList();
        }
        public List<Semester> GetSemesterDropdownList()
        {
            return courseGateway.GetSemesterDropdownList();
        }

        public bool IsCodeExist(string code)
        {
            return courseGateway.IsCodeExist(code);
        }

        public bool IsNameExist(string name)
        {
            return courseGateway.IsNameExist(name);
        }
        public string SetCourseInformation(Course course)
        {
            if (IsCodeExist(course.Code))
            {
               // return "The Course Code Already Exist";
                return "1";
            }
            else if (IsNameExist(course.Name))
            {
               // return "The Course Name Already Exist";
                return "3";
            }
            else if (courseGateway.SetCourseInformation(course))
            {
                return "2";
              //  return "The Course Information Saved Successfully";
            }
            else
            {
                return "4";
               // return "Error While Entering data into database";
            }

        }
    }
}