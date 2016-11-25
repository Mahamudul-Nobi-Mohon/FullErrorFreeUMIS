using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagementSystem.BLL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.DAL
{
    public class ViewAllDepartmentController : Controller
    {
        DepartmentManager departmentManager=new DepartmentManager();
 
        public ActionResult Show()
        {
            ViewBag.Departments = departmentManager.GetAllDepartments();
            return View();
        }        
	}
}