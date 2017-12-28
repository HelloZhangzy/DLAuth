using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.APP.ViewModel
{
    /// <summary>
    /// JSTree视图模型
    /// </summary>
    public class JSTreeViewModel
    {
        public string id { get; set; }
        public string parent { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
        public bool children { get; set; }
        public JSTreeState state { get; set; }     
        public string li_attr { get; set; }
        public string a_attr { get; set; }        
    }

    public class JSTreeState
    {
        public bool opened { get; set; }
        public bool disabled { get; set; }
        public bool selected { get; set; }

        public static JSTreeState Create(bool _opened = true, bool _selected = false, bool _disabled = false)
        {
            return new JSTreeState() { opened = _opened, selected = _selected, disabled = _disabled };
        }
    }

    //public static class JSTree
    //{
    //    public static string ToJsTree(this List<JSTreeViewModel> data)
    //    {
            
    //    }

    //}
}
