using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.DAL
{
    public class CourseGateway:CommonGateway
    {
        public bool IsCodeExist(string code)
        {
            GenarateConnection();
            string query = "SELECT * FROM Course WHERE Code =@Code";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@Code", SqlDbType.VarChar);
            Command.Parameters["@Code"].Value = code;
            Connection.Open();
            Reader = Command.ExecuteReader();

            bool result = Reader.HasRows;
            Connection.Close();
            return result;
        }
        public bool IsNameExist(string name)
        {
            GenarateConnection();
            string query = "SELECT * FROM Course WHERE Name =@Name";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@Name", SqlDbType.VarChar);
            Command.Parameters["@Name"].Value = name;
            Connection.Open();
            Reader = Command.ExecuteReader();

            bool result = Reader.HasRows;
            Connection.Close();
            return result;
        }

        public List<Department> GetDepartmentDropdownList()
        {
            List<Department> departmentList = new List<Department>();
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();

                string query = "select * from Department;";
                Command = new SqlCommand(query, Connection);
                Reader = Command.ExecuteReader();
                if (Reader.HasRows) { 
                while (Reader.Read())
                {
                    Department department=new Department();
                    department.Code = Reader["Code"].ToString();
                    department.Name = Reader["Name"].ToString();
                    departmentList.Add(department);
                }
                }
                Connection.Close();
            }
            return departmentList;
        }
        public List<Semester> GetSemesterDropdownList()
        {
            List<Semester> semesterList = new List<Semester>();
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();

                string query = "select * from Semester;";
                Command = new SqlCommand(query, Connection);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    Semester semester = new Semester();
                    semester.ID = Convert.ToInt32(Reader["ID"].ToString());
                    semester.Name = Reader["Name"].ToString();
                    semesterList.Add(semester);
                }
                Connection.Close();
            }
            return semesterList;
        }
        public bool SetCourseInformation(Course course)
        {
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query =
                    "insert into Course(Code,Name,Credit,Description,Department,Semester) values (@Code,@Name,@Credit,@Description,@Department,@Semester);";

                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@Code", SqlDbType.VarChar);
                Command.Parameters["@Code"].Value = course.Code;
                Command.Parameters.Add("@Name", SqlDbType.VarChar);
                Command.Parameters["@Name"].Value = course.Name;
                Command.Parameters.Add("@Credit", SqlDbType.Decimal);
                Command.Parameters["@Credit"].Value = course.Credit;
                Command.Parameters.Add("@Description", SqlDbType.VarChar);
                Command.Parameters["@Description"].Value = course.Description;
                Command.Parameters.Add("@Department", SqlDbType.VarChar);
                Command.Parameters["@Department"].Value = course.Department;
                Command.Parameters.Add("@Semester", SqlDbType.Decimal);
                Command.Parameters["@Semester"].Value = course.Semester;
                try
                {
                    Command.ExecuteNonQuery();
                    Connection.Close();
                    return true;
                }
                catch (Exception)
                {
                    throw new Exception("Error While Entering data into database");
                }
            }
        }


    }
}