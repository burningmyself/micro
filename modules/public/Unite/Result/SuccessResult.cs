using System;
using System.Collections.Generic;
using System.Text;
using Unite.Extension;
using Volo.Abp.Application.Dtos;

namespace Unite.Result
{
    public class SuccessResult : EntityDto
    {
        /// <summary>
        /// 成功编码
        /// </summary>
        public int SuccessCode { get; set; }

        /// <summary>
        /// 成功信息
        /// </summary>
        public string SuccessMsg { get; set; }

        public SuccessResult(SuccessCode code)
        {
            this.SuccessCode = (int)code;
            this.SuccessMsg = EnumExtension.GetEnumDescriptionName(code);
        }
        /// <summary>
        /// 创建错误结果
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static SuccessResult Init(SuccessCode code)
        {
            return new SuccessResult(code);
        }
    }
}
