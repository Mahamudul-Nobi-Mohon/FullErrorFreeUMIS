using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.DAL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.BLL
{
    public class TeacherManager
    {
        TeacherGateway teacherGateway = new TeacherGateway();
        public List<Designation> GetDesignationDropdownList()
        {
            List<Designation> designationList = teacherGateway.GetDesignationDropdownList();
            return designationList;
        }
        public List<Department> GetDepartmentDropdownList()
        {
            List<Department> departmentList = teacherGateway.GetDepartmentDropdownList();
            return departmentList;
        }

        public string SetTeacherInformation(Teacher teacher)
        {
            if (IsEmailExist(teacher.Email))
            {
                return "1";
             //   return "The Teacher Email Already Exist";
            }
            else if (teacherGateway.IsContactNumberExist(teacher.ContactNo))
            {
                return "2";
                //return "The Teacher Information Saved Successfully";
            }
            else if (teacherGateway.SetTeacherInformation(teacher))
            {
                return "3";
                //return "The Teacher Information Saved Successfully";
            }
            else
            {
                return "4";
             //   return "Error While Entering data into database";
            }

        }
        public bool IsEmailExist(string email)
        {
            bool result = teacherGateway.IsEmailExist(email);
            return result;
        }
    }
}