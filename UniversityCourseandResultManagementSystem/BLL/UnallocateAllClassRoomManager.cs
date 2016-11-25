using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseandResultManagementSystem.DAL;

namespace UniversityCourseandResultManagementSystem.BLL
{
    public class UnallocateAllClassRoomManager
    {
        UnallocateAllClassRoomGateway unallocateAllClassRoomGateway=new UnallocateAllClassRoomGateway();
        public List<int> GetClassAllocateIdList()
        {
            return unallocateAllClassRoomGateway.GetClassAllocateIdList();
        }

        public bool SetImvisible(int id)
        {
            return unallocateAllClassRoomGateway.SetImvisible(id);
        }

        public string UnallocateAllClassRoom()
        {
            bool result = false;
            List<int> classAllocateID = GetClassAllocateIdList();
            foreach (int id in classAllocateID)
            {
                result = SetImvisible(id);
            }
            if (result)
            {
                return "2";
                //return "All Class Room Successfully Unallocated";
            }
            else
            {
                return "3";
              //  return "Error While Unallocating Class Room";
            }
        }
    }
}