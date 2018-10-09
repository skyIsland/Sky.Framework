using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Sky.Models;

namespace Sky.AppWebApi
{
    /// <summary>拦截错误的特性</summary>
    public class MvcHandleErrorAttribute : HandleErrorAttribute
    {
        /// <summary>拦截异常</summary>
        /// <param name="ctx"></param>
        public override void OnException(ExceptionContext ctx)
        {
            NewLife.Log.XTrace.WriteException(ctx.Exception);
            var context = ctx;

            //获取当前的请求对象
            var request = context.RequestContext.HttpContext.Request;

            //如果请求方式为AJax，将返回Json格式数据
            if (request.IsAjaxRequest())
            {
                var result = new JsonResult
                {
                    Data = new JsonTips{ Result = false, Message = "服务器发生异常，请稍候再试或联系管理员" }
                    //ContentEncoding = System.Text.Encoding.UTF8,
                    //ContentType = "text/plain"
                };
                if (request.HttpMethod.ToUpper() == "GET")
                    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

                context.Result = result;
            }
            else context.Result = new RedirectResult("/500");

            //设置为已处理
            context.ExceptionHandled = true;
            base.OnException(context);

            base.OnException(ctx);
        }
    }
}