using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.APP.ViewModel
{
    public class TreeViewModel
    {
        public TreeViewModel()
        {
            Node = new List<TreeViewModel>();
        }
        public Guid? ParentId { get; set; }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<TreeViewModel> Node { get; set; }
    }
}
