using myChatServer.Controllers;
using myChatServer.Supplementaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace myChatServer.ClassesFromClient
{
    public class DefaultController : Controller
    {
        static DefaultController userListCeeper = new DefaultController();
        // GET: UserListKeeper
        public ActionResult Index()
        {
            string req = Request[Consts.RequestUserKeeper];
            userListCeeper.StartTimer();
            return Content("ok");
        }

        public void StartTimer()
        {

            Timer t = new Timer(CheckCurrentUserList, null, 0, 3000);

        }

        public void CheckCurrentUserList(Object o)
        {
            TimeSpan deadline = new TimeSpan(0, 0, 10);
            if (HomeController.CurrentUsersLog.Count > 0)
                try
                {
                    for (int i = 0; i < HomeController.CurrentUsersLog.Count; i++)
                    {
                        if (DateTime.Now.Subtract(HomeController.CurrentUsersLog[i].lastLogMsg) > deadline)
                            HomeController.CurrentUsersLog.RemoveAt(i);
                    }
                }
                catch { };
        }
    }
}
