using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Sky.Models
{
    /// <summary>账单</summary>
    [Serializable]
    [DataObject]
    [Description("账单")]
    [BindTable("Bill", Description = "账单", ConnName = "Conn", DbType = DatabaseType.SqlServer)]
    public partial class Bill<TEntity> : IBill
    {
        #region 属性
        private Int32 _Id;
        /// <summary>内部编号</summary>
        [DisplayName("内部编号")]
        [Description("内部编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "内部编号", "int")]
        public Int32 Id { get { return _Id; } set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } } }

        private Int32 _UserId;
        /// <summary>关联用户Id</summary>
        [DisplayName("关联用户Id")]
        [Description("关联用户Id")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("UserId", "关联用户Id", "int", Master = true)]
        public Int32 UserId { get { return _UserId; } set { if (OnPropertyChanging(__.UserId, value)) { _UserId = value; OnPropertyChanged(__.UserId); } } }

        private DateTime _HappendTime;
        /// <summary>发生时间</summary>
        [DisplayName("发生时间")]
        [Description("发生时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("HappendTime", "发生时间", "datetime")]
        public DateTime HappendTime { get { return _HappendTime; } set { if (OnPropertyChanging(__.HappendTime, value)) { _HappendTime = value; OnPropertyChanged(__.HappendTime); } } }

        private Decimal _ChangeMoney;
        /// <summary>变动金额</summary>
        [DisplayName("变动金额")]
        [Description("变动金额")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ChangeMoney", "变动金额", "money")]
        public Decimal ChangeMoney { get { return _ChangeMoney; } set { if (OnPropertyChanging(__.ChangeMoney, value)) { _ChangeMoney = value; OnPropertyChanged(__.ChangeMoney); } } }

        private Int32 _IsDeleted;
        /// <summary>是否删除</summary>
        [DisplayName("是否删除")]
        [Description("是否删除")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("IsDeleted", "是否删除", "int")]
        public Int32 IsDeleted { get { return _IsDeleted; } set { if (OnPropertyChanging(__.IsDeleted, value)) { _IsDeleted = value; OnPropertyChanged(__.IsDeleted); } } }

        private DateTime _AddTime;
        /// <summary>添加时间</summary>
        [DisplayName("添加时间")]
        [Description("添加时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("AddTime", "添加时间", "datetime")]
        public DateTime AddTime { get { return _AddTime; } set { if (OnPropertyChanging(__.AddTime, value)) { _AddTime = value; OnPropertyChanged(__.AddTime); } } }

        private String _AddIp;
        /// <summary>添加Ip</summary>
        [DisplayName("添加Ip")]
        [Description("添加Ip")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("AddIp", "添加Ip", "nvarchar(50)")]
        public String AddIp { get { return _AddIp; } set { if (OnPropertyChanging(__.AddIp, value)) { _AddIp = value; OnPropertyChanged(__.AddIp); } } }

        private Int32 _AddUser;
        /// <summary>添加人</summary>
        [DisplayName("添加人")]
        [Description("添加人")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("AddUser", "添加人", "int")]
        public Int32 AddUser { get { return _AddUser; } set { if (OnPropertyChanging(__.AddUser, value)) { _AddUser = value; OnPropertyChanged(__.AddUser); } } }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.Id : return _Id;
                    case __.UserId : return _UserId;
                    case __.HappendTime : return _HappendTime;
                    case __.ChangeMoney : return _ChangeMoney;
                    case __.IsDeleted : return _IsDeleted;
                    case __.AddTime : return _AddTime;
                    case __.AddIp : return _AddIp;
                    case __.AddUser : return _AddUser;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt32(value); break;
                    case __.UserId : _UserId = Convert.ToInt32(value); break;
                    case __.HappendTime : _HappendTime = Convert.ToDateTime(value); break;
                    case __.ChangeMoney : _ChangeMoney = Convert.ToDecimal(value); break;
                    case __.IsDeleted : _IsDeleted = Convert.ToInt32(value); break;
                    case __.AddTime : _AddTime = Convert.ToDateTime(value); break;
                    case __.AddIp : _AddIp = Convert.ToString(value); break;
                    case __.AddUser : _AddUser = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得账单字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>内部编号</summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>关联用户Id</summary>
            public static readonly Field UserId = FindByName(__.UserId);

            /// <summary>发生时间</summary>
            public static readonly Field HappendTime = FindByName(__.HappendTime);

            /// <summary>变动金额</summary>
            public static readonly Field ChangeMoney = FindByName(__.ChangeMoney);

            /// <summary>是否删除</summary>
            public static readonly Field IsDeleted = FindByName(__.IsDeleted);

            /// <summary>添加时间</summary>
            public static readonly Field AddTime = FindByName(__.AddTime);

            /// <summary>添加Ip</summary>
            public static readonly Field AddIp = FindByName(__.AddIp);

            /// <summary>添加人</summary>
            public static readonly Field AddUser = FindByName(__.AddUser);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得账单字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>内部编号</summary>
            public const String Id = "Id";

            /// <summary>关联用户Id</summary>
            public const String UserId = "UserId";

            /// <summary>发生时间</summary>
            public const String HappendTime = "HappendTime";

            /// <summary>变动金额</summary>
            public const String ChangeMoney = "ChangeMoney";

            /// <summary>是否删除</summary>
            public const String IsDeleted = "IsDeleted";

            /// <summary>添加时间</summary>
            public const String AddTime = "AddTime";

            /// <summary>添加Ip</summary>
            public const String AddIp = "AddIp";

            /// <summary>添加人</summary>
            public const String AddUser = "AddUser";
        }
        #endregion
    }

    /// <summary>账单接口</summary>
    public partial interface IBill
    {
        #region 属性
        /// <summary>内部编号</summary>
        Int32 Id { get; set; }

        /// <summary>关联用户Id</summary>
        Int32 UserId { get; set; }

        /// <summary>发生时间</summary>
        DateTime HappendTime { get; set; }

        /// <summary>变动金额</summary>
        Decimal ChangeMoney { get; set; }

        /// <summary>是否删除</summary>
        Int32 IsDeleted { get; set; }

        /// <summary>添加时间</summary>
        DateTime AddTime { get; set; }

        /// <summary>添加Ip</summary>
        String AddIp { get; set; }

        /// <summary>添加人</summary>
        Int32 AddUser { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}