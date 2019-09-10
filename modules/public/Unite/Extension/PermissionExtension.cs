using System;
using System.Collections.Generic;
using System.Text;

namespace Unite.Extension
{
    /// <summary>
    /// 权限扩展,定义常用操作码
    /// </summary>
    public abstract class PermissionExtension
    {
        public abstract string Default { get; set; }
        public abstract string Delete { get; set; }
        public abstract string Update { get; set; }
        public abstract string Create { get; set; }
        public abstract string Get { get; set; }
        public abstract string GetList { get; set; }
    }
    /// <summary>
    /// 定义常用操作码
    /// </summary>
    public static class Permission
    {
        /// <summary>
        /// 删除
        /// </summary>
        public const string Delete = "Delete";
        /// <summary>
        /// 更新
        /// </summary>
        public const string Update = "Update";
        /// <summary>
        /// 创建
        /// </summary>
        public const string Create = "Create";
        /// <summary>
        /// 获取
        /// </summary>
        public const string Get = "Get";
        /// <summary>
        /// 查询列表
        /// </summary>
        public const string GetList = "GetList";
    }
}
