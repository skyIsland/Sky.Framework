using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebPages;
using NewLife.IO;
using NewLife.Log;
using NewLife.Reflection;
using NewLife.Threading;
using NewLife.Web;
using XCode;
using XCode.Membership;

namespace Sky.Web
{
    /// <summary>区域注册基类</summary>
    /// <remarks>
    /// 提供以下功能：
    /// 1，。
    /// 2，静态构造注册一次视图引擎、绑定提供者、过滤器
    /// 3，注册区域默认路由
    /// </remarks>
    public abstract class AreaRegistrationBase : AreaRegistration
    {
        /// <summary>区域名称</summary>
        public override String AreaName { get; }

        /// <summary>所有区域类型</summary>
        public static Type[] Areas { get; private set; }

        /// <summary>实例化区域注册</summary>
        public AreaRegistrationBase()
        {
            AreaName = GetType().Name.TrimEnd("AreaRegistration");
        }

        static AreaRegistrationBase()
        {
            XTrace.WriteLine("{0} Start 初始化 {0}", new String('=', 32));
            Assembly.GetExecutingAssembly().WriteVersion();

            // 注册绑定提供者
            EntityModelBinderProvider.Register();

            // 注册过滤器
            XTrace.WriteLine("注册过滤器：{0}", typeof(MvcHandleErrorAttribute).FullName);
            XTrace.WriteLine("注册过滤器：{0}", typeof(EntityAuthorizeAttribute).FullName);
            var filters = GlobalFilters.Filters;
            filters.Add(new MvcHandleErrorAttribute());
            filters.Add(new EntityAuthorizeAttribute() { IsGlobal = true });

            XTrace.WriteLine("{0} End   初始化 {0}", new String('=', 32));
        }

        /// <summary>注册区域</summary>
        /// <param name="context"></param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            var ns = GetType().Namespace + ".Controllers";
            XTrace.WriteLine("开始注册权限管理区域[{0}]，控制器命名空间[{1}]", AreaName, ns);

            // 本区域默认配置
            context.MapRoute(
                AreaName,
                AreaName + "/{controller}/{action}/{id}",
                new { controller = "Index", action = "Index", id = UrlParameter.Optional },
                new[] { ns }
            );

            // 自动检查并添加菜单
            TaskEx.Run(() =>
            {
                try
                {
                    ScanController();
                }
                catch (Exception ex)
                {
                    XTrace.WriteException(ex);
                }
            });
        }

        /// <summary>自动扫描控制器，并添加到菜单</summary>
        /// <remarks>默认操作当前注册区域的下一级Controllers命名空间</remarks>
        protected virtual void ScanController()
        {
#if DEBUG
            XTrace.WriteLine("{0}.ScanController", GetType().Name.TrimEnd("AreaRegistration"));
#endif
            var mf = ManageProvider.Menu;
            if (mf == null) return;

            using (var tran = (mf as IEntityOperate).CreateTrans())
            {
                XTrace.WriteLine("初始化[{0}]的菜单体系", AreaName);
                mf.ScanController(AreaName, GetType().Assembly, GetType().Namespace + ".Controllers");

                // 更新区域名称为友好中文名
                var menu = mf.Root.FindByPath(AreaName);
                if (menu != null && menu.DisplayName.IsNullOrEmpty())
                {
                    var dis = GetType().GetDisplayName();
                    var des = GetType().GetDescription();

                    if (!dis.IsNullOrEmpty()) menu.DisplayName = dis;
                    if (!des.IsNullOrEmpty()) menu.Remark = des;

                    (menu as IEntity).Save();
                }

                tran.Commit();
            }
        }
    }
}