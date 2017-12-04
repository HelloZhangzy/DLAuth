namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;

    public partial class Menu
    {       
        public Menu()
        {
            MenuButton = new HashSet<MenuButton>();
            RoleMenu = new HashSet<RoleMenu>();
            RoleMenuButton = new HashSet<RoleMenuButton>();
        }        

        public Guid MenuCode { get; set; }
        public Guid ParentMenuCode { get; set; }
        public int SortNo { get; set; }      
        public string MenuName { get; set; }
        public string MenuExplain { get; set; }
        public string Url { get; set; }
        public bool IsVisible { get; set; }
        public bool IsEnable { get; set; }
        public Guid CreateUserCode { get; set; }
        public DateTime CreaterDate { get; set; }
        public Guid? UpdateUserCode { get; set; }
        public DateTime? UpdateDate { get; set; }       
        public virtual ICollection<MenuButton> MenuButton { get; set; }                
        public virtual ICollection<RoleMenu> RoleMenu { get; set; }        
        public virtual ICollection<RoleMenuButton> RoleMenuButton { get; set; }
    }
}
