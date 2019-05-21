using DreamCatcher.Domain.SharedKernel.Entities;
using System;

namespace DreamCatcher.Domain.DreamAgg.Entities
{
    public class DreamTask : BaseEntity<DreamTask>
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public Dream Dream { get; set; }

        public Guid IdDream { get; set; }
    }
}
