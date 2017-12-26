using DLiteAuthFrame.APP.APP;
using DLiteAuthFrame.APP.IApp;
using DLiteAuthFrame.Common;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DLiteAuthFrame.MVC.Attribute
{
    /// <summary>
    /// 权限验证
    /// </summary>
    public class AuthAttribute: ActionFilterAttribute
    {
        public IAuthManageApp Auth { get; set; }
        
        public ILog log { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            log.Debug("AuthAttribute start");
            if (!CheckLogin())
            {
                //filterContext.HttpContext.Response.Write("<script>top.location.href = '/Account/Login';</script>");
                //filterContext.HttpContext.Response.Write("<script>top.location.href = '/Account/Login';</script>");

                ContentResult Content = new ContentResult();
                Content.Content = "<script type='text/javascript'>top.location.href = '/Account/Login';</script>";
                filterContext.Result = Content;

            }
            else
            {
                if (!Auth.CheckAuth())
                {
                    ContentResult Content = new ContentResult();
                    Content.Content = "<script type='text/javascript'>layui.layer.msg('您无该权限');</script>";
                    filterContext.Result = Content;
                }
            }
            log.Debug("AuthAttribute end");
        }

        /// <summary>
        /// 验证是否登录
        /// </summary>
        /// <returns></returns>
        private bool CheckLogin()
        {
            if (string.IsNullOrWhiteSpace(DLSession.GetCurrLoginCode())) return false;
            return true;
            
        }
        
    }
}