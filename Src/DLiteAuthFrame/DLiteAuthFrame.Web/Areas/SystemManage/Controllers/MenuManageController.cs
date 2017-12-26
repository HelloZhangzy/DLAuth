using DLiteAuthFrame.APP.APP;
using DLiteAuthFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLiteAuthFrame.Web.Areas.SystemManage.Controllers
{
    public class MenuManageController : Controller
    {
        public IMenuManageApp menuApp {get;set;}

        // GET: SystemManage/MenuManage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMenus()
        {            
            return Content(menuApp.GetMenus());
        }
    }
}