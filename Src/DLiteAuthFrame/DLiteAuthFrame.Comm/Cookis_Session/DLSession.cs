using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace DLiteAuthFrame.Common
{
    public static class DLSession
    {
        const string CookiesName = "DLiteAuthFrame_Cookies";
        //private static HttpCookie cookie = HttpContext.Current.Request.Cookies[CookiesName];
        //private static HttpSessionState session = HttpContext.Current.Session;

        public static string GetCurrLoginCode()
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

        public static string GetToken()
        {
           var  cookie = HttpContext.Current.Request.Cookies[CookiesName];     

            if (cookie == null) return "";
            return DESEncrypt.Decrypt(cookie.Value);
        }

        public static void GetNewToken(string LoginCode)
        {
           var cookie = HttpContext.Current.Request.Cookies[CookiesName];
           var session = HttpContext.Current.Session;
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
    }
}
