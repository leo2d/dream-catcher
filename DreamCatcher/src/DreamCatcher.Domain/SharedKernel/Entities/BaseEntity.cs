using System;

namespace DreamCatcher.Domain.SharedKernel.Entities
{
    public abstract class BaseEntity<T>
    {
        public virtual Guid Id { get; set; }
    }
}
