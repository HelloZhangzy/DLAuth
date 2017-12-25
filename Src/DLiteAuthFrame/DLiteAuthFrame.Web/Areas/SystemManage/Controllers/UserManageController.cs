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
    public class UserManageController : Controller
    {
        private IUserRepository _user = null;

        public UserManageController(IUserRepository user)
        {
            _user =user;
        }

        // GET: SystemManage/UserManage
        [AuthAttribute]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOrg()
        {
            string ID=DLSession.GetCurrLoginCode();
            if (string.IsNullOrWhiteSpace(ID)) return null;            
            var orgs = _user.GetOrg(Guid.Parse(ID)).ToList();
            List<TreeViewModel> tvs = new List<TreeViewModel>();
            RecursionOrg(Guid.Empty, orgs, tvs);
            return Content(tvs.ToJson());
        }

        public ActionResult GetUserInfo(string OrgID)
        {
            string ID = DLSession.GetCurrLoginCode();
            if (string.IsNullOrWhiteSpace(ID)) return null;
            return Content(_user.GetUsers(Guid.Parse(OrgID)).ToList<User>().ToJson());
        }

        private void RecursionOrg(Guid ParentID, List<Organization> orgs, List<TreeViewModel> tvs)
        {
            foreach (var item in orgs.Where(t => t.ParentCode == ParentID))
            {
                TreeViewModel tv = new TreeViewModel();
                tv.ID = item.OrgCode;
                tv.Name = item.OrgName;
                tv.ParentId = item.ParentCode;
                if (orgs.Where(t => t.ParentCode == item.OrgCode).Count() > 0)
                {
                    RecursionOrg(item.OrgCode, orgs, tv.Node);
                }
                tvs.Add(tv);
            }
        }


    }
}