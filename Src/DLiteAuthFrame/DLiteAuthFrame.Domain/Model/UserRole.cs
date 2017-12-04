namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
        
    public partial class UserRole
    {
        public Guid ID { get; set; }

        public Guid UserCode { get; set; }

        public Guid RoleCode { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
