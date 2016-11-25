using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.DAL
{
    public class ClassScheduleGateway:CommonGateway
    {
        public List<ClassSchedule> GetCourseInformation(string code)
        {
            List<ClassSchedule> classScheduleList = new List<ClassSchedule>();
            GenarateConnection();
            using (Connection)
            {
                string query = "select * from Course where Department = @Department ;";
                Command = new SqlCommand(query, Connection);
                Connection.Open();
                Command.Parameters.Add("@Department", SqlDbType.VarChar);
                Command.Parameters["@Department"].Value = code;


                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        ClassSchedule classSchedule = new ClassSchedule();
                        classSchedule.CourseID = Convert.ToInt32(Reader["ID"].ToString());
                        classSchedule.CourseCode = Reader["Code"].ToString();
                        classSchedule.CourseName = Reader["Name"].ToString();
                        classScheduleList.Add(classSchedule);
                    }
                }
                Connection.Close();
            }
            return classScheduleList;
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
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Department department = new Department();
                        department.ID = Convert.ToInt32(Reader["ID"].ToString());
                        department.Name = Reader["Name"].ToString();
                        departmentList.Add(department);
                    }
                }
                Connection.Close();
            }
            return departmentList;
        }
        public string GetDepartmentCode(int id)
        {
            string code = "";
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();

                string query = "select * from Department where ID =@ID";
                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.Add("@ID", SqlDbType.Int);
                Command.Parameters["@ID"].Value = id;

                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        code = Reader["Code"].ToString();

                    }
                }
                Connection.Close();
            }
            return code;
        }
        public string GetScheduleinfo(int id)
        {
            string info = "";
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();

                string query = "select * from AllocateRoom where Course =@ID and Visible = @Visible";
                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();
                Command.Parameters.Add("@ID", SqlDbType.Int);
                Command.Parameters["@ID"].Value = id;
                Command.Parameters.Add("@Visible", SqlDbType.VarChar);
                Command.Parameters["@Visible"].Value = 1;

                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        info += Reader["TimeForView"].ToString();
                        info += " ; ";

                    }
                }
                Connection.Close();
            }
            return info;
        }
    }
}