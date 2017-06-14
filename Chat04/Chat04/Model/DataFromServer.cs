using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat04.Model
{
    class DataFromServer
    {
        public List<User> currentUsers { get; private set; }
        public List<ChatMessage> newMessages  { get; private set; }
        public User user { get; private set; }

        public  DataFromServer(List<User> currentUsers, List<ChatMessage> newMessages,User user)
        {
            this.currentUsers = currentUsers;
            this.newMessages = newMessages;
            this.user = user;
        }

    }
}
