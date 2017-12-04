namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
   
    
    public partial class OrgUser
    {
        public Guid ID { get; set; }

        public Guid OrgCode { get; set; }

        public Guid UserCode { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual User User { get; set; }
    }
}
