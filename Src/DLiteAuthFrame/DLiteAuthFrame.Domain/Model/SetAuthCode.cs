namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
   
    public partial class SetAuthCode
    {
       
        public SetAuthCode()
        {
            RoleSetAuth = new HashSet<RoleSetAuth>();
        }
       
        public Guid ID { get; set; }
       
        public string SetAuthName { get; set; }

        public Guid ParentCode { get; set; }

        public Guid CreateUserCode { get; set; }

        public DateTime CreaterDate { get; set; }

        public Guid? UpdateUserCode { get; set; }

        public DateTime? UpdateDate { get; set; }
       
        public virtual ICollection<RoleSetAuth> RoleSetAuth { get; set; }
    }
}
