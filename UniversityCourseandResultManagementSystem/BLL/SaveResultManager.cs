using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.DAL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.BLL
{
    public class SaveResultManager
    {
        SaveResultGateway saveResultGateway = new SaveResultGateway();

        public List<StudentEnroll> GetStudentDropdownList()
        {
            return saveResultGateway.GetStudentDropdownList();
        }

        public List<Grade> GetGradeDropdownList()
        {
            return saveResultGateway.GetGradeDropdownList();
        }

        public Student GetStudentInformation(int id)
        {
            Student student = saveResultGateway.GetStudentInformation(id);
            student.Department = GetDepartmentName(student.Department);
            return student;
        }

        public string GetDepartmentName(string code)
        {
            return saveResultGateway.GetDepartmentName(code);
        }

        public List<Course> GetCourseDropdownList(int id)
        {
            List<int> courseIDList = GetCourseIDList(id);
            List<Course> courseList=new List<Course>();           
            foreach (int courseID in courseIDList)
            {
                Course course = new Course();
                course.ID = courseID;
                course.Name = GetCourseName(courseID);
                courseList.Add(course);
            }
            return courseList;
        }

        public List<int> GetCourseIDList(int id)
        {
            return saveResultGateway.GetCourseIDList(id);
        }

        public string GetCourseName(int id)
        {
            return saveResultGateway.GetCourseName(id);
        }
        public bool IsStudentCourseResultExist(Result result)
        {
            return saveResultGateway.IsStudentCourseResultExist(result);
        }
        public string SetStudentResult(Result result)
        {
            string info = "";
            if (IsStudentCourseResultExist(result))
            {
                info = "1";
               // info = "Student result for the corresponding subject already Exist.";
            }
            else if (saveResultGateway.SetStudentResult(result))
            {
                info = "2";
                //info = "Student result to the corresponding subject has been successfully saved";
            }
            else
            {
                info = "3";
               // info = "Error While Entering data into database";
            }
            return info;
        }
    }
}