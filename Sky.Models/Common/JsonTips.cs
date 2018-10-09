using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sky.Models
{
    /// <summary>
    /// JSON 返回
    /// </summary>
    public class JsonTips
    {
        /// <summary>
        ///  操作结果代码
        /// </summary>
        public bool Result { get; set; } = false;
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 跳转链接
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}