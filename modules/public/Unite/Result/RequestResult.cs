using System;
using System.Collections.Generic;
using System.Text;

namespace Unite.Result
{
    [Serializable]
    public class RequestResult
    {
        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string MerchantNo { get; set; }
    }
}
