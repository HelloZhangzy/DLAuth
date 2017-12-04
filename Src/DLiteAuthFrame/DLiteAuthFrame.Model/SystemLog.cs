namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
   
   
    public partial class SystemLog
    {
        public Guid ID { get; set; }
        
        public string LogSource { get; set; }
       
        public string LogTypeCode { get; set; }
       
        public string LogTypeName { get; set; }
      
        public string LogText { get; set; }
       
        public string LogExplain { get; set; }

        public Guid UserCode { get; set; }
       
        public string UserName { get; set; }

        public DateTime LogDate { get; set; }
    }
}
