using DreamCatcher.Domain.DreamAgg.Entities;
using DreamCatcher.Domain.SharedKernel.Entities;
using DreamCatcher.Domain.UserAgg;
using System;
using System.Collections.Generic;

namespace DreamCatcher.Domain.DreamAgg
{
    public class Dream : BaseEntity<Dream>
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public Guid IDUser { get; set; }
        public User User { get; set; }
        public IEnumerable<DreamTask> Tasks { get; set; }
    }
}
