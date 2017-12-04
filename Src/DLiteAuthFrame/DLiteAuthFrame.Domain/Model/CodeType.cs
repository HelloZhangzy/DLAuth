namespace DLiteAuthFrame.Domain.Model
{
    using System;
    using System.Collections.Generic;
   
    public partial class CodeType
    {       
        public CodeType()
        {
            Code = new HashSet<Code>();
        }
        public Guid TypeCode { get; set; }
        public int? TypeOrder { get; set; }
        public string TypeName { get; set; }
        public string TypeExplain { get; set; }
        public Guid CreateUserCode { get; set; }
        public DateTime CreaterDate { get; set; }
        public Guid? UpdateUserCode { get; set; }
        public DateTime? UpdateDate { get; set; }        
        public virtual ICollection<Code> Code { get; set; }
    }
}
