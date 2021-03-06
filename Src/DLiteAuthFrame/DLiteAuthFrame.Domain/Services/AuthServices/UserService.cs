﻿using DLiteAuthFrame.Domain.IServices.IAuthservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLiteAuthFrame.Domain.Model;
using System.Linq.Expressions;
using DLiteAuthFrame.Domain.IRepository;

namespace DLiteAuthFrame.Domain.Services.AuthServices
{
    public  class UserService : IUserService
    {       
        private IUserRepository _user = null;
        private IRepository<OrgUser> _org=null;
        private IRepository<UserRole> _role = null;

        public UserService(IUserRepository User)
        {          
            this._user= User;
        }

        public void Add(User user)
        {
            _user.Create(user);
        }

        public void Delete(User user)
        {
            user.ibState = false;
            _user.Update(user);
        }

        public IQueryable<Menu> GetMenu(Guid UserID)
        {
            return _user.GetMenu(UserID);
        }

        public string CheckPassWord(string Name, string PassWord)
        {
           // var Luser= _user.Find(t => t.LoginCode == Name.Trim() && t.LoginPass == PassWord && t.ibState == true);
            var temp=_user.Filter(t => t.LoginCode == Name && t.LoginPass == PassWord && t.ibState==true);
           var  Luser = temp.FirstOrDefault();

            if (Luser != null)
            {
                Luser.LastLoginDate = DateTime.Now;
                Luser.LoginCount++;
                _user.Update(Luser);
                return Luser.UserCode.ToString();
            }
            else return "";
        }

        public IQueryable<Organization> GetOrg(Guid UserID)
        {
            return _user.GetOrg(UserID);
        }

        public IQueryable<Role> GetRole(Guid UserID)
        {
            return _user.GetRole(UserID);
        }

        public User GetUser(Guid ID)
        {
            return _user.Filter(t => t.UserCode == ID).FirstOrDefault();
        }

        public IQueryable<User> GetUsers(Expression<Func<User, bool>> filter, out int total, int index = 0, int size = 50)
        {
            return _user.Filter(filter, out total, index, size);
        }


        public void SetOrg(Guid UserID, List<Guid> Orgs)
        {
            throw new NotImplementedException();
        }

        public void SetRole(Guid UserID, List<Guid> Roles)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

    }
}
