using Base.Dto;
using Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Base.District
{
    public partial class DistrictAppService
    {
        public async Task<PagedResultDto<DistrictDto>> GetListAsync(DistrictRequestResultDto input)
        {
            var list = GetQueryable();
            if (input.DistrictSort > 0)
            {
                list = list.Where(d => d.DistrictSort == input.DistrictSort);
            }
            if (!string.IsNullOrEmpty(input.Code))
            {
                list = list.Where(d => d.Code.Substring(0, input.Code.Length) == input.Code);
            }
            list = list.PageBy(input.SkipCount, input.MaxResultCount).OrderBy(d => input.Sorting ?? d.Name);
            var resultList = ObjectMapper.Map<List<DistrictEntity>, List<DistrictDto>>(list.ToList());
            return new PagedResultDto<DistrictDto>()
            {
                Items = resultList,
                TotalCount = resultList.Count()
            };
        }
    }
}
