using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Enum
{
    /// <summary>
    /// 地区种类
    /// </summary>
    public enum DistrictSortEnum:byte
    {
        /// <summary>
        /// 省
        /// </summary>
        Province = 1,
        /// <summary>
        /// 市
        /// </summary>
        City = 2,
        /// <summary>
        /// 区/县
        /// </summary>
        Area = 3,
        /// <summary>
        /// 街/乡
        /// </summary>
        Street = 4,
        /// <summary>
        /// 村
        /// </summary>
        Village = 5,
    }
}
