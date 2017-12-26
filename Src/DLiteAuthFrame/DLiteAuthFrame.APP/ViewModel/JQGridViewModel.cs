using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.APP.ViewModel
{
    public class JQGridViewModel
    {
        public Guid id { get; set; }
        public Guid parent { get; set; }
        public bool isLeaf { get; set; }
        public bool expanded { get; set; }
        public bool loaded { get; set; }
        public int level { get; set; }
    }
}
