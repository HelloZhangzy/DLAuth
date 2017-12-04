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
        public IUserService User { get; set; }

        public bool Login(string Name, string Pass)
        {
            return User.CheckPassWord(Name, Pass);
        }

    }
}
