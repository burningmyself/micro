using Unite.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unite.Result
{
    /// <summary>
    /// 结果处理个工具
    /// </summary>
    public class ResultUtil<T>
    {

        /// <summary>
        /// 请求成功无返回值
        /// </summary>
        /// <returns></returns>
        public static Result<T> Success()
        {
            T obj = default(T);
            return Success(obj);
        }
        /// <summary>
        /// 请求成功
        /// </summary>
        /// <param name="obj">返回的数据</param>
        /// <returns></returns>
        public static Result<T> Success(T obj)
        {
            Result<T> result = new Result<T>();
            result.Code = (int)ResultCode.Success;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.Success);
            result.Details = obj;
            return result;
        }
        /// <summary>
        /// 请求失败
        /// </summary>
        /// <returns></returns>
        public static Result<T> Fail()
        {
            T obj = default(T);
            return Fail(obj);
        }
        /// <summary>
        /// 请求失败
        /// </summary>
        /// <param name="obj">返回的数据</param>
        /// <returns></returns>
        public static Result<T> Fail(T obj)
        {
            Result<T> result = new Result<T>();
            result.Code = (int)ResultCode.Fail;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.Fail);
            result.Details = obj;
            return result;
        }
        /// <summary>
        /// 请求错误
        /// </summary>
        /// <returns></returns>
        public static Result<T> Error()
        {
            T obj = default(T);
            return Error(obj);
        }
        /// <summary>
        /// 请求错误
        /// </summary>
        /// <param name="obj">返回的数据</param>
        /// <returns></returns>
        public static Result<T> Error(T obj)
        {
            Result<T> result = new Result<T>();
            result.Code = (int)ResultCode.Error;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.Error);
            result.Details = obj;
            return result;
        }
        /// <summary>
        /// 请求无数据
        /// </summary>
        /// <returns></returns>
        public static Result<T> NotData()
        {
            T obj = default(T);
            return NotData(obj);
        }
        /// <summary>
        /// 请求无数据
        /// </summary>
        /// <param name="obj">
        /// <param name="obj">返回的数据</param>
        /// <returns></returns>
        public static Result<T> NotData(T obj)
        {
            Result<T> result = new Result<T>();
            result.Code = (int)ResultCode.NotData;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.NotData);
            result.Details = obj;
            return result;
        }
        /// <summary>
        /// 超时
        /// </summary>
        /// <returns></returns>
        public static Result<T> OverTime()
        {
            T obj = default(T);
            return OverTime(obj);
        }
        /// <summary>
        /// 超时
        /// </summary>
        /// <param name="obj">返回的数据</param>
        /// <returns></returns>
        public static Result<T> OverTime(T obj)
        {
            Result<T> result = new Result<T>();
            result.Code = (int)ResultCode.OverTime;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.OverTime);
            result.Details = obj;
            return result;
        }

        /// <summary>
        /// 系统维护
        /// </summary>
        /// <returns></returns>
        public static Result<T> SysFix()
        {
            T obj = default(T);
            return SysFix(obj);
        }
        /// <summary>
        /// 系统维护
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Result<T> SysFix(T obj)
        {
            Result<T> result = new Result<T>();
            result.Code = (int)ResultCode.SysFix;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.SysFix);
            result.Details = obj;
            return result;
        }


        /// <summary>
        /// 不在服务时间
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Result<T> NotTime(T obj)
        {
            Result<T> result = new Result<T>();
            result.Code = (int)ResultCode.SysFix;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.NotTime);
            result.Details = obj;
            return result;
        }

    }

    public class ResultUtil
    {

        /// <summary>
        /// 请求成功
        /// </summary>
        /// <param name="obj">返回的数据</param>
        /// <returns></returns>
        public static Result Success(Dictionary<string, object> keyValues = null)
        {
            Result result = new Result();
            result.Code = (int)ResultCode.Success;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.Success);
            result.Details = keyValues;
            return result;
        }

        /// <summary>
        /// 请求失败
        /// </summary>
        /// <param name="obj">返回的数据</param>
        /// <returns></returns>
        public static Result Fail(Dictionary<string, object> keyValues = null)
        {
            Result result = new Result();
            result.Code = (int)ResultCode.Fail;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.Fail);
            result.Details = keyValues;
            return result;
        }

        /// <summary>
        /// 请求错误
        /// </summary>
        /// <param name="obj">返回的数据</param>
        /// <returns></returns>
        public static Result Error(Dictionary<string, object> keyValues = null)
        {
            Result result = new Result();
            result.Code = (int)ResultCode.Error;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.Error);
            result.Details = keyValues;
            return result;
        }
        /// <summary>
        /// 请求错误
        /// </summary>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        public static Result Error(ErrorCode errorCode)
        {
            Result result = new Result();
            result.Code = (int)ResultCode.Error;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.Error);
            result.Details = KeyValues(errorCode);
            return result;
        }
        const string ErrorCode = "ErrorCode";
        const string ErrorMsg = "ErrorMsg";
        public static Dictionary<string, object> KeyValues(Enum @enum)
        {
            Dictionary<string, object> keyValues = new Dictionary<string, object>();
            keyValues.Add(ErrorCode, @enum);
            keyValues.Add(ErrorMsg, EnumExtension.GetEnumDescriptionName(@enum));
            return keyValues;
        }

        /// <summary>
        /// 请求无数据
        /// </summary>
        /// <param name="obj">
        /// <param name="obj">返回的数据</param>
        /// <returns></returns>
        public static Result NotData(Dictionary<string, object> keyValues = null)
        {
            Result result = new Result();
            result.Code = (int)ResultCode.NotData;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.NotData);
            result.Details = keyValues;
            return result;
        }

        /// <summary>
        /// 超时
        /// </summary>
        /// <param name="obj">返回的数据</param>
        /// <returns></returns>
        public static Result OverTime(Dictionary<string, object> keyValues = null)
        {
            Result result = new Result();
            result.Code = (int)ResultCode.OverTime;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.OverTime);
            result.Details = keyValues;
            return result;
        }

        /// <summary>
        /// 系统维护
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Result SysFix(Dictionary<string, object> keyValues = null)
        {
            Result result = new Result();
            result.Code = (int)ResultCode.SysFix;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.SysFix);
            result.Details = keyValues;
            return result;
        }


        /// <summary>
        /// 不在服务时间
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Result NotTime(Dictionary<string, object> keyValues = null)
        {
            Result result = new Result();
            result.Code = (int)ResultCode.NotTime;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.NotTime);
            result.Details = keyValues;
            return result;
        }

        /// <summary>
        /// 签名失败
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Result SignFail(Dictionary<string, object> keyValues = null)
        {
            Result result = new Result();
            result.Code = (int)ResultCode.SignFail;
            result.Msg = EnumExtension.GetEnumDescriptionName(ResultCode.SignFail);
            result.Details = keyValues;
            return result;
        }
    }
}
