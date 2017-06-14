using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myChatServer.ClassesFromClient
{
    class DataFromServer
    {
        public List<ChatUser> currentUsers { get; private set; }
        public List<ChatMessage> newMessages { get; private set; }
        public ChatUser user { get; private set; }

        public DataFromServer(List<ChatUser> currentUsers, List<ChatMessage> newMessages,ChatUser user)
        {
            this.currentUsers = currentUsers;
            this.newMessages = newMessages;
            this.user = user;
        }

    }
}