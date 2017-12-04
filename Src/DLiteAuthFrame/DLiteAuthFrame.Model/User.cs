namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
   
   
    public partial class User
    {        
        public User()
        {
            OrgUser = new HashSet<OrgUser>();
            UserRole = new HashSet<UserRole>();
            UserSet = new HashSet<UserSet>();
        }
       
        public Guid UserCode { get; set; }
      
        public string UserName { get; set; }
       
        public string UserExplain { get; set; }
        
        public string LoginPass { get; set; }

        public bool ibState { get; set; }

        public int LoginCount { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public Guid CreateUserCode { get; set; }

        public DateTime CreaterDate { get; set; }

        public Guid? UpdateUserCode { get; set; }

        public DateTime? UpdateDate { get; set; }
        
        public virtual ICollection<OrgUser> OrgUser { get; set; }
       
        public virtual ICollection<UserRole> UserRole { get; set; }
        
        public virtual ICollection<UserSet> UserSet { get; set; }
    }
}
