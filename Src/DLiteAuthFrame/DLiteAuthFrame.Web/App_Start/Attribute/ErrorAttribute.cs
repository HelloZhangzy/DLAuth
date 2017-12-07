using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLiteAuthFrame.Web.App_Start.Attribute
{
    public class ErrorAttribute : ActionFilterAttribute, IExceptionFilter
    {
        public ILog log { get; set; }
        /// <summary>
        /// 全局异常处理
        /// </summary>        
        public void OnException(ExceptionContext filterContext)
        {
            //获取异常信息，入库保存
            Exception Error = filterContext.Exception;
            string Message = Error.Message;//错误信息
            string Url = HttpContext.Current.Request.RawUrl;//错误发生地址
            log.Error("Url==>"+Url);
            log.Error("Message==>" + Message);

            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/Error/Show/");//跳转至错误提示页面
        }
    }
} 