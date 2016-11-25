using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using UniversityCourseandResultManagementSystem.BLL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.Controllers
{
    public class CourseAssaignToTeacherController : Controller
    {
        static CourseAssaignToTeacherManager courseAssaign=new CourseAssaignToTeacherManager();
        public ActionResult Save()
        {
            ViewBag.Departments = courseAssaign.GetDepartmentDropdownList();

            return View();
        }
        [HttpPost]
        public ActionResult Save(CourseAssaign assaign)
        {
            ViewBag.Message = courseAssaign.SetCourseAssaignInformation(assaign);
            ViewBag.Departments = courseAssaign.GetDepartmentDropdownList();

            return View();
        }

        public JsonResult GetTeacherDropdownList(string id)
        {
            var result = courseAssaign.GetTeacherDropdownList(id);
            return Json(new SelectList(result, "ID", "Name"));
        }


        public JsonResult GetCourseDropdownList(string id)
        {
            var result = courseAssaign.GetCourseDropdownList(id);
            return Json(new SelectList(result, "Code", "Name"));
        }
        public double GetCreditToBeTaken(int id)
        {
            CourseAssaign course = courseAssaign.GetCreditInformation(id);
            double credit = course.CreditToBeTaken;
            return credit;
        }
        public double GetRemainingCredit(int id)
        {
            CourseAssaign course = courseAssaign.GetCreditInformation(id);
            double credit = course.RemainingCredit;
            return credit;
        }
        public CourseAssaign GetCreditInformation(int id)
        {
            return courseAssaign.GetCreditInformation(id);
        }
        public Course GetCourseInformation(string code)
        {
            return courseAssaign.GetCourseInformation(code);
        }
        public JsonResult GetCourseName(string code)
        {
            Course course = courseAssaign.GetCourseInformation(code);
            string name = course.Name;
            return Json(name);

        }
        public double GetCourseCredit(string code)
        {
            Course course = courseAssaign.GetCourseInformation(code);
            double credit = course.Credit;
            return credit;
        }

        }
}