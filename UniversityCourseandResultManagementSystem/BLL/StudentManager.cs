using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.DAL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.BLL
{
    public class StudentManager
    {
        StudentGateway studentGateway=new StudentGateway();

        public List<Department> GetDepartmentDropdownList()
        {
            return studentGateway.GetDepartmentDropdownList();
        }


        public bool IsEmailExist(string email)
        {
            return studentGateway.IsEmailExist(email);
        }

        public string SetStudentInformation(Student student)
        {
            int year = student.Date.Year;
            string partialRegistrationNo=GetPartialRegistrationNo(student.Department, year);
            int regNumber = studentGateway.GetRegistrationNumber(partialRegistrationNo);
            string registrationNumber=GetFullRegistrationNo(student.Department, year, regNumber);

            if (IsEmailExist(student.Email))
            {
                return "1";
                //return "The Student Email Already Exist";
            }
            else if (studentGateway.SetStudentInformation(student, registrationNumber))
            {
                return "The Student Information Saved Successfully. And the Student Registration Number is " + registrationNumber;
            }
            else
            {
                return "3";
               // return "Error While Entering data into database";
            }
        }

        public string GetPartialRegistrationNo(string department, int year)
        {
            return department + "-" + year;
        }
        public string GetFullRegistrationNo(string department, int year,int regNumber)
        {
            string regNo;
            if (regNumber < 10) { 
            regNo = department + "-" + year + "-00" + regNumber;
            }
            else if (regNumber>=10 && regNumber < 100)
            {
                regNo = department + "-" + year + "-0" + regNumber;
            }
            else
            {
                regNo = department + "-" + year + "-" + regNumber;
            }
            return regNo;
        }

        public int GetYear(DateTime date)
        {
            int year = date.Year;
            return year;
        }

    }
}