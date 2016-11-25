using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace UniversityCourseandResultManagementSystem.Models
{
    public class AllocateRoom
    {
        public int Department { get; set; }
        public int Course { get; set; }
        public int RoomNo { get; set; }
        public int Day { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
    }
}