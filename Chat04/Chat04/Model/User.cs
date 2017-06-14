using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat04.Model
{
    class User
    {
        public int id { get; private set; }
        public string username { get; private set; }
        public DateTime lastLogMsg { get; set; }
        public User(int id,string username)
        {
            this.id = id;
            this.username = username;
            this.lastLogMsg = DateTime.Now;
            
        }
    }
}
