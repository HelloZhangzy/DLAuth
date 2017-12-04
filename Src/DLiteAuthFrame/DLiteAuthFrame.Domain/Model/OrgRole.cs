namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
   
   
    public partial class OrgRole
    {
        public Guid ID { get; set; }

        public Guid RoleCode { get; set; }

        public Guid OrgCode { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual Role Role { get; set; }
    }
}
