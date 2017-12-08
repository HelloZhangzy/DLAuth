using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.APP.ViewModel;
using DLiteAuthFrame.Common;
using DLiteAuthFrame.Domain.IServices.IAuthservices;
using DLiteAuthFrame.Domain.Model;
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
        const string CookiesName = "DLiteAuthFrame_Cookies";

        private  IUserService User { get; set; }

        private HttpCookie cookie = HttpContext.Current.Request.Cookies[CookiesName];
        private HttpSessionState session= HttpContext.Current.Session;

        public AuthApp(IUserService _user)
        {
            User = _user;
        }

        public bool Login(string Name, string Pass)
        {
            string ID = User.CheckPassWord(Name, Pass);
            if (!string.IsNullOrWhiteSpace(ID))
            {
                GetNewToken(ID);
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

        public User GetUserInfo()
        {
            string ID = GetCurrLoginCode();
            if (string.IsNullOrWhiteSpace(ID)) return null;
            return User.GetUser(Guid.Parse(ID));
        }

        public MenuViewModel GetMenu()
        {
            string ID = GetCurrLoginCode();
            if (string.IsNullOrWhiteSpace(ID)) return null;
            List<Menu> menu=User.GetMenu(Guid.Parse(ID)).ToList();
            MenuViewModel mvm = new MenuViewModel();
            mvm.ParentId = Guid.Empty;
            mvm.Name = " 首页";
            mvm.ID = Guid.Empty;
            mvm.URL = "/Home/Index";
            mvm.ICO = "";
            RecursionMenu(Guid.Empty, menu, mvm);
            return mvm;         
        }

        private void RecursionMenu(Guid ParentID,List<Menu> menu,MenuViewModel _mvm)
        {            
            foreach (var item in menu.Where(t => t.ParentMenuCode == ParentID))
            {
                MenuViewModel mvm = new MenuViewModel();
                mvm.ID = item.MenuCode;
                mvm.Name = item.MenuName;
                mvm.ParentId = item.ParentMenuCode;
                mvm.URL = item.Url;
                mvm.ICO = item.Url;
                if (menu.Where(t=>t.ParentMenuCode==item.MenuCode).Count()>0)
                {   
                    var node=menu.Where(t => t.ParentMenuCode == item.MenuCode).ToList<Menu>();
                    RecursionMenu(item.MenuCode, node, mvm);
                }
                _mvm.Node.Add(mvm);
            }

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
