using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.DAL;
using UniversityCourseandResultManagementSystem.Models;

namespace UniversityCourseandResultManagementSystem.BLL
{
    public class AllocateRoomManager
    {
        AllocateRoomGateway allocateRoomGateway=new AllocateRoomGateway();

        public int SetRoomAllocationInformation(AllocateRoom allocateRoom)
        {
            int fromHour = allocateRoom.FromTime.Hour;
            int fromMinute = allocateRoom.FromTime.Minute;
            double fromTimeForDB = Convert.ToDouble(fromHour + "." + fromMinute);

            int toHour = allocateRoom.ToTime.Hour;
            int toMinute = allocateRoom.ToTime.Minute;          
            double toTimeForDB = Convert.ToDouble(toHour + "." + toMinute);

            string timeForView = GetTimeForView(allocateRoom);
            

            int result = 0;

            if (allocateRoomGateway.IsTimeExist(fromTimeForDB,toTimeForDB,allocateRoom.Day ,allocateRoom.RoomNo))
            {
                result = 1;
            }
            else if (allocateRoomGateway.SetRoomAllocationInformation(allocateRoom,fromTimeForDB,toTimeForDB,timeForView))
            {
                result = 2;
                //result = "The Room Allocation Information Successfully saved";
            }
            else
            {
                result = 3;
                //result = "There is some error while entering data into database";
            }

            return result;
        }

        public string GetTimeForView(AllocateRoom allocateRoom)
        {
            int fromHour = allocateRoom.FromTime.Hour;
            string fromHourString = "";
            if (fromHour > 12)
            {
                fromHour = fromHour - 12;                
            }
            if (fromHour < 10)
            {
                fromHourString = "0" + fromHour;
            }
            else
            {
                fromHourString = "" + fromHour;
            }


            int fromMinute = allocateRoom.FromTime.Minute;
            string fromMinuteString = "";
            if (fromMinute == 0)
            {
                fromMinuteString = "00";
            }
            else if (fromMinute < 10)
            {
                fromMinuteString = fromMinute + "0";
            }
            else
            {
                fromMinuteString = fromMinute + "";
            }
            string fromTt = allocateRoom.FromTime.ToString("tt", CultureInfo.InvariantCulture);
            if (fromTt.Equals("AM") && fromHour == 0)
            {
                fromHourString = "12";
            }



            int toHour = allocateRoom.ToTime.Hour;
            string toHourString = "";
            if (toHour > 12)
            {
                toHour = toHour - 12;                
            }
            if (toHour < 10)
            {
                toHourString = "0" + toHour;
            }
            else
            {
                toHourString = "" + toHour;
            }


            int toMinute = allocateRoom.ToTime.Minute;
            string toMinuteString = "";
            if (toMinute == 0)
            {
                toMinuteString = "00";
            }
            else if (toMinute < 10)
            {
                toMinuteString = fromMinute + "0";
            }
            else
            {
                toMinuteString = fromMinute + "";
            }
            string ToTt = allocateRoom.ToTime.ToString("tt", CultureInfo.InvariantCulture);
            if (ToTt.Equals("AM") && toHour == 0)
            {
                toHourString = "12";
            }


            string getRoomName = allocateRoomGateway.GetRoomName(allocateRoom.RoomNo);
            string getDayName = allocateRoomGateway.GetDayName(allocateRoom.Day);

            string fullTimeResult = "R. No : " + getRoomName + " , " + getDayName + " , " + fromHourString + ":" +
                                    fromMinuteString + " " + fromTt + " - " + toHourString + " : " + toMinuteString + " " + ToTt;

            return fullTimeResult;
        }

        public List<Department> GetDepartmentDropdownList()
        {
            return allocateRoomGateway.GetDepartmentDropdownList();
        }

        public List<Course> GetCourseDropdownList(int id)
        {
            return allocateRoomGateway.GetCourseDropdownList(id);
        }

        public List<Room> GetRoomDropdownList()
        {
            return allocateRoomGateway.GetRoomDropdownList();
        }

        public List<Day> GetDayDropdownList()
        {
            return allocateRoomGateway.GetDayDropdownList();
        }
        public int GetYear(DateTime date)
        {
            int year = date.Year;
            return year;
        }
    }
}