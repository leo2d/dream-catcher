using DreamCatcher.Domain.DreamAgg;
using DreamCatcher.Domain.DreamAgg.Contracts;
using DreamCatcher.Infra.Data.Config;
using System;
using System.Collections.Generic;

namespace DreamCatcher.Infra.Data.Repositories
{
    public class DreamRepository : RepositoryBase<Dream>, IDreamRepository
    {
        public DreamRepository(NHibernateConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public IEnumerable<Dream> GetByUserId(Guid id)
        {
            return new List<Dream>() { new Dream() { Id = Guid.NewGuid() } };
        }
    }
}
