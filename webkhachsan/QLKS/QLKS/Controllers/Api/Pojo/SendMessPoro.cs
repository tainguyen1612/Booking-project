using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Controllers.Api.Pojo
{
    public class SendMessPoro
    {
        public String MessID;
        public String FullName;
        public String IDCard;
        public String PhoneNumber;
        public String Email;
        public String Content;

        public SendMessPoro(string messID, string fullName, string iDCard, string phoneNumber, string email, string content)
        {
            MessID = messID;
            FullName = fullName;
            IDCard = iDCard;
            PhoneNumber = phoneNumber;
            Email = email;
            Content = content;
        }
    }
}