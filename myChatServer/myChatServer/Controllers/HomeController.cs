using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
//FromMyProject
using myChatServer.Database;
using myChatServer.ClassesFromClient;
using myChatServer.Supplementaries;
using System.Text;
using System.Threading;

namespace myChatServer.Controllers
{
    public partial class HomeController : Controller
    {
       public static List<ChatUser> CurrentUsersLog = new List<ChatUser>();
       
        


        public ActionResult Index()
        {
            
            ViewBag.Title = "Home Page";
            
            return View();
        }

        //Authentication methods start
        public ActionResult CreateNewUser()
        {
            string createUserDataFromClient = Request[Consts.RequestIdForUserData];
            bool createUserSuccesed=false;
            string response;
            


            try
            {

                LogInMessage UserObject = JsonConvert.DeserializeObject<LogInMessage>(createUserDataFromClient);

                if (IsUserExistInDatabase(UserObject.username))
                {
                    createUserSuccesed = false;
                }
                else
                {
                    CreateUser(UserObject.username,UserObject.password);
                    createUserSuccesed = true;
                }

            }
            catch { }

            response = JsonConvert.SerializeObject(createUserSuccesed);



            return Content(response);
        }

        public ActionResult LogIn()
        {
            string logInDataFromClient = Request[Consts.RequestIdForUserData];
            bool isLogInSuccesed = false;
            string response="";
            try
            {
                LogInMessage UserObject = JsonConvert.DeserializeObject<LogInMessage>(logInDataFromClient);
                
                if (CheckUserLoginData(UserObject.username, UserObject.password))
                {
                    isLogInSuccesed = true;
                    
                        CurrentUsersLog.Add(GetCurrentUserInstance(UserObject.username));
                        
                   
                    
                }
                else
                {
                    isLogInSuccesed = false;
                }
            }
            catch
            { }

            response = JsonConvert.SerializeObject(isLogInSuccesed);
            return Content(response);
        }

        public ActionResult ChangePassword()
        {
            string logInDataFromClient = Request[Consts.RequestIdForUserData];
            bool isChangePassSuccesed = false;
            string response = "";
            try
            {
              LogInMessage UserObject = JsonConvert.DeserializeObject<LogInMessage>(logInDataFromClient);

                if (ChangePassword(CheckUserLoginData(UserObject.username,UserObject.password),UserObject.username, UserObject.newPassword))
                {
                    isChangePassSuccesed = true;
                }
                else
                {
                    isChangePassSuccesed = false;
                }
            }
            catch { }


            response = JsonConvert.SerializeObject(isChangePassSuccesed);
            return Content(response);
        }

        public ActionResult DeleteUser()
        {
            string logInDataFromClient = Request[Consts.RequestIdForUserData];
            bool isDeleteSuccesed = false;
            string response = "";
            try
            {
                LogInMessage UserObject = JsonConvert.DeserializeObject<LogInMessage>(logInDataFromClient);

                if (UserDelete(CheckUserLoginData(UserObject.username,UserObject.password),UserObject.username))
                {
                    isDeleteSuccesed = true;
                }
                else
                {
                    isDeleteSuccesed = false;
                }
            }
            catch
            { }

            response = JsonConvert.SerializeObject(isDeleteSuccesed);
            return Content(response);
        }
        
        public ActionResult GetUserInstance()
        {
            string requestForUserInstance = Request[Consts.RequestIdForUserData];
            string response="";
            ChatUser currentUser=null;
            try
            {
                LogInMessage UserObject = JsonConvert.DeserializeObject<LogInMessage>(requestForUserInstance);

                if (IsUserExistInDatabase(UserObject.username))
                {
                     currentUser = GetCurrentUserInstance(UserObject.username);
                     
                }
                else
                {
                     currentUser =null;
                }
            }
            catch
            {  }
            response = JsonConvert.SerializeObject(currentUser);

            return Content(response);
        }

        public ActionResult LogOut()
        {
            string requestForUserInstance = Request[Consts.RequestIdForUserData];
            try
            {
                LogInMessage UserObject = JsonConvert.DeserializeObject<LogInMessage>(requestForUserInstance);
                for(int i=0;i<=CurrentUsersLog.Count ;i++)
                CurrentUsersLog.Remove(CurrentUsersLog.Find(x => x.username == UserObject.username));
                
            }
            catch
            { }

            return Content(JsonConvert.SerializeObject(true));
        }
        //Authentication end
        //Recieve Message
        public ActionResult AddChatMessage()
        {
            string userMessageFromClient = Request[Consts.RequestUserMessage];
            bool sendMessageSuccesed = false;
            string response="";

            try
            {
                ChatMessage message = JsonConvert.DeserializeObject<ChatMessage>(userMessageFromClient);

                if (SendMessageToDatabase(message.message,message.source,message.reciever))
                {
                    sendMessageSuccesed = true;


                }
                else
                {
                    sendMessageSuccesed = false;
                }
            }
            catch { }
            response = JsonConvert.SerializeObject(sendMessageSuccesed);
            return Content(response);
        }
        //SendData
        public ActionResult UploadDataToClient()
        {
            string createUserDataFromClient = Request[Consts.RequestCurrentData];
            string response = "";
            try
            {
                ChatUser userFromClient = JsonConvert.DeserializeObject<ChatUser>(createUserDataFromClient);
                List<ChatMessage> newMessages = GetNewMessages(userFromClient);
                userFromClient.lastLogMsg = DateTime.Now;

                CurrentUsersLog.Find(x => x.username == userFromClient.username).lastLogMsg = DateTime.Now;
                DataFromServer currentData = new DataFromServer(CurrentUsersLog, newMessages, userFromClient);
                
                response = JsonConvert.SerializeObject(currentData);
            }
            catch { }
            return Content(response);
        }
    }
}
