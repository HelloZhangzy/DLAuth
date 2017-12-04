namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
   
    
    public partial class Role
    {
        
        public Role()
        {
            OrgRole = new HashSet<OrgRole>();
            RoleMenu = new HashSet<RoleMenu>();
            RoleMenuButton = new HashSet<RoleMenuButton>();
            RoleSetAuth = new HashSet<RoleSetAuth>();
            UserRole = new HashSet<UserRole>();
        }

        
        public Guid RoleCode { get; set; }

        public int SortNo { get; set; }
       
        public string RoleName { get; set; }
      
        public string RoleExplain { get; set; }

        public Guid CreateUserCode { get; set; }

        public DateTime CreaterDate { get; set; }

        public Guid? UpdateUserCode { get; set; }

        public DateTime? UpdateDate { get; set; }
        
        public virtual ICollection<OrgRole> OrgRole { get; set; }
        
        public virtual ICollection<RoleMenu> RoleMenu { get; set; }
        
        public virtual ICollection<RoleMenuButton> RoleMenuButton { get; set; }
       
        public virtual ICollection<RoleSetAuth> RoleSetAuth { get; set; }
        
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
