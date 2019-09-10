using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Unite.Generate
{
    public static class GenerateHelper
    {
        const int MerchnatNoLength = 8;
        const int OrderNoLength = 20;
        /// <summary>
        /// 生成商户号
        /// </summary>
        /// <param name="length">1-14</param>
        /// <returns></returns>
        public static string MerchantNo(int length = MerchnatNoLength)
        {
            if (MerchnatNoLength < 1 && MerchnatNoLength > 14)
            {
                throw new ArgumentException("1^14");
            }
            return DateTime.Now.ToString("yyyyMMddHHmmssff").Substring(2, length);
        }

        public static string OrderNo(int length = OrderNoLength)
        {
            if (OrderNoLength < 1)
            {
                throw new ArgumentException("Length greater than zero");
            }
            string orderNo = DateTime.Now.ToString("yyyyMMddHHmmssff");
            var differ = length - orderNo.Length;
            if (differ == 0)
            {
                return orderNo;
            }
            if (differ < 0 && length > 0)
            {
                return orderNo.Substring(0, orderNo.Length - length);
            }
            if (differ > 0)
            {
                RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();
                byte[] byteCsp = new byte[differ];
                csp.GetBytes(byteCsp);
                orderNo = orderNo + BitConverter.ToString(byteCsp);
                return orderNo;
            }
            else
            {
                RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();
                byte[] byteCsp = new byte[length];
                csp.GetBytes(byteCsp);
                return BitConverter.ToString(byteCsp);
            }
        }

        public static string OrderNo(string prefix = null, int length = OrderNoLength)
        {
            if (length < 1)
            {
                throw new ArgumentException("Length greater than zero");
            }
            string orderNo = DateTime.Now.ToString("yyyyMMddHHmmssff");
            if (!string.IsNullOrEmpty(prefix))
            {
                orderNo = prefix + orderNo;
            }
            var differ = length - orderNo.Length;
            if (differ == 0)
            {
                return orderNo;
            }
            if (differ < 0 && length > 0)
            {
                return orderNo.Substring(0, orderNo.Length - length);
            }
            if (differ > 0)
            {
                RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();
                byte[] byteCsp = new byte[differ];
                csp.GetBytes(byteCsp);
                orderNo = orderNo + BitConverter.ToString(byteCsp);
                return orderNo;
            }
            else
            {
                RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();
                byte[] byteCsp = new byte[length];
                csp.GetBytes(byteCsp);
                return BitConverter.ToString(byteCsp);
            }
        }
        /// <summary>
        /// 生成密钥
        /// </summary>
        /// <param name="length">自定义长度</param>
        /// <param name="letter">字母是否是大小写，默认小写</param>
        /// <returns></returns>
        public static string SecretKey(int length , bool letter = true)
        {
            RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();
            byte[] byteCsp = new byte[length / 2];
            csp.GetBytes(byteCsp);
            var secretKey = BitConverter.ToString(byteCsp).Replace("-", "").Substring(0, length);
            if (letter)
            {
                secretKey = secretKey.ToLower();
            }
            return secretKey;
        }
        /// <summary>
        /// 生成32密钥
        /// </summary>
        /// <param name="letter">字母是否是大小写，默认小写</param>
        /// <returns></returns>
        public static string SecretKey(bool letter = true)
        {
            var secretKey = Guid.NewGuid().ToString("N");
            if (true)
            {
                secretKey = secretKey.ToLower();
            }
            return secretKey;
        }
    }
}
