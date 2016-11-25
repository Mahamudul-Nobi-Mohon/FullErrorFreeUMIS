using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.DAL
{
    public class ViewResultGateway:CommonGateway
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
        public List<int> GetStudentEnrolledCourse(int id)
        {
            List<int> enrolledCourse=new List<int>();

            GenarateConnection();
            using (Connection)
            {
                string querys = "select * from EnrollInACourse where StudentID =@Id ;";
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
                        enrolledCourse.Add(Convert.ToInt32(Reader["CourseID"].ToString())); 

                    }
                }
                Reader.Close();
                Connection.Close();
            }
            return enrolledCourse;
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
        public int GetGradeID(int studentId,int courseID)
        {
            int grade = 0;
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query = "select * from Result where StudentID = @StudentID and CourseID =@CourseID ;";

                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@StudentID", SqlDbType.Int);
                Command.Parameters["@StudentID"].Value = studentId;
                Command.Parameters.Add("@CourseID", SqlDbType.Int);
                Command.Parameters["@CourseID"].Value = courseID;

                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {

                        grade = Convert.ToInt32(Reader["GradeID"].ToString());

                    }
                }
                Reader.Close();
                Connection.Close();
            }
            return grade;
        }
        public Course GetCourseCodeName(int id)
        {
            Course course = new Course();
            GenarateConnection();
            using (Connection)
            {
                string query = "select * from Course where ID = @Id;";
                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();
                Connection.Open();
                Command.Parameters.Add("@Id", SqlDbType.Int);
                Command.Parameters["@Id"].Value = id;

                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        course.Code = Reader["Code"].ToString();
                        course.Name = Reader["Name"].ToString();
                    }
                }
                Reader.Close();
                Connection.Close();
            }
            return course;
        }
        public string GetGradeName(int id)
        {
            string name = "";
            GenarateConnection();
            using (Connection)
            {
                string query = "select * from Grade where ID = @Id;";
                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();
                Connection.Open();
                Command.Parameters.Add("@Id", SqlDbType.Int);
                Command.Parameters["@Id"].Value = id;

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
            if (name.Equals(""))
            {
                name = "Not Graded Yet";
            }
            return name;
        }
    }
}