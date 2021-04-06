using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Controllers.Api.Pojo
{
    public class RoomPojo
    {
        public int RoomID;
        public String RoomNumber;
        public String Description;

        public RoomPojo(int roomID, string roomNumber, string description)
        {
            RoomID = roomID;
            RoomNumber = roomNumber;
            Description = description;
        }
    }
}