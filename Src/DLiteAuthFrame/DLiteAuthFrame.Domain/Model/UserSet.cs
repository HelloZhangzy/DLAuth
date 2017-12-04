namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
   
    public partial class UserSet
    {
        public Guid ID { get; set; }

        public Guid UserCode { get; set; }
        
        public string SetCode { get; set; }
        
        public string SetName { get; set; }
       
        public string SetExplain { get; set; }

        public virtual User User { get; set; }
    }
}
