using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace Unite.Extension
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExtension
    {


        /// <summary>
        /// 获取DescriptionName
        /// </summary>
        /// <param name="enumObj"></param>
        /// <returns></returns>
        public static string GetEnumDescriptionName(this Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                dynamic[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return (attrs[0]).Description;
                }
            }
            return en.ToString();
        }
        /// <summary>
        /// 获取displayName
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string GetEnumDisplayName(this Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DisplayAttribute)attrs[0]).Name;
                }
            }
            return en.ToString();
        }

        /// <summary>
        /// 字符串转Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T ConvertEnum<T>(this string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }
        /// <summary>
        /// 通过枚举值得到枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetValueToEnum<T>(string value)
        {
            var enumType = typeof(T);
            foreach (var obj in System.Enum.GetValues(enumType))
            {
                if (value.Equals(((int)obj).ToString()))
                {
                    return (T)obj;
                }
                if (value.Equals(obj.ToString()))
                {
                    return (T)obj;
                }
            }
            return default(T);
        }
        /// <summary>
        /// 通过枚举得到值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumToValue<T>(T enumValue)
        {
            var enumType = typeof(T);
            foreach (var obj in System.Enum.GetValues(enumType))
            {
                if (enumValue.Equals(obj))
                {
                    return obj.ToString();
                }
            }
            return default(T).ToString();
        }
        
    }
}
