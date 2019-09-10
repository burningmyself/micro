using System;
using System.Collections.Generic;
using System.Text;
using Unite.Extension;
using Volo.Abp.Application.Dtos;

namespace Unite.Result
{
    /// <summary>
    /// 错误结果
    /// </summary>
    public class ErrorResult : EntityDto
    {
        /// <summary>
        /// 错误编码
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg { get; set; }
        public ErrorResult(ErrorCode code)
        {
            this.ErrorCode = (int)code;
            this.ErrorMsg = EnumExtension.GetEnumDescriptionName(code);
        }
        /// <summary>
        /// 创建错误结果
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ErrorResult Init(ErrorCode code)
        {
            return new ErrorResult(code);
        }
    }
}
