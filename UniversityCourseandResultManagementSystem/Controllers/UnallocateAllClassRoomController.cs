﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseandResultManagementSystem.BLL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.Controllers
{
    public class UnallocateAllClassRoomController : Controller
    {
        UnallocateAllClassRoomManager unallocateAllClassRoomManager=new UnallocateAllClassRoomManager();
        public ActionResult GetAction()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetAction(MyModel myModel)
        {
            ViewBag.Message = unallocateAllClassRoomManager.UnallocateAllClassRoom();
            return View();
        }
	}
}