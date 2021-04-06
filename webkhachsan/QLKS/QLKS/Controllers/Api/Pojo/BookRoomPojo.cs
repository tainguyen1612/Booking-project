using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Controllers.Api.Pojo
{
    public class BookRoomPojo
    {
        public String MessID;
        public String FullName;
        public String IDCard;
        public String PhoneNumber;
        public String startDate;
        public String endDate;
        public int roomID;
        public int status;

        public BookRoomPojo(string messID, string fullName, string iDCard, string phoneNumber, string startDate, string endDate, int roomID, int status)
        {
            MessID = messID;
            FullName = fullName;
            IDCard = iDCard;
            PhoneNumber = phoneNumber;
            this.startDate = startDate;
            this.endDate = endDate;
            this.roomID = roomID;
            this.status = status;
        }
    }
}