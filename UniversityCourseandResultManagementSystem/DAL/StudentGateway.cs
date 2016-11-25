using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.DAL
{
    public class StudentGateway:CommonGateway
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
                Connection.Close();
            }
            return departmentList;
        }
        public bool IsEmailExist(string email)
        {
            GenarateConnection();
            string query = "SELECT * FROM Student WHERE Email =@Email";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@Email", SqlDbType.VarChar);
            Command.Parameters["@Email"].Value = email;
            Connection.Open();
            Reader = Command.ExecuteReader();

            bool result = Reader.HasRows;
            Connection.Close();
            return result;
        }
        public int GetRegistrationNumber(string partialRegistrationNo)
        {
            GenarateConnection();
            string query = "SELECT * FROM Student WHERE  RegistrationNo like '%' + @RegistrationNo +'%'";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@RegistrationNo", SqlDbType.VarChar);
            Command.Parameters["@RegistrationNo"].Value = partialRegistrationNo;

            Connection.Open();
            Reader = Command.ExecuteReader();
            int regNo = 1;
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    regNo++;
                }
            }
            Connection.Close();
            return regNo;
        }

        public bool SetStudentInformation(Student student, string registrationNo)
        {
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query =
                    "insert into Student(Name,Email,ContactNumber,Date,Address,Department,RegistrationNo) values (@Name,@Email,@ContactNo,@Date,@Address,@Department,@RegistrationNo);";

                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@Name", SqlDbType.VarChar);
                Command.Parameters["@Name"].Value = student.Name;
                Command.Parameters.Add("@Email", SqlDbType.VarChar);
                Command.Parameters["@Email"].Value = student.Email;
                Command.Parameters.Add("@ContactNo", SqlDbType.VarChar);
                Command.Parameters["@ContactNo"].Value = student.ContactNo;
                Command.Parameters.Add("@Date", SqlDbType.VarChar);
                Command.Parameters["@Date"].Value = student.Date;
                Command.Parameters.Add("@Address", SqlDbType.VarChar);
                Command.Parameters["@Address"].Value = student.Address;
                Command.Parameters.Add("@Department", SqlDbType.VarChar);
                Command.Parameters["@Department"].Value = student.Department;
                Command.Parameters.Add("@RegistrationNo", SqlDbType.VarChar);
                Command.Parameters["@RegistrationNo"].Value = registrationNo;

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