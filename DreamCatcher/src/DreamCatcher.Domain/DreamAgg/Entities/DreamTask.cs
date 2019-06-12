using DreamCatcher.Domain.SharedKernel.Entities;
using System;

namespace DreamCatcher.Domain.DreamAgg.Entities
{
    public class DreamTask : BaseEntity<DreamTask>
    {
        public virtual string Title { get; set; }
        public virtual bool IsDone { get; set; }
        public virtual Dream Dream { get; set; }

        public virtual Guid IdDream { get; set; }
    }
}
