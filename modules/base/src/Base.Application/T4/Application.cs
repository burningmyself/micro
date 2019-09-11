



using Base.Entity;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using System.Linq;

			namespace Base.District 
{
	public partial class DistrictAppService:CrudAppService<DistrictEntity, DistrictDto, Guid, PagedAndSortedResultRequestDto,
            CreateDistrictDto, UpdateDistrictDto>,
        IDistrictAppService
	{
		private readonly IRepository<DistrictEntity, Guid> _repository;
		public DistrictAppService(IRepository<DistrictEntity, Guid> repository)
            : base(repository)
        {
			_repository = repository;
        }
		public IQueryable<DistrictEntity> GetQueryable()
        {
            return _repository.AsQueryable();
        }
	}
	}






