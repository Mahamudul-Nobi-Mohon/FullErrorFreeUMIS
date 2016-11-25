using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagementSystem.BLL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.Controllers
{
    public class EnrollCourseController : Controller
    {
       EnrollCourseManager enrollCourseManager=new EnrollCourseManager();
        public ActionResult Save()
        {
            ViewBag.StudentEnrolls = enrollCourseManager.GetStudentDropdownList();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Enroll enroll)
        {
            ViewBag.Message = enrollCourseManager.SetEnrollStudent(enroll);
            ViewBag.StudentEnrolls = enrollCourseManager.GetStudentDropdownList();
            return View();
        }
        public JsonResult GetStudentName(int id)
        {
            Student student = enrollCourseManager.GetStudentInformation(id);
            string name = student.Name;
            return Json(name);

        }
        public JsonResult GetStudentEmail(int id)
        {
            Student student = enrollCourseManager.GetStudentInformation(id);
            string email = student.Email;
            return Json(email);

        }
        public JsonResult GetStudentDepartment(int id)
        {
            Student student = enrollCourseManager.GetStudentInformation(id);
            string department = student.Department;
            return Json(department);

        }
        public JsonResult GetCourseDropdownList(int id)
        {
            var result = enrollCourseManager.GetCourseDropdownList(id);
            return Json(new SelectList(result, "ID", "Name"));
        }
	}
}