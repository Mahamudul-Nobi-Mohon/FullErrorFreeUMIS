using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.DAL
{
    public class EnrollCourseGateway:CommonGateway
    {
        public List<StudentEnroll> GetStudentDropdownList()
        {
            List<StudentEnroll> studentList = new List<StudentEnroll>();
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query = "select * from Student;";
                Command = new SqlCommand(query, Connection);
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        StudentEnroll student = new StudentEnroll();
                        student.ID = Convert.ToInt32(Reader["ID"].ToString());
                        student.RegistrationNo = Reader["RegistrationNo"].ToString();
                        studentList.Add(student);
                    }
                }
                Reader.Close();
                Connection.Close();
            }
            return studentList;
        }

        public Student GetStudentInformation(int id)
        {
            Student student = new Student();
            GenarateConnection();
            using (Connection)
            {
                string querys = "select * from Student where ID =@Id ;";
                Command = new SqlCommand(querys, Connection);
                Command.Parameters.Clear();
                Connection.Open();
                Command.Parameters.Add("@Id", SqlDbType.Int);
                Command.Parameters["@Id"].Value = id;

                Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {                        
                        student.Name = Reader["Name"].ToString();
                        student.Email = Reader["Email"].ToString();
                        student.Department = Reader["Department"].ToString();
                    }
                }
                Reader.Close();
                Connection.Close();
            }
            return student;
        }
        public bool IsStudentCourseExist(Enroll enroll)
        {
            bool result = false;
            GenarateConnection();
            using (Connection)
            {
                string querys = "select * from EnrollInACourse where StudentID =@StudentId and CourseID=@CourseID ;";
                Command = new SqlCommand(querys, Connection);
                Command.Parameters.Clear();
                Connection.Open();
                Command.Parameters.Add("@StudentId", SqlDbType.Int);
                Command.Parameters["@StudentId"].Value = enroll.ID;
                Command.Parameters.Add("@CourseID", SqlDbType.Int);
                Command.Parameters["@CourseID"].Value = enroll.CourseIDs;

                Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        result = true;
                    }
                }
                Reader.Close();
                Connection.Close();
            }
            return result;
        }
        public string GetDepartmentName(string code)
        {
            string name = "";
            GenarateConnection();
            using (Connection)
            {
                string querys = "select * from Department where Code = '" + code + "' ;";
                Command = new SqlCommand(querys, Connection);
                Connection.Open();

                Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        name = Reader["Name"].ToString();
                    }
                }
                Reader.Close();
                Connection.Close();
            }
            return name;
        }
        public List<Course> GetCourseDropdownList(string code)
        {
            List<Course> courseList = new List<Course>();
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query = "select * from Course where Department = '" + code + "';";
                Command = new SqlCommand(query, Connection);
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Course course = new Course();
                        course.ID = Convert.ToInt32(Reader["ID"].ToString());
                        course.Name = Reader["Name"].ToString();
                        courseList.Add(course);
                    }
                }
                Reader.Close();
                Connection.Close();
            }
            return courseList;
        }

        public bool SetEnrollStudent(Enroll enroll)
        {
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query ="insert into EnrollInACourse(StudentID,CourseID,Date) values (@StudentID,@CourseID,@Date);";

                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@StudentID", SqlDbType.Int);
                Command.Parameters["@StudentID"].Value = enroll.ID;
                Command.Parameters.Add("@CourseID", SqlDbType.Int);
                Command.Parameters["@CourseID"].Value = enroll.CourseIDs;
                Command.Parameters.Add("@Date", SqlDbType.VarChar);
                Command.Parameters["@Date"].Value = enroll.Date;

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