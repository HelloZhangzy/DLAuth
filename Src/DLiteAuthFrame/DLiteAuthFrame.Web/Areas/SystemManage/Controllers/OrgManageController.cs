using DLiteAuthFrame.APP.APP;
using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.APP.ViewModel;
using DLiteAuthFrame.Base.Cookis_Session;
using DLiteAuthFrame.Common;
using DLiteAuthFrame.Domain.IRepository;
using DLiteAuthFrame.Domain.IServices.IAuthservices;
using DLiteAuthFrame.Domain.Model;
using DLiteAuthFrame.Web.App_Start.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLiteAuthFrame.Web.Areas.SystemManage.Controllers
{
    public class OrgManageController : Controller
    {
        public IOrgManageApp orgApp { get; set; }

        // GET: SystemManage/Org
        [AuthAttribute]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetOrgs()
        {
            List<OrgViewModel> data = orgApp.GetOrgTree();
            string ret_s = "{\"rows\": " + data.ToJson() + "}";
            return Content(ret_s);
        }               

        [HttpPost]
        public ActionResult GetOrg(Guid ID)
        {
            return Content(orgApp.GetOrgInfo(ID).ToJson());
        }

        [HttpPost]
        public ActionResult AddOrUpdateOrg(OrgViewModel ov)
        {
            if (ov != null)
            {
                if (ov.OrgCode == Guid.Empty)
                    return Content(orgApp.Add(ov).ToJson());
                else
                    return Content(orgApp.Update(ov).ToJson());
            }
            return Content(new AjaxResult { state = ResultType.error.ToString(), message = "数据填写不完整！", data = null }.ToJson());
        }

        public ActionResult DeleteOrg(Guid ID)
        {
            return Content(orgApp.Delete(ID).ToJson());
        }
                 
        [AuthAttribute]
        public ActionResult Edit(string id)
        {
            Guid ID = Guid.Parse(id);

            var ls = orgApp.GetOrgSelect(ID);

            if (!(ID==Guid.Empty))
            {
                var org = orgApp.GetOrgInfo(ID);

                ls.Where(t => t.Value == org.ParentCode.ToString()).FirstOrDefault().Selected = true;

                var temp = ls.Where(t => t.Value == ID.ToString()).FirstOrDefault();

                if (temp != null)
                {
                    temp.Disabled = false;
                }

                ViewData["OrgViewModel"] = org;
            }
            else ViewData["OrgViewModel"] = new OrgViewModel();            

            ViewData["OrgList"] = new SelectList(ls, "Value", "Text");
            return View();
        }
    }
}