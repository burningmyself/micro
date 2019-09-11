using Base.District;
using Base.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace Base.Controllers
{
    [RemoteService]
    [Area("base")]
    [Route("api/base/[controller]")]
    public class DistrictController : BaseController
    {
        private readonly IDistrictAppService _districtAppService;

        public DistrictController(IDistrictAppService districtAppService)
        {
            _districtAppService = districtAppService;
        }

        /// <summary>
        /// get area data
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<PagedResultDto<DistrictDto>> GetListAsync([FromQuery]DistrictRequestResultDto input)
        {
            return await _districtAppService.GetListAsync(input);
        }
    }
}
