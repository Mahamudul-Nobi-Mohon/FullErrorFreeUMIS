using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagementSystem.DAL
{
    public class UnallocateAllClassRoomGateway:CommonGateway
    {
        public List<int> GetClassAllocateIdList()
        {
            List<int> courseIdList = new List<int>();
            GenarateConnection();
            using (Connection)
            {
                Connection.Open();

                string query = "select * from AllocateRoom;";
                Command = new SqlCommand(query, Connection);
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        courseIdList.Add(Convert.ToInt32(Reader["ID"].ToString()));
                    }
                }
                Connection.Close();
            }
            return courseIdList;
        }
        public bool SetImvisible(int id)
        {


            GenarateConnection();
            using (Connection)
            {
                Connection.Open();
                string query = "UPDATE AllocateRoom set Visible =@Visible where ID = @ID;";

                Command = new SqlCommand(query, Connection);
                Command.Parameters.Clear();

                Command.Parameters.Add("@ID", SqlDbType.Int);
                Command.Parameters["@ID"].Value = id;
                Command.Parameters.Add("@Visible", SqlDbType.Decimal);
                Command.Parameters["@Visible"].Value = 0;

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