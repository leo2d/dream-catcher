using DreamCatcher.Domain.DreamAgg.Entities;
using DreamCatcher.Domain.SharedKernel.Entities;
using DreamCatcher.Domain.UserAgg;
using System;
using System.Collections.Generic;

namespace DreamCatcher.Domain.DreamAgg
{
    public class Dream : BaseEntity<Dream>
    {
        public Dream()
        {
            Tasks = new List<DreamTask>();
        }

        public virtual string Title { get; set; }
        public virtual bool IsDone { get; set; }
        public virtual DateTime RegisterDate { get; set; }

        public virtual Guid IDUser { get; set; }
        public virtual User User { get; set; }

        public virtual IList<DreamTask> Tasks { get; set; }
    }
}
