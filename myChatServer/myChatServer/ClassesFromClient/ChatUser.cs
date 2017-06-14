using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myChatServer.ClassesFromClient
{
    public class ChatUser
    {
        public int id { get; private set; }
        public string username { get; private set; }
        public DateTime lastLogMsg { get; set; }
        public ChatUser(int id, string username)
        {
            this.id = id;
            this.username = username;
            this.lastLogMsg = DateTime.Now;

        }
    }
}