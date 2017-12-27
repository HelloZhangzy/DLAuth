using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.APP.ViewModel;
using DLiteAuthFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLiteAuthFrame.MVC.Controllers
{
    public class AccountController : Controller
    {

        private IAuthManageApp Auth = null;

        public AccountController(IAuthManageApp _auth)
        {
            Auth = _auth;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Name, string PassWord)
        {
            if (Auth.Login(Name, PassWord))
                return Content(ResultModel.success("登录成功", "/Home/Index").ToJson());
            else
                return Content(ResultModel.error("账号或密码错误!", "").ToJson());
        }        
    }
}