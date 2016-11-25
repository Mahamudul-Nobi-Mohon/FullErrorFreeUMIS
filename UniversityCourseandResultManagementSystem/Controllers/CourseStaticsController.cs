using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagementSystem.DAL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.Controllers
{
    public class CourseStaticsController : Controller
    {
        CourseStaticsManager courseStaticsManager=new CourseStaticsManager();
        public ActionResult ViewDepartment()
        {
            ViewBag.Departments = courseStaticsManager.GetDepartmentDropdownList();
            return View();
        }

        [HttpPost]
        public ActionResult ViewDepartment(DepartmentName departmentName,FormCollection form)
        {
            try
            {
                string department = form["Department"].ToString();
                List<CourseStatics> courseStaticses = courseStaticsManager.GetCourseStatics(department);
                ViewBag.CourseStaticses = courseStaticses;
            }
            catch (Exception exception)
            {
                ViewBag.Message = exception.Message;
            }
            ViewBag.Departments = courseStaticsManager.GetDepartmentDropdownList();
            return View();

        }
	}
}