﻿using DLiteAuthFrame.APP.ViewModel;
using DLiteAuthFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.APP.IApp
{
    public interface IAuthManageApp
    {
        bool Login(string Name, string Pass);        

        bool CheckAuth();

        MenuNavViewModel GetMenu();

        User GetUserInfo();
    }

}
