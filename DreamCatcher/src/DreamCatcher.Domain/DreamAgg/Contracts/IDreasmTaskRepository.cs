using DreamCatcher.Domain.DreamAgg.Entities;
using DreamCatcher.Domain.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace DreamCatcher.Domain.DreamAgg.Contracts
{
    public interface IDreamTaskRepository : IRepository<DreamTask>
    {
        IEnumerable<DreamTask> GetByDreamId(Guid id);
    }
}
