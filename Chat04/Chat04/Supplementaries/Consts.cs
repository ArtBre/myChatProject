using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat04.Supplementaries
{
     class Consts
    {
       public class IDs
        {
            public static string RequestUserData = "userdata";
            public static string RequestUserKeeper = "keep";
            public static string RequestUserMessage = "chatMessage";
            public static string RequestCurrentData = "data";

        }
       public class Addresses
        {
            public static string serverAddres = "http://localhost:7007";

            public static string authCreateUser = serverAddres+ "/Home/CreateNewUser";
            public static string authLogIn = serverAddres + "/Home/LogIn";
            public static string authChangePass = serverAddres + "/Home/ChangePassword";
            public static string authDeleteUsr = serverAddres + "/Home/DeleteUser";
            public static string authLogOut = serverAddres + "/Home/LogOut";
            public static string cliGetInstance = serverAddres + "/Home/GetUserInstance";
            public static string requestUserKeeper = serverAddres + "/Default/Index";
            public static string sendChatMessageToServer = serverAddres + "/Home/AddChatMessage";
            public static string getDataFromServer = serverAddres + "/Home/UploadDataToClient";
            

        }

       public class Combo
        {
            public static string LogIn = "LogIn";
            public static string CreateAcc = "Create Account";
            public static string ChangePass = "Change Password";
            public static string DeleteUser = "Delete User";
        }


    }
}
