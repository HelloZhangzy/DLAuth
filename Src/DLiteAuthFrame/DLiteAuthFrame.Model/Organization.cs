namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
   
    public partial class Organization
    {        
        public Organization()
        {
            OrgRole = new HashSet<OrgRole>();
            OrgUser = new HashSet<OrgUser>();
        }

     
        public Guid OrgCode { get; set; }

        public Guid ParentCode { get; set; }
        
        public string OrgName { get; set; }
   
        public string OrgExplain { get; set; }

        public Guid CreateUserCode { get; set; }

        public DateTime CreaterDate { get; set; }

        public Guid? UpdateUserCode { get; set; }

        public DateTime? UpdateDate { get; set; }
        
        public virtual ICollection<OrgRole> OrgRole { get; set; }
        
        public virtual ICollection<OrgUser> OrgUser { get; set; }
    }
}
