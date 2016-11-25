using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagementSystem.BLL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        TeacherManager teacherManager = new TeacherManager();
        public ActionResult Save()
        {
            ViewBag.Departments = teacherManager.GetDepartmentDropdownList();
            ViewBag.Designation = teacherManager.GetDesignationDropdownList();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            try
            {
                string result = teacherManager.SetTeacherInformation(teacher);
                ViewBag.Message = result;
            }
            catch (Exception exception)
            {
                ViewBag.Message = "4";
            }
            ViewBag.Departments = teacherManager.GetDepartmentDropdownList();
            ViewBag.Designation = teacherManager.GetDesignationDropdownList();
            return View();

        }
    }
}