
using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.Common;
using DLiteAuthFrame.Domain.IServices.IAuthservices;
using DLiteAuthFrame.Web.Models;
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
        public string CheckLogin(LoginViewModel user)
        {
            //Response.Write("<Script Language=JavaScript>alert('密码或用户名错误，请重试！');</Script>");

            if (Auth.Login(user.LoginCode, user.PassWord))
                return (new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            else
                return (new AjaxResult { state = ResultType.error.ToString(), message = "账号或密码错误！" }.ToJson());

        }
    }
}