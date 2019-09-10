using System;
using System.Collections.Generic;
using System.Text;
using Unite.Extension;

namespace Unite.Result
{
    /// <summary>
    /// 失败结果
    /// </summary>
    public class FailResult
    {
        /// <summary>
        /// 失败编码
        /// </summary>
        public int FailCode { get; set; }
        /// <summary>
        /// 失败信息
        /// </summary>
        public string FailMsg { get; set; }
        public FailResult(FailCode code)
        {
            this.FailCode = (int)code;
            this.FailMsg = EnumExtension.GetEnumDescriptionName(code);
        }
        /// <summary>
        /// 创建错误结果
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static FailResult Init(FailCode code)
        {
            return new FailResult(code);
        }
    }
}
