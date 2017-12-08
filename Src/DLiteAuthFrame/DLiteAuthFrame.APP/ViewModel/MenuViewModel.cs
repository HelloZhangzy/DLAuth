using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.APP.ViewModel
{
    public class MenuViewModel
    {
        public MenuViewModel()
        {
            Node = new List<MenuViewModel>();
        }
        public Guid? ParentId { get; set; }
        public Guid ID { get; set; }
        public  string Name { get; set; }
        public string URL { get; set; }
        public  string ICO { get; set; }
        public bool isNode
        {
            get
            {
                if (Node.Count()>0) return true;
                return false;
            }
        }
        public List<MenuViewModel> Node { get; set; }
    }
}
