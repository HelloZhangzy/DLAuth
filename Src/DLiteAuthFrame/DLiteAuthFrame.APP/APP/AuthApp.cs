using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.Common;
using DLiteAuthFrame.Domain.IServices.IAuthservices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace DLiteAuthFrame.APP.APP
{
    public class AuthApp : IAuthApp
    {
        const string CookiesName = "DLiteAuthFrame_Cookies2";
        private  IUserService User { get; set; }
        private HttpCookie cookie = HttpContext.Current.Request.Cookies[CookiesName];
        private HttpSessionState session= HttpContext.Current.Session;

        public AuthApp(IUserService _user)
        {
            User = _user;
        }

        public bool Login(string Name, string Pass)
        {
            if (User.CheckPassWord(Name, Pass))
            {
                GetNewToken(Name);
                return true;
            }
            else return false;
        }
                
        public string GetCurrLoginCode()
        {
            string Token = GetToken();

            if (string.IsNullOrWhiteSpace(Token)) return "";
            
            var session = HttpContext.Current.Session[Token];
            if (session != null)
            {
                return session.ToString();
            }
            else
                return "";
        }

        public bool CheckAuth()
        {
            string LoginCode = GetCurrLoginCode();
            return true;
        }

        private void GetNewToken(string LoginCode)
        {
            string ToKen = "";
            if (cookie == null)
            {
                cookie = new HttpCookie(CookiesName);
                ToKen = Guid.NewGuid().ToString();
            }
            else
            {
                ToKen = GetToken();
                if (ToKen != "")
                {
                    session.Remove(ToKen);
                }
            }
            cookie.Value = DESEncrypt.Encrypt(ToKen);
            cookie.Expires = DateTime.Now.AddMinutes(20);

            HttpContext.Current.Response.Cookies.Add(cookie);
            session.Add(ToKen, LoginCode);
        }

        private string GetToken()
        {          
            if (cookie == null) return "";
            return DESEncrypt.Decrypt(cookie.Value);
        }
    }
}
