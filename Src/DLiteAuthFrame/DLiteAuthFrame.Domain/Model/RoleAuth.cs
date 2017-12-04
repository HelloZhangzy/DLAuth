namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class RoleAuth
    {
        public Guid ID { get; set; }

        public Guid RoleCode { get; set; }

        public Guid MenuCode { get; set; }

        public int AuthType { get; set; }
       
        public string ColumnName { get; set; }
       
    }
}
