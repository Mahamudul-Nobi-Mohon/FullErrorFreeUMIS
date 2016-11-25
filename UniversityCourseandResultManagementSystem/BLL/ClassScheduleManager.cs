using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.DAL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.BLL
{
    public class ClassScheduleManager
    {
        ClassScheduleGateway classScheduleGateway=new ClassScheduleGateway();

        public List<Department> GetDepartmentDropdownList()
        {
            return classScheduleGateway.GetDepartmentDropdownList();
        }

        public List<ClassSchedule> GetCourseInformation(int id)
        {
            string code = GetDepartmentCode(id);
            List<ClassSchedule> classSchedules = classScheduleGateway.GetCourseInformation(code);
            foreach (ClassSchedule classSchedule in classSchedules)
            {
                string scheduleInfo = GetScheduleinfo(classSchedule.CourseID);
                if (scheduleInfo.Equals(""))
                {
                    scheduleInfo = "No Class room has been assaign for this Course yet";
                }
                classSchedule.SchuduleInfo = scheduleInfo;

            }
            return classSchedules;
        }

        public string GetDepartmentCode(int id)
        {
            return classScheduleGateway.GetDepartmentCode(id);
        }

        public string GetScheduleinfo(int id)
        {
            return classScheduleGateway.GetScheduleinfo(id);
        }
    }
}