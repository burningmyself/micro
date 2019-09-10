
using System.ComponentModel;


namespace Unite.Result
{
    /// <summary>
    /// 结果编码
    /// </summary>
    public enum ResultCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 1000,
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Fail = 2000,
        /// <summary>
        /// 错误
        /// </summary>
        [Description("错误")]
        Error = 3000,
        /// <summary>
        /// 无数据
        /// </summary>
        [Description("无数据")]
        NotData = 4000,
        /// <summary>
        /// 超时
        /// </summary>
        [Description("超时")]
        OverTime = 5000,
        /// <summary>
        /// 系统维护
        /// </summary>
        [Description("系统维护")]
        SysFix = 6000,
        /// <summary>
        /// 不在服务时间
        /// </summary>
        [Description("不在服务时间")]
        NotTime = 7000,

        /// <summary>
        /// 验签失败
        /// </summary>
        [Description("验签失败")]
        SignFail = 9000,
    }
}
