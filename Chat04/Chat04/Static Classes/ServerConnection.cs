using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using Chat04.Supplementaries;

namespace Chat04.Static_Classes
{
    class ServerConnection
    {
        public static string SendMessage(string message, string webAddres, string id)
        {
            string responsemsg;
            try
            {
                using (WebClient client = new WebClient())
                {
                    var values = new NameValueCollection();
                    values[id] = message;

                    var response = client.UploadValues(webAddres, values);


                    responsemsg = Encoding.Default.GetString(response);
                }
            }
            catch
            {

               responsemsg = Newtonsoft.Json.JsonConvert.SerializeObject(false);
          
            }
            return responsemsg;
        }


        


    }
}