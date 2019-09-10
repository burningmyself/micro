using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Unite
{
    public class MD5Sign
    {

        /// <summary>
        /// 校验签名
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="sign">签名</param>
        /// <returns></returns>
        public static bool CheckSign(object model, string sign, string api_secret)
        {
            SortedDictionary<string, string> signParams = new SortedDictionary<string, string>(StringComparer.Ordinal);
            var keyValueTo = ToMap(model);
            foreach (var p in keyValueTo)
            {
                if (p.Key != "Sign" && p.Key != "Signlen" && p.Key != "Img")
                {
                    signParams[p.Key] = p.Value;
                }
            }
            StringBuilder paramStr = new StringBuilder();
            foreach (var item in signParams)
            {
                if (!string.IsNullOrWhiteSpace(item.Value))
                {
                    paramStr.AppendFormat("{0}={1}&", item.Key, item.Value);
                }
            }
            paramStr.AppendFormat("Key={0}", api_secret);
            string computeSign = GetMd5Hash(paramStr.ToString()).ToUpper();
            return string.Equals(sign, computeSign);
        }
        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public static string GetSign(object model, string api_secret)
        {
            SortedDictionary<string, string> signParams = new SortedDictionary<string, string>(StringComparer.Ordinal);
            var keyValueTo = ToMap(model);
            foreach (var p in keyValueTo)
            {
                if (p.Key != "Sign" && p.Key != "Signlen" && p.Key != "Img")
                {
                    signParams[p.Key] = p.Value;
                }
            }
            StringBuilder paramStr = new StringBuilder();
            foreach (var item in signParams)
            {
                if (!string.IsNullOrWhiteSpace(item.Value))
                {
                    paramStr.AppendFormat("{0}={1}&", item.Key, item.Value);
                }
            }
            paramStr.AppendFormat("Key={0}", api_secret);
            string computeSign = GetMd5Hash(paramStr.ToString()).ToUpper();
            return computeSign;
        }

        /// <summary>  
        /// 将对象属性转换为key-value对  
        /// </summary>  
        /// <param name="o"></param>  
        /// <returns></returns>  
        private static Dictionary<String, String> ToMap(Object o)
        {
            Dictionary<String, String> map = new Dictionary<String, String>();

            Type t = o.GetType();

            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo p in pi)
            {
                MethodInfo mi = p.GetGetMethod();

                if (mi != null && mi.IsPublic)
                {
                    map.Add(p.Name, mi.Invoke(o, new String[] { }).ToString());
                }
            }

            return map;

        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">字符串</param>
        /// <returns></returns>
        public static string GetMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

    }
}
