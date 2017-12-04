namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
    
   
    public partial class RoleSetAuth
    {
        public Guid ID { get; set; }

        public Guid RoleCode { get; set; }

        public Guid SetAuthCode { get; set; }

        public virtual Role Role { get; set; }

        public virtual SetAuthCode SetAuthCodeEntity { get; set; }
    }
}
