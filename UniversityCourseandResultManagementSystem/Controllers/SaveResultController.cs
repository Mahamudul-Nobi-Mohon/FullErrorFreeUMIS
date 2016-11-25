using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagementSystem.BLL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.Controllers
{
    public class SaveResultController : Controller
    {
        SaveResultManager saveResultManager=new SaveResultManager();
        public ActionResult Save()
        {
            ViewBag.StudentList = saveResultManager.GetStudentDropdownList();
            ViewBag.Grades = saveResultManager.GetGradeDropdownList();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Result result)
        {
            ViewBag.Message = saveResultManager.SetStudentResult(result);
            ViewBag.StudentList = saveResultManager.GetStudentDropdownList();
            ViewBag.Grades = saveResultManager.GetGradeDropdownList();
            return View();
        }
        public JsonResult GetStudentName(int id)
        {
            Student student = saveResultManager.GetStudentInformation(id);
            string name = student.Name;
            return Json(name);

        }
        public JsonResult GetStudentEmail(int id)
        {
            Student student = saveResultManager.GetStudentInformation(id);
            string email = student.Email;
            return Json(email);

        }
        public JsonResult GetStudentDepartment(int id)
        {
            Student student = saveResultManager.GetStudentInformation(id);
            string department = student.Department;
            return Json(department);

        }
        public JsonResult GetCourseDropdownList(int id)
        {
            var result = saveResultManager.GetCourseDropdownList(id);
            return Json(new SelectList(result, "ID", "Name"));
        }
	}
}