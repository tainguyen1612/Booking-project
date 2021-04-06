using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Controllers.Api.Pojo
{
    public class RoomTypePojo
    {
        public int RoomTypeID;
        public String Description;
        public String[] ImgUrl;
        public Nullable<double> Price;

        public RoomTypePojo(int roomTypeID, string description, string[] imgUrl, double? price)
        {
            RoomTypeID = roomTypeID;
            Description = description;
            ImgUrl = imgUrl;
            Price = price;
        }
    }
}