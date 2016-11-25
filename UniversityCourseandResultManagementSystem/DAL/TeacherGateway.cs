using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.DAL
{
    public class TeacherGateway : CommonGateway
    {
        public List<Designation> GetDesignationDropdownList()
        {
            List<Designation> designationList = new List<Designation>();
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();

                string query = "select * from Designation;";
                Command = new SqlCommand(query, Connection);
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Designation designation = new Designation();
                        designation.ID = Convert.ToInt32(Reader["ID"].ToString());
                        designation.Name = Reader["Name"].ToString();
                        designationList.Add(designation);
                    }
                }
                Connection.Close();
            }
            return designationList;
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
            string query = "SELECT * FROM Teacher WHERE Email =@Email";
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
        public bool IsContactNumberExist(string contactNumber)
        {
            GenarateConnection();
            string query = "SELECT * FROM Teacher WHERE ContactNumber =@ContactNumber";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();

            Command.Parameters.Add("@ContactNumber", SqlDbType.VarChar);
            Command.Parameters["@ContactNumber"].Value = contactNumber;
            Connection.Open();
            Reader = Command.ExecuteReader();

            bool result = Reader.HasRows;
            Connection.Close();
            return result;
        }

        public bool SetTeacherInformation(Teacher teacher)
        {
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query =
                    "insert into Teacher(Name,Address,Email,ContactNumber,Designation,Department,CreditToBeTaken) values (@Name,@Address,@Email,@ContactNo,@Designation,@Department,@Credit);";

                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@Name", SqlDbType.VarChar);
                Command.Parameters["@Name"].Value = teacher.Name;
                Command.Parameters.Add("@Address", SqlDbType.VarChar);
                Command.Parameters["@Address"].Value = teacher.Address;
                Command.Parameters.Add("@Email", SqlDbType.VarChar);
                Command.Parameters["@Email"].Value = teacher.Email;
                Command.Parameters.Add("@ContactNo", SqlDbType.VarChar);
                Command.Parameters["@ContactNo"].Value = teacher.ContactNo;
                Command.Parameters.Add("@Designation", SqlDbType.Decimal);
                Command.Parameters["@Designation"].Value = teacher.Designation;
                Command.Parameters.Add("@Department", SqlDbType.VarChar);
                Command.Parameters["@Department"].Value = teacher.Department;
                Command.Parameters.Add("@Credit", SqlDbType.Decimal);
                Command.Parameters["@Credit"].Value = teacher.CreditToBeTaken;
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