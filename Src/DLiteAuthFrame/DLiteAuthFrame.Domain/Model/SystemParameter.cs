namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
   
    
    public partial class SystemParameter
    {
      
        public Guid ParameterCode { get; set; }
        
        public string ParameterValue { get; set; }

        public bool IsEdit { get; set; }
        
        public string Explain { get; set; }

        public Guid CreateUserCode { get; set; }

        public DateTime CreaterDate { get; set; }

        public Guid? UpdateUserCode { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
