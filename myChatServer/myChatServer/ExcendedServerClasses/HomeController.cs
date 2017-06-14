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
    partial class HomeController
    {

        //Auth
        bool IsUserExistInDatabase(string username)
        {
            myChatDatabaseDataContext db = new myChatDatabaseDataContext();
            var user = from User in db.Users where User.username == username && User.deleted==false select User.username;
            if (user.Count()>0) return true;
            else return false;
        }
        void CreateUser(string username,string password)
        {
           
            myChatDatabaseDataContext db = new myChatDatabaseDataContext();
            User newUser = new Database.User();
            newUser.username = username;
            newUser.password = password;
            newUser.usercreated = DateTime.Now;
            newUser.userlastlogintime = DateTime.Now;
            newUser.deleted = false;
            db.Users.InsertOnSubmit(newUser);
            db.SubmitChanges();
        }
        bool CheckUserLoginData(string username,string password)
        {
            myChatDatabaseDataContext db = new myChatDatabaseDataContext();
            var user = from User in db.Users where User.username == username && User.password== password && User.deleted == false select User;
            if (user.Count() > 0) return true;
            else return false;
        }
        bool ChangePassword(bool userDataChecked,string username,string password)
        {
            if (userDataChecked)
            {
                myChatDatabaseDataContext db = new myChatDatabaseDataContext();
                var user = from User in db.Users where User.username == username && User.deleted == false select User;
                User currentUser = user.First<User>();
                currentUser.password = password;   
                db.SubmitChanges();
                return true;
            }
            else return false;
        }
        bool UserDelete(bool userDataChecked, string username)
        {
            if (userDataChecked)
            {
                myChatDatabaseDataContext db = new myChatDatabaseDataContext();
                var user = from User in db.Users where User.username == username && User.deleted == false select User;
                User currentUser = user.First<User>();
                currentUser.deleted=true;
                db.SubmitChanges();
                return true;
            }
            else return false;
        }
        ChatUser GetCurrentUserInstance(string login)
        {
            myChatDatabaseDataContext db = new myChatDatabaseDataContext();
            var user = from User in db.Users where User.username == login && User.deleted == false select User;
            
            User currentUser = user.First<User>();
            currentUser.userlastlogintime = DateTime.Now;
            db.SubmitChanges();
            
            return new ChatUser(currentUser.user_id, currentUser.username);
        }
        //ChatMessages
        bool SendMessageToDatabase(string message,int source,int reciver)
        {
            try
            {
                myChatDatabaseDataContext db = new myChatDatabaseDataContext();
                db_message currentMessage = new db_message();
                currentMessage.message = message;
                currentMessage.sender = source;
                currentMessage.receiver = reciver;
                currentMessage.date = DateTime.Now;
                db.db_messages.InsertOnSubmit(currentMessage);
                db.SubmitChanges();
                return true;
            }
            catch { return false; }
        }

        List<ChatMessage> GetNewMessages(ChatUser currentUser)
        {
            myChatDatabaseDataContext db = new myChatDatabaseDataContext();
            List<ChatMessage> newMessages = new List<ChatMessage>();
            
            var messages = from db_message in db.db_messages where db_message.date > currentUser.lastLogMsg &&  (db_message.receiver==currentUser.id || db_message.receiver==0 ) select db_message;
            db_message[] tempArray = messages.ToArray<db_message>();

            foreach (db_message message in tempArray)
            {
                newMessages.Add(new ChatMessage(message.sender, message.receiver, message.message));
            }

            return newMessages;
        }

        



    }
}