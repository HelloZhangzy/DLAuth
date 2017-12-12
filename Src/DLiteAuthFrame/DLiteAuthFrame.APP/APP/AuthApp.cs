using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.APP.ViewModel;
using DLiteAuthFrame.Base.Cookis_Session;
using DLiteAuthFrame.Common;
using DLiteAuthFrame.Domain.IServices.IAuthservices;
using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace DLiteAuthFrame.APP.APP
{
    public class AuthApp : IAuthApp
    {
        private  IUserService User { get; set; }

        public AuthApp(IUserService _user)
        {
            User = _user;
        }

        public bool Login(string Name, string Pass)
        {
            string ID = User.CheckPassWord(Name, Pass);
            if (!string.IsNullOrWhiteSpace(ID))
            {
                DLSession.GetNewToken(ID);
                return true;
            }
            else return false;
        }        
        
        public bool CheckAuth()
        {
            string LoginCode = DLSession.GetCurrLoginCode();            
            return true;
        }

        public User GetUserInfo()
        {
            string ID = DLSession.GetCurrLoginCode();
            if (string.IsNullOrWhiteSpace(ID)) return null;
            return User.GetUser(Guid.Parse(ID));
        }

        public MenuViewModel GetMenu()
        {
            string ID = DLSession.GetCurrLoginCode();
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

        public List<TreeViewModel> GetOrg()
        {
            string ID = DLSession.GetCurrLoginCode();
            if (string.IsNullOrWhiteSpace(ID)) return null;
            var orgs=User.GetOrg(Guid.Parse(ID));
            List<TreeViewModel> trs = new List<TreeViewModel>();
            RecursionOrg(Guid.Empty,orgs.ToList(),trs);
            return trs;
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
                    RecursionOrg(item.OrgCode,orgs,tv.Node);
                }
                tvs.Add(tv);
            }
        }
    }
}
