using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.Domain.IServices.IAuthservices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return false;
            //return User.CheckPassWord(Name, Pass);
        }

    }
}
