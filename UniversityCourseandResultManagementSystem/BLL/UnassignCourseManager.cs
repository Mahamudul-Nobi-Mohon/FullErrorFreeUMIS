using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.DAL;

namespace UniversityCourseandResultManagementSystem.BLL
{
    public class UnassignCourseManager
    {
        UnassignCourseGateway unassignCourseGateway=new UnassignCourseGateway();

        public List<int> GetCourseIdList()
        {
            return unassignCourseGateway.GetCourseIdList();
        }

        public bool SetImvisible(int id)
        {
            return unassignCourseGateway.SetImvisible(id);
        }

        public string UnassignAllCourse()
        {
            bool result = false;
            List<int> courseAssignId = GetCourseIdList();
            foreach (int id in courseAssignId)
            {
                result = SetImvisible(id);
            }
            if (result)
            {
                return "2";
               // return "All Course Successfully Unassigned";
            }
            else
            {
                return "3";
               // return "Error While Unassigning Courses";
            }
        }
    }
}