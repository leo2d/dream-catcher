using DreamCatcher.Domain.DreamAgg.Contracts;
using DreamCatcher.Domain.DreamAgg.Entities;
using DreamCatcher.Infra.Data.Config;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DreamCatcher.Infra.Data.Repositories
{
    public class DreamTaskRepository : RepositoryBase<DreamTask>, IDreamTaskRepository
    {
        public DreamTaskRepository(NHibernateConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public IEnumerable<DreamTask> GetByDreamId(Guid id)
        {
            var result = Session.Query<DreamTask>()
               .Where(x => x.IdDream.Equals(id));

            return result;
        }
    }
}
