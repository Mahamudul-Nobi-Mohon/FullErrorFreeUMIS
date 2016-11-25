using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagementSystem.BLL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.DAL
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();

        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Department department)
        {
            try
            {

                string result = departmentManager.SetDepartmentInformation(department);
                ViewBag.Message = result;
            }
            catch (Exception exception)
            {
                ViewBag.Message = "4";
            }
            return View(department);
        }
    }
}