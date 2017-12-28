using DLiteAuthFrame.APP.IApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLiteAuthFrame.MVC.Areas.SystemManage.Controllers
{
    public class UserManageController : Controller
    {
        public IUserManageApp userApp { get; set; }

        // GET: SystemManage/UserManage
        public ActionResult Index()
        {
            return View();
        }
    }
}