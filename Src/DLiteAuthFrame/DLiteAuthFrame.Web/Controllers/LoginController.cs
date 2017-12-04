
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
        public IUserService User { get; set; }        

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Name, string PassWord)
        {
            //HttpResponse resp = new HttpResponse();

            //if (User.CheckPassWord(Name, PassWord))
            //{
            //    Result = "/home/index?Token=" + result.Token;                
            //}
            //else
            //{
            //    resp.Message = "登陆失败";
            //}
            return RedirectToAction("Index", "Home");           
        }
    }
}