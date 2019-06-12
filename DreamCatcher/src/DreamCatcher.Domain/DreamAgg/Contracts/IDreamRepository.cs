using System;
using System.Collections.Generic;

namespace DreamCatcher.Domain.DreamAgg.Contracts
{
    public interface IDreamRepository
    {
        IEnumerable<Dream> GetByUserId(Guid id);
        void Delete(Dream dream);
        Dream GetById(Guid id);
    }
}
