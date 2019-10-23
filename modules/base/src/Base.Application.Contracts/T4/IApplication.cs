




using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using System.Linq;

			namespace Base.District
{
	public partial interface IDistrictAppService:ICrudAppService<DistrictDto, Guid, PagedAndSortedResultRequestDto,
            CreateDistrictDto, UpdateDistrictDto>
	{

	}

}




