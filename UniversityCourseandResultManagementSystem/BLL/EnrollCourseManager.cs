using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.DAL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.BLL
{
    public class EnrollCourseManager
    {
        EnrollCourseGateway enrollCourseGateway=new EnrollCourseGateway();

        public List<StudentEnroll> GetStudentDropdownList()
        {
            return enrollCourseGateway.GetStudentDropdownList();
        }

        public Student GetStudentInformation(int id)
        {
            Student student = enrollCourseGateway.GetStudentInformation(id);
            student.Department = GetDepartmentName(student.Department);
            return student;
        }

        public string GetDepartmentName(string code)
        {
            return enrollCourseGateway.GetDepartmentName(code);
        }

        public List<Course> GetCourseDropdownList(int id)
        {
            Student student;
            student=enrollCourseGateway.GetStudentInformation(id);
            return enrollCourseGateway.GetCourseDropdownList(student.Department);
        }

        public string SetEnrollStudent(Enroll enroll)
        {
            string result;
            if (enrollCourseGateway.IsStudentCourseExist(enroll))
            {
                result = "1";
               // result = "This Student already enrolled with this Course";
            }
            else if (enrollCourseGateway.SetEnrollStudent(enroll))
            {
                result = "2";
               // result = "Enroll In a Course information Saved Successfully";
            }
            else
            {
                result = "3";
              //  result = "Error While Entering data into database";
            }
            return result;
        }

    }
}