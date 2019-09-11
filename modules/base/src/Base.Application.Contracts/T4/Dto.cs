


using System;
using Volo.Abp.Application.Dtos;
	namespace Base.District
{
public  partial class DistrictDto: EntityDto<Guid>
{
	public virtual Guid Id { get; set; }
	public virtual string Code { get; set; }
	public virtual string Name { get; set; }
	public virtual byte DistrictSort { get; set; }
}
}

