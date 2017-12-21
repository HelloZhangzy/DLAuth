using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.APP.ViewModel
{
    public class UserViewModel
    {
        public Guid UserCode { get; set; }

        public string UserName { get; set; }

        public string UserExplain { get; set; }

        public int Sex { get; set; }

        public string LoginCode { get; set; }

        public string LoginPass { get; set; }

        public bool ibState { get; set; }

        public int LoginCount { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public Guid? CreateUserCode { get; set; }

        public DateTime? CreaterDate { get; set; }

        public Guid? UpdateUserCode { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
