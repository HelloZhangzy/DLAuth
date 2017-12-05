
using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.Common;
using DLiteAuthFrame.Domain.IServices.IAuthservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLiteAuthFrame.Web.Controllers
{
    public class LoginController : Controller
    {
        private IAuthApp Auth = null;

        public LoginController(IAuthApp _auth)
        {
            Auth = _auth;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]        
        public ActionResult Login(string Name, string PassWord)
        {
            if(!Auth.Login(Name,PassWord))  return Content(new AjaxResult { state = ResultType.error.ToString(), message = "账号或密码错误！" }.ToJson());           
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功！" }.ToJson());

        }
    }
}