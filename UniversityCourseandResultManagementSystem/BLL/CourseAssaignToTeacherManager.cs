using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.DAL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.BLL
{
    public class CourseAssaignToTeacherManager
    {
        CourseAssaignToTeacherGateway courseAssaignToTeacherGateway=new CourseAssaignToTeacherGateway();

        public List<Department> GetDepartmentDropdownList()
        {
            return courseAssaignToTeacherGateway.GetDepartmentDropdownList();
        }

        public List<Teacher> GetTeacherDropdownList(string code)
        {
            return courseAssaignToTeacherGateway.GetTeacherDropdownList(code);
        }


        public CourseAssaign GetCreditInformation(int id)
        {
            return courseAssaignToTeacherGateway.GetCreditInformation(id);
        }

        public List<Course> GetCourseDropdownList(string code)
        {
            return courseAssaignToTeacherGateway.GetCourseDropdownList(code);
        }

        public Course GetCourseInformation(string code)
        {
            return courseAssaignToTeacherGateway.GetCourseInformation(code);
        }

        public bool IsCourseExist(string code)
        {
            return courseAssaignToTeacherGateway.IsCourseExist(code);
        }
        public string SetCourseAssaignInformation(CourseAssaign courseAssaign)
        {
            if (IsCourseExist(courseAssaign.CourseID))
            {
                return "1";
               // return "<h3 class='alert alert-danger'>This Course Already Assaign to a teacher</h3>";
            }
            else if (courseAssaignToTeacherGateway.SetCourseAssaignInformation(courseAssaign))
            {
                return "2";
               // return "<h3 class='alert alert-success'>The Course Assaign Information Saved Successfully</h3>";
            }
            else
            {
                return "3";
               // return "<h3 class='alert alert-danger'>Error While Entering data into database</h3>";
            }

        }
        
    }
}