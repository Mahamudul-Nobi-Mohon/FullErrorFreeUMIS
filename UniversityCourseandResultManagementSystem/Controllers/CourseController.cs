using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagementSystem.BLL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.DAL
{
    public class CourseController : Controller
    {
        CourseManager courseManager=new CourseManager();
        public ActionResult Save()
        {
            ViewBag.Departments = courseManager.GetDepartmentDropdownList();
            ViewBag.Semester = courseManager.GetSemesterDropdownList();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Course course)
        {
            try
            {
                string result = courseManager.SetCourseInformation(course);
                ViewBag.Message = result;
            }
            catch (Exception exception)
            {
                //ViewBag.Message = "Please Check Your Data. Something is Wrong";

                ViewBag.Message = "4";
            }
            ViewBag.Departments = courseManager.GetDepartmentDropdownList();
            ViewBag.Semester = courseManager.GetSemesterDropdownList();
            return View();

        }
	}
}