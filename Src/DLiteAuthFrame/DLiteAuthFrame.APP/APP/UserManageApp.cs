using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.APP.ViewModel;
using DLiteAuthFrame.Common;
using DLiteAuthFrame.Domain.IRepository;
using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.APP.APP
{
    public class UserManageApp: IUserManageApp
    {
        public IUserRepository _user { get; set; }

        public IRoleRepository _role { get; set; }

       // public AuthApp auth { get; set; }

        public List<UserViewModel> GetOrgUsers(Guid orgID)
        {
            List<UserViewModel> users = new List<UserViewModel>();
            foreach (var item in _user.GetUsers(orgID))
            {
                UserViewModel uv = new UserViewModel();
                uv.CreaterDate = item.CreaterDate;
                uv.CreateUserCode = item.CreateUserCode;
                uv.ibState = item.ibState;
                uv.LastLoginDate = item.LastLoginDate;
                uv.LoginCode = item.LoginCode;
                uv.LoginCount = item.LoginCount;
                uv.LoginPass = item.LoginPass;
                uv.Sex = item.Sex;
                uv.UpdateDate = item.UpdateDate;
                uv.UpdateUserCode = item.UpdateUserCode;
                uv.UserCode = item.UserCode;
                uv.UserExplain = item.UserExplain;
                uv.UserName = item.UserName;                
                users.Add(uv);
            }
            return users;
        }


        public UserViewModel GetUserInfo(Guid ID)
        {
            var item = _user.Find(t => t.UserCode == ID);
            UserViewModel uv = new UserViewModel();
            uv.CreaterDate = item.CreaterDate;
            uv.CreateUserCode = item.CreateUserCode;
            uv.ibState = item.ibState;
            uv.LastLoginDate = item.LastLoginDate;
            uv.LoginCode = item.LoginCode;
            uv.LoginCount = item.LoginCount;
            uv.LoginPass = item.LoginPass;
            uv.Sex = item.Sex;
            uv.UpdateDate = item.UpdateDate;
            uv.UpdateUserCode = item.UpdateUserCode;
            uv.UserCode = item.UserCode;
            uv.UserExplain = item.UserExplain;
            uv.UserName = item.UserName;
            uv.OrgCode = item.OrgUser.FirstOrDefault().OrgCode;
            return uv;
        }


        public ResultModel UpdateState(Guid UserID)
        {
            var user=_user.Find(t => t.UserCode == UserID);
            if (user == null) return ResultModel.error("未找到用户！");
            if (user.LoginCode=="admin") return ResultModel.error("超级管理员不能禁用！");
            user.ibState = !user.ibState;
            user.UpdateUserCode = Guid.Parse(DLSession.GetCurrLoginCode());
            user.UpdateDate = DateTime.Now;
            _user.Update(user);            
            return ResultModel.error("操作成功！");
        }

        public ResultModel UpdateUserInfo(UserViewModel user)
        {

            var Info = _user.Find(t => t.UserCode == user.UserCode);
            if (Info==null) return ResultModel.error("未找到用户！");
            Info.UserExplain = user.UserExplain;
            Info.UserName = user.UserName;
            Info.LoginCode = user.LoginCode;
            Info.Sex = user.Sex;
            Info.UpdateDate = DateTime.Now;
            Info.UpdateUserCode = Guid.Parse(DLSession.GetCurrLoginCode());
            _user.Update(Info);
            
            return ResultModel.error("操作成功！");
        }

        public  ResultModel AddUser(UserViewModel user)
        { 
            User Info = new User();
            Info.UserExplain = user.UserExplain;
            Info.UserName = user.UserName;
            Info.LoginCode = user.LoginCode;
            Info.Sex = user.Sex;
            Info.CreaterDate = DateTime.Now;
            Info.CreateUserCode =Guid.Parse(DLSession.GetCurrLoginCode());
            Info.UpdateDate = DateTime.Now;
            Info.UpdateUserCode = Guid.Parse(DLSession.GetCurrLoginCode());
            _user.Create(Info);
            return ResultModel.error("操作成功！");
        }



        public ResultModel ResetPassWord(Guid UserID,string pass)
        {
            var user = _user.Find(t => t.UserCode == UserID);
            if (user == null) return ResultModel.error("未找到用户！");
            user.LoginPass = pass;
            _user.Update(user);
            return ResultModel.error("操作成功！");
        }

        public ResultModel UpdatePassWord(Guid UserID, string OldPass,string NewPass)
        {
            var user = _user.Find(t => t.UserCode == UserID&&t.LoginPass==OldPass);
            if (user == null) return ResultModel.error("原密码不正确！");
            user.LoginPass = NewPass;
            _user.Update(user);
            return ResultModel.error("操作成功！");
        }

        public ResultModel SetRole(Guid userId, List<Guid> roles)
        {
            throw new NotImplementedException();
        }
    }
}
