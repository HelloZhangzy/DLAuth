namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
  

    
    public partial class MenuButton
    {
        public Guid ID { get; set; }

        public Guid MenuCode { get; set; }

        public Guid ButtonCode { get; set; }

        public virtual ButtonLibrary ButtonLibrary { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
