using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using UniversityCourseandResultManagementSystem.DAL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway departmentGateway=new DepartmentGateway();

        public bool IsCodeExist(string code)
        {
            return departmentGateway.IsCodeExist(code);           
        }
        public bool IsNameExist(string name)
        {
            return departmentGateway.IsNameExist(name);
        }

        public string SetDepartmentInformation(Department department)
        {
            if (IsCodeExist(department.Code))
            {
                return "1";
              //  return "The Department Code Already Exist";
            }
            else if (IsNameExist(department.Name))
            {
                return "3";
               // return "The Department Name Already Exist";
            }
            else if(departmentGateway.SetDepartmentInformation(department))
            {
                return "2";
               // return "The Department Information Saved Successfully";
            }
            else
            {
                return "4";
               // return "Error While Entering data into database";
            }
            
        }

        public List<Department> GetAllDepartments()
        {
            return departmentGateway.GetAllDepartments();
        }
    }
}