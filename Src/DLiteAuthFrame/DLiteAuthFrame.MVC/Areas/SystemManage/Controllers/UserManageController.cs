using DLiteAuthFrame.APP.APP;
using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.APP.ViewModel;
using DLiteAuthFrame.Base.Cookis_Session;
using DLiteAuthFrame.Common;
using DLiteAuthFrame.Domain.IRepository;
using DLiteAuthFrame.Domain.IServices.IAuthservices;
using DLiteAuthFrame.Domain.Model;
using DLiteAuthFrame.MVC.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLiteAuthFrame.MVC.Areas.SystemManage.Controllers
{
    public class UserManageController : Controller
    {
        public IUserRepository _user { get; set; }

        public IUserManageApp userApp { get; set; }
        public IOrgManageApp orgApp { get; set; }

        [AuthAttribute]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOrg()
        {
            string ID = DLSession.GetCurrLoginCode();
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

        [HttpGet]
        public ActionResult GetOrgUsers(string OrgID)
        {
            if (string.IsNullOrWhiteSpace(OrgID)) return Content("");

            var retData = userApp.GetOrgUsers(Guid.Parse(OrgID));
            if (retData == null) return Content("");

            return Content(retData.ToJson());
        }

        [AuthAttribute]
        [HttpPost]
        public ActionResult UpdateState(string ID)
        {
            if (string.IsNullOrWhiteSpace(ID)) return Content(ResultModel.error("请选择……").ToJson());
            return Content(userApp.UpdateState(Guid.Parse(ID)).ToJson());
        }

        [AuthAttribute]
        [HttpGet]
        public ActionResult PassWord(string ID)
        {
            ViewData["ID"] = ID;
            return View();
        }

        [AuthAttribute]
        [HttpGet]
        public ActionResult Edit(string ID)
        {

            var user = new UserViewModel();

            var ls = orgApp.GetOrgSelect(Guid.Empty);

            if (string.IsNullOrEmpty(ID))
            {
                user = userApp.GetUserInfo(Guid.Parse(ID));
                ls.Where(t => t.Value == user.ToString()).FirstOrDefault().Selected = true;
            }
            ViewData["UserInfo"] = user;
            ViewData["OrgList"] = ls;
            return View();
        }

        public ActionResult AddOrUpdateUserInfo(UserViewModel info)
        {
            if (info.UserCode == null)
            {
                return Content(userApp.AddUser(info).ToJson());
            }
            else
                return Content(userApp.UpdateUserInfo(info).ToJson());
        }



        [AuthAttribute]
        [HttpPost]
        public ActionResult ResetPassWord(string ID, string PassWord, string ConfirmPassWord)
        {
            if (!PassWord.Equals(ConfirmPassWord)) return Content(ResultModel.error("两次密码不一致").ToJson());

            return Content(userApp.ResetPassWord(Guid.Parse(ID), PassWord).ToJson());
        }

        [AuthAttribute]
        [HttpPost]
        public ActionResult UpdatePassWord(string ID, string OldPassWord, string PassWord, string ConfirmPassWord)
        {
            if (!PassWord.Equals(ConfirmPassWord)) return Content(ResultModel.error("两次密码不一致").ToJson());

            return Content(userApp.UpdatePassWord(Guid.Parse(ID), OldPassWord, PassWord).ToJson());
        }

        [AuthAttribute]
        [HttpPost]
        public ActionResult UpdateInfo(UserViewModel user)
        {
            if (user == null || user.UserCode == null) return Content(ResultModel.error("数据错误").ToJson());

            return Content(userApp.UpdateUserInfo(user).ToJson());
        }
    }
}