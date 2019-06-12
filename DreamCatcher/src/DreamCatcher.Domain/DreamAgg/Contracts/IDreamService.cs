using System;
using System.Collections.Generic;

namespace DreamCatcher.Domain.DreamAgg.Contracts
{
    public interface IDreamService
    {
        string GetTest();
        IEnumerable<Dream> GetByUserId(Guid id);
        void Delete(Guid Id);
    }
}
