using DreamCatcher.Domain.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;

namespace DreamCatcher.Domain.DreamAgg.Contracts
{
    public interface IDreamRepository : IRepository<Dream>
    {
        IEnumerable<Dream> GetByUserId(Guid id);
    }
}
