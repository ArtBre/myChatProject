using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myChatServer.ClassesFromClient
{
    public class LogInMessage
    {
        public string username { get; private set; }
        public string password { get; private set; }
        public string newPassword { get; private set; }
        //public LogInMessage(string username, string password)
        //{
        //    this.username = username;
        //    this.password = password;
        //}
        public LogInMessage(string username, string password, string newPassword)
        {
            this.username = username;
            this.password = password;
            this.newPassword = newPassword;
        }
    }
}