using Base.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Base.District
{
    public partial interface IDistrictAppService
    {
        Task<PagedResultDto<DistrictDto>> GetListAsync(DistrictRequestResultDto input);
    }
}
