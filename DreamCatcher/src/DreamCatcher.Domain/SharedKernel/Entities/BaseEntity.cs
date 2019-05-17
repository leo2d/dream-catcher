using System;

namespace DreamCatcher.Domain.SharedKernel.Entities
{
    public abstract class BaseEntity<T>
    {
        public Guid Id { get; set; }
    }
}
