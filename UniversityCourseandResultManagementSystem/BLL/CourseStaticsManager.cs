using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.DAL
{
    public class CourseStaticsManager
    {
        CourseStaticsGateway courseStaticsGateway=new CourseStaticsGateway();

        public List<Department> GetDepartmentDropdownList()
        {
            return courseStaticsGateway.GetDepartmentDropdownList();
        }       
        public List<CourseStatics> GetCourseStatics(string departmentCode)
        {
            return courseStaticsGateway.GetCourseStatics(departmentCode);
        }
    }
}