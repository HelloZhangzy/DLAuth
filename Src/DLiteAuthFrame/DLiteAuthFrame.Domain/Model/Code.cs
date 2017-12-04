namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
   
    public partial class Code
    {      
        public Guid ID { get; set; }
        public Guid ParentCode { get; set; }
        public Guid TypeCode { get; set; }
        public string TypeName { get; set; }
        public int SortNo { get; set; }       
        public string EnValue { get; set; }
        public string ZhValue { get; set; }
        public bool IsEnable { get; set; }    
        public string CodeExplain { get; set; }
        public Guid CreateUserCode { get; set; }
        public DateTime CreaterDate { get; set; }
        public Guid? UpdateUserCode { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual CodeType CodeType { get; set; }
    }
}
