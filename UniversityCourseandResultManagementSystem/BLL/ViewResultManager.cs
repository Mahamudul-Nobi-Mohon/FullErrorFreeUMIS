using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.DAL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.BLL
{
    public class ViewResultManager
    {
        ViewResultGateway viewResultGateway=new ViewResultGateway();

        public List<StudentEnroll> GetStudentDropdownList()
        {
            return viewResultGateway.GetStudentDropdownList();
        }
        public Student GetStudentInformation(int id)
        {
            Student student = viewResultGateway.GetStudentInformation(id);
            student.Department = GetDepartmentName(student.Department);
            return student;
        }
        public string GetDepartmentName(string code)
        {
            return viewResultGateway.GetDepartmentName(code);
        }

        public List<ResultForVIew> GetResultList(int studentId)
        {
            List<int> enrolledCourse = viewResultGateway.GetStudentEnrolledCourse(studentId);
            List<ResultForVIew> viewResultList = new List<ResultForVIew>();
            foreach (int courseID in enrolledCourse)
            {
                ResultForVIew viewResult = new ResultForVIew();
                viewResult.CourseCode = GetCourseCodeName(courseID).Code;
                viewResult.CourseName = GetCourseCodeName(courseID).Name;
                int gradeID = GetGradeID(studentId, courseID);
                viewResult.Grade = GetGradeName(gradeID);
                viewResultList.Add(viewResult);
            }
            return viewResultList;
        }

        public Course GetCourseCodeName(int id)
        {
            return viewResultGateway.GetCourseCodeName(id);
        }

        public int GetGradeID(int studentId, int courseID)
        {
            return viewResultGateway.GetGradeID(studentId, courseID);
        }

        public string GetGradeName(int id)
        {
            return viewResultGateway.GetGradeName(id);
        }
    }
}