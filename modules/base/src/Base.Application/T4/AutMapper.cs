



using System;
using AutoMapper;
using Base.Entity;

namespace Base 
{
 public partial class BaseProfile : Profile
    {
	public BaseProfile()
        {
			
	 CreateMap<DistrictEntity, District.DistrictDto>();
	 CreateMap<DistrictEntity, District.CreateDistrictDto>();
	 CreateMap<DistrictEntity, District.UpdateDistrictDto>();
	
}
}
}

