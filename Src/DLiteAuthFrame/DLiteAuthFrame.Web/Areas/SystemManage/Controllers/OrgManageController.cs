using DLiteAuthFrame.APP.ViewModel;
using DLiteAuthFrame.Base.Cookis_Session;
using DLiteAuthFrame.Common;
using DLiteAuthFrame.Domain.IRepository;
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
        IOrgRository org = null;
        public OrgManageController(IOrgRository _org)
        {
            org = _org;
        }

        // GET: SystemManage/Org
        [AuthAttribute]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOrgs()
        {
            var UserID = DLSession.GetCurrLoginCode();

            if (string.IsNullOrWhiteSpace(UserID)) return null;

            var data = org.GetOrgs(Guid.Parse(UserID));

            return Content(ToViewModel(data).ToJson());
        }

        [HttpPost]
        public ActionResult GetOrg(string ID)
        {
            var item = org.Filter(t => t.OrgCode.ToString() == ID).FirstOrDefault();
            if (item != null)
            {
                OrgViewModel ov = new OrgViewModel();
                ov.CreaterDate = item.CreaterDate;
                ov.CreateUserCode = item.CreateUserCode;
                ov.OrgCode = item.OrgCode;
                ov.OrgExplain = item.OrgExplain;
                ov.OrgName = item.OrgName;
                ov.ParentCode = item.ParentCode;
                ov.UpdateDate = item.UpdateDate;
                ov.UpdateUserCode = item.UpdateUserCode;
                return Content(ov.ToJson());
            }
            return null;            
        }

        private List<OrgViewModel> ToViewModel(IQueryable<Organization> orgs)
        {
            List<OrgViewModel> ovm = new List<OrgViewModel>();

            foreach (var item in orgs)
            {
                OrgViewModel ov = new OrgViewModel();
                ov.CreaterDate = item.CreaterDate;
                ov.CreateUserCode = item.CreateUserCode;
                ov.OrgCode = item.OrgCode;
                ov.OrgExplain = item.OrgExplain;
                ov.OrgName = item.OrgName;
                ov.ParentCode = item.ParentCode;
                ov.UpdateDate = item.UpdateDate;
                ov.UpdateUserCode = item.UpdateUserCode;
                ovm.Add(ov);
            }
            return ovm;
        }

        [AuthAttribute]
        public ActionResult Edit()
        {           
            return View();
        }
    }
}