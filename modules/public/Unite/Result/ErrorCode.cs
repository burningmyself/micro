using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Unite.Extension;

namespace Unite.Result
{
    //public class EnumCode
    //{
    //    const string Code = "Code";
    //    const string Msg = "Msg";
    //    public static Dictionary<string, object> KeyValues(Enum @enum)
    //    {
    //        Dictionary<string, object> keyValues = new Dictionary<string, object>();
    //        keyValues.Add(Code, @enum);
    //        keyValues.Add(Msg, EnumExtension.GetEnumDescriptionName(@enum));
    //        return keyValues;
    //    }
    //}
    public enum ErrorCode
    {
        /// <summary>
        /// 错误
        /// </summary>
        Error = 3000,
        /// <summary>
        /// 存在
        /// </summary>
        [Description("以存在")]
        Exist = 3001,
        /// <summary>
        /// 不存在
        /// </summary>
        [Description("不存在")]
        NotExist = 3002,
        /// <summary>
        /// 已初始化
        /// </summary>
        [Description("已初始化")]
        Init = 3003,
        /// <summary>
        /// 未初始化
        /// </summary>
        [Description("未初始化")]
        NotInit = 3004,
        /// <summary>
        /// 不足够
        /// </summary>
        [Description("不足够")]
        NotEnough = 3005,
        /// <summary>
        /// 未设置
        /// </summary>
        [Description("未设置")]
        NotSet = 3006,

        /// <summary>
        /// 商户无效
        /// </summary>
        [Description("商户无效")]
        MerchantInvalid = 3007,
        /// <summary>
        /// 参数错误
        /// </summary>
        [Description("参数错误")]
        ArgError = 3008,
    }
}
