using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Base.Entity
{
    [Table("BaseType")]
    public class BaseTypeEntity : Entity<Guid>
    {
        public BaseTypeEntity()
        {
        }

        public BaseTypeEntity(string code, string name)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public Guid? ParentId { get; set; }
        [NotNull]
        public string Code { get; set; }
        [NotNull]
        public string Name { get; set; }
        public int Sort { get; set; }
        public string Remark { get; set; }

        public virtual ICollection<BaseItemEntity> BaseItems { get; set; }
    }
}
