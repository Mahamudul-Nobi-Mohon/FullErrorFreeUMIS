using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagementSystem.BLL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        StudentManager studentManager = new StudentManager();
        public ActionResult Save()
        {
            ViewBag.Departments = studentManager.GetDepartmentDropdownList();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            try
            {
                string result = studentManager.SetStudentInformation(student);
                ViewBag.Message = result;
            }
            catch (Exception exception)
            {
                ViewBag.Message = exception.Message;
            }
            ViewBag.Departments = studentManager.GetDepartmentDropdownList();
            return View();

        }
	}
}