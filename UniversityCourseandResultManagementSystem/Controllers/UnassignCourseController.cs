using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using UniversityCourseandResultManagementSystem.BLL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.Controllers
{
    public class UnassignCourseController : Controller
    {
        UnassignCourseManager unassignCourseManager=new UnassignCourseManager();
        public ActionResult GetAction()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetAction(MyModel myModel)
        {
            ViewBag.Message = unassignCourseManager.UnassignAllCourse();
            return View();
        }
	}
}