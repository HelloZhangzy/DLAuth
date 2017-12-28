using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLiteAuthFrame.MVC.Areas.SystemManage.Controllers
{
    public class OrgManageController : Controller
    {
        public IOrgManageApp orgApp { get; set; }

        // GET: SystemManage/OrgManage
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetOrgNode(string OrgID)
        {            
            if (string.IsNullOrWhiteSpace(OrgID))            
                return Content(orgApp.Get_CurrUser_OrgNode().ToJson());
            else
                return Content(orgApp.Get_Org_OrgNode(Guid.Parse(OrgID)).ToJson());
        }

    }
}