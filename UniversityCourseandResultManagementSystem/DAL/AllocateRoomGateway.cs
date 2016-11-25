using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.DAL
{
    public class AllocateRoomGateway:CommonGateway
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
                        department.ID = Convert.ToInt32(Reader["ID"].ToString());
                        department.Name = Reader["Name"].ToString();
                        departmentList.Add(department);
                    }
                }
                Reader.Close();
                Connection.Close();
            }
            return departmentList;
        }
        public string GetRoomName(int id)
        {
            string name = "";
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query = "select * from Room  where ID =@ID;";
                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@ID", SqlDbType.Int);
                Command.Parameters["@ID"].Value = id;;

                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {

                    while (Reader.Read())
                    {
                        name = Reader["Name"].ToString();
                    }
                }
                Connection.Close();
            }
            return name;
        }
        public string GetDayName(int id)
        {
            string day = "";
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query = "select * from Day  where ID =@ID;";
                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@ID", SqlDbType.Int);
                Command.Parameters["@ID"].Value = id; ;

                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {

                    while (Reader.Read())
                    {
                        string days = Reader["Name"].ToString();
                        day = days.Substring(0, 3);
                    }
                }
                Connection.Close();
            }
            return day;
        }

        public List<Course> GetCourseDropdownList(int id)
        {
            string code = "";
            GenarateConnection();
            using (Connection)
            {               
                string query = "select * from Department where ID =@ID;";
                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();
                Connection.Open();
                Command.Parameters.Add("@ID", SqlDbType.VarChar);
                Command.Parameters["@ID"].Value = id;
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        code = Reader["Code"].ToString();

                    }
                }
                Reader.Close();
                Connection.Close();
            }

            List<Course> courseList = new List<Course>();
            GenarateConnection();
            using (Connection)
            {
                string query = "select * from Course where Department =@Department ;";
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
        public List<Room> GetRoomDropdownList()
        {
            List<Room> roomList = new List<Room>();
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();

                string query = "select * from Room;";
                Command = new SqlCommand(query, Connection);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    Room room = new Room();
                    room.ID = Convert.ToInt32(Reader["ID"].ToString());
                    room.Name = Reader["Name"].ToString();
                    roomList.Add(room);
                }
                Connection.Close();
            }
            return roomList;
        }
        public List<Day> GetDayDropdownList()
        {
            List<Day> dayList = new List<Day>();
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();

                string query = "select * from Day;";
                Command = new SqlCommand(query, Connection);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    Day day = new Day();
                    day.ID = Convert.ToInt32(Reader["ID"].ToString());
                    day.Name = Reader["Name"].ToString();
                    dayList.Add(day);
                }
                Connection.Close();
            }
            return dayList;
        }

        public bool IsTimeExist(double fromTimeForDB, double toTimeForDB,int day,int roomNumber )
        {
            bool result = false;
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query = "select * from AllocateRoom  where Day =@Day and RoomNumber =@roomNumber and Visible = @Visible;";
                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@Day", SqlDbType.Int);
                Command.Parameters["@Day"].Value = day;
                Command.Parameters.Add("@roomNumber", SqlDbType.Int);
                Command.Parameters["@roomNumber"].Value = roomNumber;
                Command.Parameters.Add("@Visible", SqlDbType.Int);
                Command.Parameters["@Visible"].Value = 1;

                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {

                    while (Reader.Read())
                    {
                        double fromTime = Convert.ToDouble(Reader["FromTime"].ToString());
                        double toTime = Convert.ToDouble(Reader["ToTime"].ToString());
                        if (fromTimeForDB < fromTime && fromTime < toTimeForDB)
                        {
                            result = true;
                        }
                        else if (fromTimeForDB < toTime && toTime < toTimeForDB)
                        {
                            result = true;
                        }
                        else if (fromTimeForDB.Equals(fromTime))
                        {
                            result = true;
                        }
                        else if (toTimeForDB.Equals(toTime))
                        {
                            result = true;
                        }
                        else if (fromTimeForDB < fromTime && toTime < toTimeForDB)
                        {
                            result = true;
                        }
                        else if (fromTimeForDB > fromTime && toTime > toTimeForDB)
                        {
                            result = true;
                        }
                    }
                }
                Connection.Close();
            }
            return result;
        }
        public bool SetRoomAllocationInformation(AllocateRoom allocateRoom, double fromTimeForDB, double toTimeForDB, string timeForView)
        {
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query =
                    "insert into AllocateRoom (Department,Course,RoomNumber,Day,FromTime,ToTime,TimeForView,Visible) values (@Department,@Course,@RoomNo,@Day,@FromTime,@ToTime,@TimeForView,@Visible);";

                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@Department", SqlDbType.Int);
                Command.Parameters["@Department"].Value = allocateRoom.Department;
                Command.Parameters.Add("@Course", SqlDbType.Int);
                Command.Parameters["@Course"].Value = allocateRoom.Course;
                Command.Parameters.Add("@RoomNo", SqlDbType.Int);
                Command.Parameters["@RoomNo"].Value = allocateRoom.RoomNo;
                Command.Parameters.Add("@Day", SqlDbType.Int);
                Command.Parameters["@Day"].Value = allocateRoom.Day;
                Command.Parameters.Add("@FromTime", SqlDbType.Float);
                Command.Parameters["@FromTime"].Value = fromTimeForDB;
                Command.Parameters.Add("@ToTime", SqlDbType.Float);
                Command.Parameters["@ToTime"].Value = toTimeForDB;
                Command.Parameters.Add("@TimeForView", SqlDbType.VarChar);
                Command.Parameters["@TimeForView"].Value = timeForView;
                Command.Parameters.Add("@Visible", SqlDbType.Int);
                Command.Parameters["@Visible"].Value = 1;
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