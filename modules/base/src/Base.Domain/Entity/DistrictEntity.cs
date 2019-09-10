using Base.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Base.Entity
{
    /// <summary>
    /// 地区
    /// </summary>
    [Table("District")]
    public class DistrictEntity : Entity<Guid>
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 地区种类
        /// </summary>
        public DistrictSortEnum DistrictSort { get; set; }

    }
}
