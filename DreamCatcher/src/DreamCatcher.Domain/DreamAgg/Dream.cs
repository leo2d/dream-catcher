using DreamCatcher.Domain.DreamAgg.Entities;
using DreamCatcher.Domain.SharedKernel.Entities;
using DreamCatcher.Domain.UserAgg;
using System;
using System.Collections.Generic;

namespace DreamCatcher.Domain.DreamAgg
{
    public class Dream : BaseEntity<Dream>
    {
        public virtual string Title { get; set; }
        public virtual bool IsDone { get; set; }

        public virtual Guid IDUser { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<DreamTask> Tasks { get; set; }
    }
}
