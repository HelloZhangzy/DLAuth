using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.APP.ViewModel
{
    public class MenuViewModel: JQGridViewModel
    {
        public Guid MenuCode { get; set; }
        public Guid ParentMenuCode { get; set; }
        public int SortNo { get; set; }
        public string MenuName { get; set; }
        public string MenuExplain { get; set; }
        public string Url { get; set; }
        public string Ico { get; set; }
        public bool IsVisible { get; set; }
        public bool IsEnable { get; set; }
        public Guid CreateUserCode { get; set; }
        public DateTime CreaterDate { get; set; }
        public Guid? UpdateUserCode { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
