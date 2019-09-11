


using System;
	namespace Base.District
{
public  partial class UpdateDistrictDto
{
	public virtual Guid Id { get; set; }
	public virtual string Code { get; set; }
	public virtual string Name { get; set; }
	public virtual byte DistrictSort { get; set; }
}
}

