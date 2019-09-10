using System;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Base.Entity
{
    [Table("BaseItem")]
    public class BaseItemEntity:Entity<Guid>
    {
        public BaseItemEntity()
        {
        }

        public BaseItemEntity(Guid baseTypeGuid, string code, string name)
        {
            BaseTypeGuid = baseTypeGuid;
            Code = code ?? throw new ArgumentNullException(nameof(code));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        [NotNull]
        public Guid BaseTypeGuid { get; set; }
        [NotNull]
        public string Code { get; set; }
        [NotNull]
        public string Name { get; set; }

        public int Sort { get; set; }

        public string Remark { get; set; }

        public virtual BaseTypeEntity BaseType { get; set; }
    }
}
