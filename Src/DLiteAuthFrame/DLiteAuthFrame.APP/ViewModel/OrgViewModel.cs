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

        #region jqGrid Tree 关键参数
        public int level { get; set; }

        public int parent { get; set; }

        public bool isLeaf { get; set; }

        public bool expanded { get; set; }

        public bool loaded { get { return true; } }

        public string icon_field { get { return ""; } }
        #endregion
    }
}
