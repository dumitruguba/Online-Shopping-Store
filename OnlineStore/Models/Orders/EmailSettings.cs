using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models.Orders
{
    public class EmailSettings
    {
        public string MailToAddress = "dumitru.guba@gmail.com";
        public string MailFromAddress = "dumitru.guba@gmail.com";
        public bool UseSsl = true;
        public string Username = "dumitru.guba@gmail.com";
        public string Password = "kzyijcwrlovoveuv"; 
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }
}