using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XCode.Membership;

namespace Sky.Web.Areas.Admin.Controllers
{
    /// <summary>用户控制器</summary>
    [DisplayName("用户")]
    [Description("系统基于角色授权，每个角色对不同的功能模块具备添删改查以及自定义权限等多种权限设定。")]
    public class UserController : EntityController<UserX>
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }
    }
}