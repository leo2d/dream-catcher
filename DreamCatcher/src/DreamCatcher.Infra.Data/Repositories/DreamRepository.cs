using DreamCatcher.Domain.DreamAgg;
using DreamCatcher.Domain.DreamAgg.Contracts;
using DreamCatcher.Infra.Data.Config;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DreamCatcher.Infra.Data.Repositories
{
    public class DreamRepository : RepositoryBase<Dream>, IDreamRepository
    {
        public DreamRepository(NHibernateConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public IEnumerable<Dream> GetByUserId(Guid id)
        {
            var result = Session.Query<Dream>()
                .Where(x => x.IDUser.Equals(id));

            return result;
        }
    }
}
