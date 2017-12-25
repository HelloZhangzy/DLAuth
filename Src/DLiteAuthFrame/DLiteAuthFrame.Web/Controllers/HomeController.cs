using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.Web.App_Start.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLiteAuthFrame.Web.Controllers
{
    public class HomeController : Controller
    {
        public IAuthManageApp auth { get; set; }        

        [AuthAttribute]
        public ActionResult Index()
        {
            ViewData["UserName"] = auth.GetUserInfo().UserName;
            ViewData["MenuViewModel"] = auth.GetMenu();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}