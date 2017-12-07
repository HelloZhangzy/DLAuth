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
        [AuthAttribute]
        public ActionResult Index()
        {            
            return View();
        }
    }
}