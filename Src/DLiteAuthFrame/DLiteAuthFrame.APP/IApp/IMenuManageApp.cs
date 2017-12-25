using DLiteAuthFrame.APP.ViewModel;
using DLiteAuthFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.APP.APP
{
    public interface IMenuManageApp
    {
        ResultModel AddMenu(MenuViewModel Info);

        ResultModel UpdateMenu(MenuViewModel Info);

        string  GetMenus();
    }
}
