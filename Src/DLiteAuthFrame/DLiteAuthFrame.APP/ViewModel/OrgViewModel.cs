using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.APP.ViewModel
{
    public class OrgViewModel
    {    
        public Guid OrgCode { get; set; }

        public Guid ParentCode { get; set; }

        public string OrgName { get; set; }

        public string OrgExplain { get; set; }

        public Guid CreateUserCode { get; set; }

        public DateTime CreaterDate { get; set; }

        public Guid? UpdateUserCode { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
