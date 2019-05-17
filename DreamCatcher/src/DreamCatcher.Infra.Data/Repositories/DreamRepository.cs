using DreamCatcher.Domain.DreamAgg;
using DreamCatcher.Domain.DreamAgg.Contracts;
using System;
using System.Collections.Generic;

namespace DreamCatcher.Infra.Data.Repositories
{
    public class DreamRepository : IDreamRepository
    {
        public IEnumerable<Dream> GetByUserId(Guid id)
        {
            return new List<Dream>() { new Dream() { Id = Guid.NewGuid() } };
        }
    }
}
