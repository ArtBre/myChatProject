using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myChatServer.ClassesFromClient
{
    class ChatMessage
    {
        public int id { get; private set; }
        public int source { get; private set; }
        public int reciever { get; private set; }
        public string message { get; private set; }
        public DateTime time { get; set; }

        public ChatMessage(int source, int reciever, string message)
        {
            this.source = source;
            this.reciever = reciever;
            this.message = message;
        }

    }
}