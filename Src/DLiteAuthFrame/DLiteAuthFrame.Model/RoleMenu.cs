namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoleMenu
    {
        public Guid ID { get; set; }

        public Guid RoleCode { get; set; }

        public Guid MenuCode { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual Role Role { get; set; }
    }
}
