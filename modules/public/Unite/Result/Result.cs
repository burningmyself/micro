using System;
using System.Collections.Generic;
using Unite.Extension;

namespace Unite.Result
{

    /// <summary>
    /// 结果
    /// </summary>
    public class Result<T>
    {
        /// <summary>
        /// 响应Code
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 响应信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 响应数据
        /// </summary>
        public T Details { get; set; }

        /// <summary>
        /// 自定义结果
        /// </summary>
        public Result() { }
        public Result(int code)
        {
            this.Code = code;
        }
        public Result(string msg)
        {
            this.Msg = msg;
        }
        public Result(int code, string msg)
        {
            this.Code = code;
            this.Msg = msg;
        }
    }
    /// <summary>
    /// 结果
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 响应Code
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 响应信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 响应数据
        /// </summary>
        public Dictionary<string, object> Details { get; set; }

        /// <summary>
        /// 自定义结果
        /// </summary>
        public Result() { }
        public Result(Enum code)
        {
            this.Code = Convert.ToInt32(code);
            this.Msg = EnumExtension.GetEnumDescriptionName(code);
        }
        public Result(Enum code, Enum msg)
        {
            this.Code = Convert.ToInt32(code);
            this.Msg = EnumExtension.GetEnumDescriptionName(msg);
        }
        public Result(string msg)
        {
            this.Msg = msg;
        }
        public Result(int code, string msg)
        {
            this.Code = code;
            this.Msg = msg;
        }

        public static Result Init(Enum @enum)
        {
            return new Result(@enum);
        }
        public static Result Init(Enum @enumResult, Enum @enumError)
        {
            return new Result(@enumResult, @enumError);
        }
        public static Result Success(int code = 0, string msg = null, Dictionary<string, object> property = null)
        {
            var result = new Result(code, msg);
            result.Details = property;
            return result;
        }

        public static Result Fail(int code = 0, string msg = null, Dictionary<string, object> property = null)
        {
            var result = new Result(code, msg);
            result.Details = property;
            return result;
        }

        public static Result Error(int code = 0, string msg = null, Dictionary<string, object> property = null)
        {
            var result = new Result(code, msg);
            result.Details = property;
            return result;
        }
    }
}
