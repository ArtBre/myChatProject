using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//My usings
using Chat04.Model;
using Chat04.Static_Classes;
namespace Chat04.Model
{
    class LogInMessage
    {
       public  string username { get; private set; }
       public string password { get; private set; }
       public string newPassword { get; private set; }
        public LogInMessage(string username,string password)
        {
            this.username = username;
            this.password = password;
        }
        public LogInMessage(string username, string password,string newPassword)
        {
            this.username = username;
            this.password = password;
            this.newPassword = newPassword;
        }

    }
}
