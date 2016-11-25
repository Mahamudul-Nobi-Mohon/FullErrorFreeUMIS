using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.DAL
{
    public class DepartmentGateway:CommonGateway
    {
        public bool IsCodeExist(string code)
        {
            GenarateConnection();
            string query = "SELECT * FROM Department WHERE Code =@Code";
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
            string query = "SELECT * FROM Department WHERE Name =@Name";
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
        public bool SetDepartmentInformation(Department department)
        {
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query = "insert into Department(Code,Name) values (@Code,@Name);";

                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@Code", SqlDbType.VarChar);
                Command.Parameters["@Code"].Value = department.Code;
                Command.Parameters.Add("@Name", SqlDbType.VarChar);
                Command.Parameters["@Name"].Value = department.Name;

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

        public List<Department> GetAllDepartments()
        {
            GenarateConnection();
            string query = "SELECT * FROM Department;";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.Clear();
            Connection.Open();
            List<Department> departments = new List<Department>();
            Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    Department department = new Department();
                    department.Code = Reader["Code"].ToString();
                    department.Name = Reader["Name"].ToString();
                    departments.Add(department);
                }
                Reader.Close();
            }
            Connection.Close();

            return departments;
        }
    }
}