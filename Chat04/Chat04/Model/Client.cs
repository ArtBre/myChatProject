using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//My usings
using Chat04.Model;
using Chat04.Static_Classes;
using Chat04.Supplementaries;
using Chat04;



namespace Chat04.Model
{
    class Client
    {

        public static User current = null;
        public static bool SendLogInMessage(string host, string username, string password, string newPassword) 
        {
            LogInMessage logInMessage = new LogInMessage(username, password,newPassword);
            string sendLoginMessageToServer = JsonConvert.SerializeObject(logInMessage);
            string response = ServerConnection.SendMessage(sendLoginMessageToServer, host, Consts.IDs.RequestUserData);
            return JsonConvert.DeserializeObject<bool>(response);
        }

        public static User getCurrentUserInstance(string username)
        {
            
            LogInMessage logInMessage = new LogInMessage(username, null, null);
            string sendLoginMessageToServer = JsonConvert.SerializeObject(logInMessage);
            string  response = ServerConnection.SendMessage(sendLoginMessageToServer, Consts.Addresses.cliGetInstance, Consts.IDs.RequestUserData);
            return JsonConvert.DeserializeObject<User>(response); 
        }

        public static bool SendMessageToServer(int source, int reciever, string message)
        {
            ChatMessage newMessage = new ChatMessage(source,reciever,message);
            string sendChatMessageToserver = JsonConvert.SerializeObject(newMessage);
            string response = ServerConnection.SendMessage(sendChatMessageToserver, Consts.Addresses.sendChatMessageToServer, Consts.IDs.RequestUserMessage);
            return JsonConvert.DeserializeObject<bool>(response);
        }

        public static bool GetCurrentDataFromServer(User user, Form1 myForm)
        {

            try
            {
                
                string sendUserToServer = JsonConvert.SerializeObject(user);
                string response = ServerConnection.SendMessage(sendUserToServer, Consts.Addresses.getDataFromServer, Consts.IDs.RequestCurrentData);

                DataFromServer newDataFromServer = JsonConvert.DeserializeObject<DataFromServer>(response);

                User tempUserForTime = newDataFromServer.user;
                List<User> currentUsers = newDataFromServer.currentUsers;
                List<ChatMessage> newMessages = newDataFromServer.newMessages;

                Client.current.lastLogMsg = tempUserForTime.lastLogMsg;

                foreach (ChatMessage ms in newMessages)
                {
                    if (ms.reciever == 0)
                    {
                        myForm.MainChatWindow.Items.Add(ms);
                        myForm.MainChatWindow.SelectedIndex = (myForm.MainChatWindow.Items.Count - 1);
                        myForm.MainChatWindow.ClearSelected();
                    }
                    else
                    {
                        PrivateMessageAdministrator(ms);
                    }

                }

                myForm.NickNameList.Items.Clear();
                foreach (User usr in currentUsers)
                {
                    myForm.NickNameList.Items.Add(usr);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void PrivateMessageAdministrator(ChatMessage PrivMsg)
        {
            Form2 tempUsrForCheck= Form1.activePrivForms.Find(x => x.reciever == PrivMsg.source);
            if (tempUsrForCheck !=null)
            {
                foreach (Form2 form in Form1.activePrivForms) 
                {
                    if (form.sender == PrivMsg.reciever && PrivMsg.source == form.reciever) {
                        form.PrivateChatWindow.Items.Add(PrivMsg.message);
                        form.PrivateChatWindow.SelectedIndex = (form.PrivateChatWindow.Items.Count - 1);
                        form.PrivateChatWindow.ClearSelected();
                    }
                }

            }
            else {
                Form2 form2 = new Form2("test", Client.current.id, PrivMsg.source, PrivMsg.message);
                Form1.activePrivForms.Add(form2);
                form2.Show();
            }

        }
    }
}
