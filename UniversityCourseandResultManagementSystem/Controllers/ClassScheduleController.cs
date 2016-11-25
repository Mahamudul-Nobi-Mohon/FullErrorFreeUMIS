using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagementSystem.BLL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.Controllers
{
    public class ClassScheduleController : Controller
    {
        ClassScheduleManager classScheduleManager=new ClassScheduleManager();
        public ActionResult ClassScheduleInformationView()
        {
            ViewBag.Departments = classScheduleManager.GetDepartmentDropdownList();
            return View();
        }
        [HttpPost]
        public ActionResult ClassScheduleInformationView(DepartmentID department)
        {
            ViewBag.ClassSchedules = classScheduleManager.GetCourseInformation(department.DepartmentId);
            ViewBag.Departments = classScheduleManager.GetDepartmentDropdownList();
            return View();
        }
	}
}