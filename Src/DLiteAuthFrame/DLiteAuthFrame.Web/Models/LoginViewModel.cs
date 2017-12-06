using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLiteAuthFrame.Web.Models
{
    public class LoginViewModel
    {
        public string LoginCode { get; set; }
        public string PassWord { get; set; }
        public string CheckCode { get; set; }
    }
}