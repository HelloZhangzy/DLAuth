
    using System;
    using System.Collections.Generic;


namespace DLiteAuthFrame.Domain.Model
{
    public partial class RoleMenuButton
    {
        public Guid ID { get; set; }

        public Guid ButtonCode { get; set; }

        public Guid RoleCode { get; set; }

        public Guid MenuCode { get; set; }

        public virtual ButtonLibrary ButtonLibrary { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual Role Role { get; set; }
    }
}
