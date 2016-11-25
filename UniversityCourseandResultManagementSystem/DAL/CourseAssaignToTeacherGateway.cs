using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.DAL
{
    public class CourseAssaignToTeacherGateway:CommonGateway
    {
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
                        department.Code = Reader["Code"].ToString();
                        department.Name = Reader["Name"].ToString();
                        departmentList.Add(department);
                    }
                }
                Reader.Close();
                Connection.Close();
            }
            return departmentList;
        }

        public List<Teacher> GetTeacherDropdownList(string code)
        {
            List<Teacher> teacherList = new List<Teacher>();
            GenarateConnection();
            using (Connection)
            {
                string query = "select * from Teacher where Department = @Department ";
                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();
                Connection.Open();
                Command.Parameters.Add("@Department", SqlDbType.VarChar);
                Command.Parameters["@Department"].Value = code;
               

                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Teacher teacher = new Teacher();
                        teacher.ID = Convert.ToInt32(Reader["ID"].ToString());
                        teacher.Name = Reader["Name"].ToString();
                        teacher.CreditToBeTaken = Convert.ToInt32(Reader["CreditToBeTaken"]);
                        teacherList.Add(teacher);
                    }
                }
                Reader.Close();
                Connection.Close();
            }
            return teacherList;
        }
        public CourseAssaign GetCreditInformation(int id)
        {
            string name = "";
            GenarateConnection();
            using (Connection)
            {
                string querys = "select * from Teacher where ID =@Id ;";
                Command = new SqlCommand(querys, Connection);
                Command.Parameters.Clear();
                Connection.Open();
                Command.Parameters.Add("@Id", SqlDbType.Int);
                Command.Parameters["@Id"].Value = id;

                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    name = Reader["Name"].ToString();

                }
                Reader.Close();

                Connection.Close();
            }

            CourseAssaign courseAssaign = new CourseAssaign();
            GenarateConnection();
            using (Connection)
            {

                string query = "select * from CourseAssaign where Teacher =@Teacher and Visible = @Visible ;";
                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();
                Connection.Open();
                Command.Parameters.Add("@Teacher", SqlDbType.VarChar);
                Command.Parameters["@Teacher"].Value = name;
                Command.Parameters.Add("@Visible", SqlDbType.VarChar);
                Command.Parameters["@Visible"].Value = 1;

                
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        courseAssaign.CreditToBeTaken = Convert.ToDouble(Reader["CreditToBeTaken"].ToString());
                        courseAssaign.RemainingCredit = Convert.ToDouble(Reader["RemainingCredit"].ToString());

                    }
                    Reader.Close();

                }
                else
                {
                    Connection.Close();
                    string querys = "select * from Teacher where ID =@Id ;";
                    Command = new SqlCommand(querys, Connection);
                    Command.Parameters.Clear();
                    Connection.Open();
                    Command.Parameters.Add("@Id", SqlDbType.Int);
                    Command.Parameters["@Id"].Value = id;

                    Reader = Command.ExecuteReader();
                    if (Reader.HasRows) { 
                     while (Reader.Read())
                      {
                        courseAssaign.CreditToBeTaken = Convert.ToDouble(Reader["CreditToBeTaken"].ToString());
                        courseAssaign.RemainingCredit = Convert.ToDouble(Reader["CreditToBeTaken"].ToString());

                      }
                    }
                    Reader.Close();
                }
                Connection.Close();
            }
            return courseAssaign;
        }
        

        public List<Course> GetCourseDropdownList(string code)
        {
            List<Course> courseList = new List<Course>();
            GenarateConnection();
            using (Connection)
            {
                string query = "select * from Course where Department =@Department ;";
                Command = new SqlCommand(query, Connection);
                Connection.Open();
                Command.Parameters.Add("@Department", SqlDbType.VarChar);
                Command.Parameters["@Department"].Value = code;
                
               
                    Reader = Command.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        while (Reader.Read())
                        {
                            Course course = new Course();
                            course.Code = Reader["Code"].ToString();
                            course.Name = Reader["Name"].ToString();
                            courseList.Add(course);
                        }
                    }
                    Reader.Close();
                Connection.Close();
            }
            return courseList;
        }
        public Course GetCourseInformation(string code)
        {
            Course course = new Course();
            GenarateConnection();
            using (Connection)
            {
                string query = "select * from Course where Code =@Code ;";
                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();
                Connection.Open();
                Command.Parameters.Add("@Code", SqlDbType.VarChar);
                Command.Parameters["@Code"].Value = code;

                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        course.Code = Reader["Code"].ToString();
                        course.Name = Reader["Name"].ToString();
                        course.Credit = Convert.ToDouble(Reader["Credit"].ToString());

                    }  
                }
                    
               Reader.Close();
                
                
             Connection.Close();
            }
            return course;
        }
        public bool IsCourseExist(string code)
        {
            GenarateConnection();
            string query = "SELECT * FROM CourseAssaign WHERE CourseID =@Code and Visible = @Visible ;";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@Code", SqlDbType.VarChar);
            Command.Parameters["@Code"].Value = code;
            Command.Parameters.Add("@Visible", SqlDbType.Int);
            Command.Parameters["@Visible"].Value = 1;
            Connection.Open();
            Reader = Command.ExecuteReader();

            bool result = Reader.HasRows;
            Connection.Close();
            return result;
        }
        public bool SetCourseAssaignInformation(CourseAssaign courseAssaign)
        {
            string name = "";
            GenarateConnection();
            using (Connection)
            {
                string querys = "select * from Teacher where ID =@Id ;";
                Command = new SqlCommand(querys, Connection);
                Command.Parameters.Clear();
                Connection.Open();
                Command.Parameters.Add("@Id", SqlDbType.Int);
                Command.Parameters["@Id"].Value = courseAssaign.Teacher;

                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    name = Reader["Name"].ToString();

                }
                Reader.Close();

                Connection.Close();
            }

            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query =
                    "insert into CourseAssaign(Department,Teacher,CourseID,CourseName,Credit,CreditToBeTaken,RemainingCredit,Visible) values (@Department,@Teacher,@CourseID,@CourseName,@Credit,@CreditToBeTaken,@RemainingCredit,@Visible);";

                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@Department", SqlDbType.VarChar);
                Command.Parameters["@Department"].Value = courseAssaign.Department;
                Command.Parameters.Add("@Teacher", SqlDbType.VarChar);
                Command.Parameters["@Teacher"].Value = name;
                Command.Parameters.Add("@CourseID", SqlDbType.VarChar);
                Command.Parameters["@CourseID"].Value = courseAssaign.CourseID;
                Command.Parameters.Add("@CourseName", SqlDbType.VarChar);
                Command.Parameters["@CourseName"].Value = courseAssaign.Name;
                Command.Parameters.Add("@Credit", SqlDbType.Decimal);
                Command.Parameters["@Credit"].Value = courseAssaign.Credit;
                Command.Parameters.Add("@CreditToBeTaken", SqlDbType.Decimal);
                Command.Parameters["@CreditToBeTaken"].Value = courseAssaign.CreditToBeTaken;
                double remainingCredit = courseAssaign.RemainingCredit - courseAssaign.Credit;
                Command.Parameters.Add("@RemainingCredit", SqlDbType.Decimal);
                Command.Parameters["@RemainingCredit"].Value = remainingCredit;
                int visible = 1;
                Command.Parameters.Add("@Visible", SqlDbType.Decimal);
                Command.Parameters["@Visible"].Value = visible;

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