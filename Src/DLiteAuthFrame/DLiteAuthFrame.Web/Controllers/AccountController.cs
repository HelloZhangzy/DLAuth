using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLiteAuthFrame.Web.Controllers
{
    public class AccountController : Controller
    {

        private IAuthApp Auth = null;

        public AccountController(IAuthApp _auth)
        {
            Auth = _auth;
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Name, string PassWord)
        {            
            if (Auth.Login(Name, PassWord))
                return Content(new AjaxResult { state = ResultType.success.ToString(),Url="/Home/Index", message = "登录成功。" }.ToJson());
            else
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = "账号或密码错误！" }.ToJson());
            //return View();
        }        
    }
}