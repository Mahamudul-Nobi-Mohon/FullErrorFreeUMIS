using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using UniversityCourseandResultManagementSystem.Controllers;
using UniversityCourseandResultManagementSystem.BLL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.Controllers
{
    public class ViewResultController : Controller
    {
        ViewResultManager viewResultManager=new ViewResultManager();
          public ActionResult ViewResult()
        {
            ViewBag.StudentList = viewResultManager.GetStudentDropdownList();
            return View();
        }
        [HttpPost]
        public ActionResult ViewResult(Student student)
        {
 
            ViewBag.ViewResults = viewResultManager.GetResultList(student.ID);
            ViewBag.StudentList = viewResultManager.GetStudentDropdownList();
            return View();
        }
              [HttpPost]

        public ActionResult ExportResult()
           {
            ViewBag.StudentList = viewResultManager.GetStudentDropdownList();
            return View();
        }
    
        public ActionResult ExportResult(int id)
             {
                
            ViewBag.ViewResults = viewResultManager.GetResultList(id);
            ViewBag.StudentList = viewResultManager.GetStudentDropdownList();
            return View();
        }

      
        public JsonResult GetStudentName(int id)
        {
            Student student = viewResultManager.GetStudentInformation(id);
            string name = student.Name;
            return Json(name);

        }
        public JsonResult GetStudentEmail(int id)
        {
            Student student = viewResultManager.GetStudentInformation(id);
            string email = student.Email;
            return Json(email);

        }
        public JsonResult GetStudentDepartment(int id)
        {
            Student student = viewResultManager.GetStudentInformation(id);
            string department = student.Department;
            return Json(department);

        }

        public ActionResult GeneratePDF(int id)
        {
            return new ActionAsPdf("ExportResult/"+id)
            {
                FileName  = Server.MapPath("~/Content/StudentResult.pdf")
            };
        }
	}
}