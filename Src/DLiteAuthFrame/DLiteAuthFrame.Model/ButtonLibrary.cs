namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;

    public partial class ButtonLibrary
    {        
        public ButtonLibrary()
        {
            MenuButton = new HashSet<MenuButton>();
            RoleMenuButton = new HashSet<RoleMenuButton>();
        }
       
        public Guid ButtonCode { get; set; }

        public int SortNo { get; set; }
       
        public string IcoUrl { get; set; }
       
        public string Explain { get; set; }

        public Guid CreateUserCode { get; set; }

        public DateTime CreaterDate { get; set; }

        public Guid? UpdateUserCode { get; set; }

        public DateTime? UpdateDate { get; set; }
       
        public virtual ICollection<MenuButton> MenuButton { get; set; }
       
        public virtual ICollection<RoleMenuButton> RoleMenuButton { get; set; }
    }
}
