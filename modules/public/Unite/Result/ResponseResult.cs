using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace Unite.Result
{
    [Serializable]
    public class ResponseResult
    {
        public ResponseResult(string merchantNo, string sign, string code, string msg, string details)
        {
            MerchantNo = merchantNo;
            Sign = sign;
            Code = code;
            Msg = msg;
            Details = details;
        }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string MerchantNo { get; set; }

        public string Msg { get; set; }

        public string Code { get; set; }

        public string Details { get; set; }
    }
}
