using DLiteAuthFrame.APP.APP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLiteAuthFrame.APP.ViewModel;
using DLiteAuthFrame.Domain.IRepository;
using DLiteAuthFrame.Domain.Model;
using DLiteAuthFrame.Common;

namespace DLiteAuthFrame.APP.IApp
{
    public class MenuManageApp : IMenuManageApp
    {
        
        public IMenuRepository _menu { get; set; }

        public ResultModel AddMenu(MenuViewModel Info)
        {
            var Item = new Menu();
            Item.CreaterDate = DateTime.Now;
            Item.CreateUserCode = Guid.Parse(DLSession.GetCurrLoginCode());
            Item.IsEnable = true;
            Item.IsVisible = true;
            Item.MenuCode = Guid.NewGuid();
            Item.MenuExplain = Info.MenuExplain;
            Item.MenuName = Info.MenuName;
            Item.ParentMenuCode = Item.ParentMenuCode;
            Item.Url = Item.Url;
            _menu.Create(Item);
            return ResultModel.success("操作成功!");
        }

        public ResultModel UpdateMenu(MenuViewModel Info)
        {
            var Item = new Menu();
            Item.CreaterDate = DateTime.Now;
            Item.CreateUserCode = Guid.Parse(DLSession.GetCurrLoginCode());
            Item.IsEnable = true;
            Item.IsVisible = true;
            Item.MenuCode = Guid.NewGuid();
            Item.MenuExplain = Info.MenuExplain;
            Item.MenuName = Info.MenuName;
            Item.ParentMenuCode = Item.ParentMenuCode;
            Item.Url = Item.Url;
            _menu.Create(Item);
            return ResultModel.success("操作成功!");
        }

        public string GetMenus()
        {           
            List<MenuViewModel> vms = new List<MenuViewModel>();
            ToTreeViewModel(vms, _menu.All().ToList(), 0, Guid.Empty);
            return "{\"rows\": " + vms.ToJson() + "}";
        }

        private void ToTreeViewModel(List<MenuViewModel> ls, List<Menu> menus, int Level, Guid ParentOrgCode)
        {
            int ser = 1;
            foreach (var item in menus.Where(t => t.ParentMenuCode == ParentOrgCode))
            {
                MenuViewModel mdto = new MenuViewModel();
                mdto.CreaterDate = item.CreaterDate;
                mdto.CreateUserCode = item.CreateUserCode;
                mdto.Ico = item.Ico;
                mdto.IsEnable = item.IsEnable;
                mdto.IsVisible = item.IsVisible;
                mdto.MenuCode = item.MenuCode;
                mdto.MenuExplain = item.MenuExplain;
                mdto.MenuName = item.MenuName;
                mdto.ParentMenuCode = item.ParentMenuCode;
                mdto.SortNo = item.SortNo;
                mdto.UpdateDate = item.UpdateDate;
                mdto.UpdateUserCode = item.UpdateUserCode;
                mdto.Url = item.Url;                 
                
                mdto.id = item.MenuCode;
                mdto.parent = item.ParentMenuCode;                
                if (menus.Where(t => t.ParentMenuCode == item.MenuCode).Count() > 0)
                { 
                    mdto.isLeaf = false;
                    mdto.expanded = true;
                }
                else
                { 
                    mdto.isLeaf = true;
                    mdto.expanded = false;
                }
                mdto.level = Level;
                mdto.loaded = true;

                ls.Add(mdto);
                if (menus.Where(t => t.ParentMenuCode == item.MenuCode).Count() > 0)
                {
                    ToTreeViewModel(ls, menus, Level + 1, item.MenuCode);
                }
            }
        }


    }
}
