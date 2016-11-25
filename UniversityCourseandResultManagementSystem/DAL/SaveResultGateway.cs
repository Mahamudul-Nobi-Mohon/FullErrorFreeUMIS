using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.DAL
{
    public class SaveResultGateway:CommonGateway
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
        public List<Grade> GetGradeDropdownList()
        {
            List<Grade> gradeList = new List<Grade>();
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query = "select * from Grade;";
                Command = new SqlCommand(query, Connection);
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Grade grade = new Grade();
                        grade.ID = Convert.ToInt32(Reader["ID"].ToString());
                        grade.Name = Reader["Name"].ToString();
                        gradeList.Add(grade);
                    }
                }
                Reader.Close();
                Connection.Close();
            }
            return gradeList;
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
        public List<int> GetCourseIDList(int id)
        {
            List<int> courseIDList = new List<int>();
            GenarateConnection();
            using (Connection)
            {
                string query = "select * from EnrollInACourse where StudentID = @Id ;";
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
                        int ID = Convert.ToInt32(Reader["CourseID"].ToString());
                        courseIDList.Add(ID);
                    }
                }
                Reader.Close();
                Connection.Close();
            }
            return courseIDList;
        }

        public string GetCourseName(int id)
        {
            string name = "";
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
                        name = Reader["Name"].ToString();
                    }
                }
                Reader.Close();
                Connection.Close();
            }
            return name;
        }
        public bool IsStudentCourseResultExist(Result aresult)
        {

            GenarateConnection();
            string query = "SELECT * FROM Result WHERE CourseID =@CourseID and StudentID=@StudentID;";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@StudentID", SqlDbType.VarChar);
            Command.Parameters["@StudentID"].Value = aresult.ID;
            Command.Parameters.Add("@CourseID", SqlDbType.VarChar);
            Command.Parameters["@CourseID"].Value = aresult.CoursesID;
            Connection.Open();
            Reader = Command.ExecuteReader();

            bool result = Reader.HasRows;
            Connection.Close();
            return result;
        }
        public bool SetStudentResult(Result result)
        {
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query = "insert into Result(StudentID,CourseID,GradeID) values (@StudentID,@CourseID,@GradeID);";

                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@StudentID", SqlDbType.Int);
                Command.Parameters["@StudentID"].Value = result.ID;
                Command.Parameters.Add("@CourseID", SqlDbType.Int);
                Command.Parameters["@CourseID"].Value = result.CoursesID;
                Command.Parameters.Add("@GradeID", SqlDbType.Int);
                Command.Parameters["@GradeID"].Value = result.Grade;

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