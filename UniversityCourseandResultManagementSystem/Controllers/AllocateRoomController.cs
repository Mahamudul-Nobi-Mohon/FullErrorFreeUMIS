using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagementSystem.BLL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.Controllers
{
    public class AllocateRoomController : Controller
    {
     AllocateRoomManager allocateRoomManager=new AllocateRoomManager();
        public ActionResult Save()
        {
            ViewBag.Departments = allocateRoomManager.GetDepartmentDropdownList();
            ViewBag.Rooms = allocateRoomManager.GetRoomDropdownList();
            ViewBag.Days = allocateRoomManager.GetDayDropdownList();
            return View();
        }
        [HttpPost]
        public ActionResult Save(AllocateRoom allocateRoom)
        {
            int result = allocateRoomManager.SetRoomAllocationInformation(allocateRoom);
            //if ( result== 1)
            //{
            //    ViewBag.Message = " Time Conflit with another class. please reallocate time";
            //}
            //else if( result== 2)
            //{
            //    ViewBag.Message =  "The Room Allocation Information Successfully saved";
            //}
            //else
            //{
            //    ViewBag.Message = "There is some error while entering data into database";
            //}
            ViewBag.Message = result.ToString();
            ViewBag.Departments = allocateRoomManager.GetDepartmentDropdownList();
            ViewBag.Rooms = allocateRoomManager.GetRoomDropdownList();
            ViewBag.Days = allocateRoomManager.GetDayDropdownList();
            return View();
        }
        public JsonResult GetCourseDropdownList(int id)
        {
            var result = allocateRoomManager.GetCourseDropdownList(id);
            return Json(new SelectList(result, "ID", "Name"));
        }
	}
}