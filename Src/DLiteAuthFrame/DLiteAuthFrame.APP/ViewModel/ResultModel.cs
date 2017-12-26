using DLiteAuthFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLiteAuthFrame.APP.ViewModel
{
    public class ResultModel
    {
        /// <summary>
        /// 操作结果类型
        /// </summary>
        public object state { get; set; }
        /// <summary>
        /// 获取 消息内容
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 跳转地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object data { get; set; }

        public static ResultModel success(string _msg,string _url="",object _data=null)
        {
            return new ResultModel { state = ResultType.success.ToString(), message = _msg, Url = _url, data = _data };
        }
        public static ResultModel info(string _msg, string _url = "", object _data = null)
        {
            return new ResultModel { state = ResultType.info.ToString(), message = _msg, Url = _url, data = _data };
        }
        public static ResultModel warning(string _msg, string _url = "", object _data = null)
        {
            return new ResultModel { state = ResultType.warning.ToString(), message = _msg, Url = _url, data = _data };
        }
        public static ResultModel error(string _msg, string _url = "", object _data = null)
        {
            return new ResultModel { state = ResultType.error.ToString(), message = _msg, Url = _url, data = _data };
        }
    }    
}
