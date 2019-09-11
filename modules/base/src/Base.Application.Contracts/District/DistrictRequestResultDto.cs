using Base.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Base.Dto
{
    public class DistrictRequestResultDto: PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 地区码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 地区种类
        /// </summary>
        public DistrictSortEnum DistrictSort { get; set; }
    }
}
