namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
    
  
    public partial class LoginLog
    {
        public Guid ID { get; set; }

        public Guid UserCode { get; set; }
        
        public string UserName { get; set; }

        public Guid RoleCode { get; set; }
               
        public string RoleName { get; set; }
   
        public string ComputerName { get; set; }
       
        public string LoginIP { get; set; }

        public DateTime LoginDate { get; set; }
    }
}
