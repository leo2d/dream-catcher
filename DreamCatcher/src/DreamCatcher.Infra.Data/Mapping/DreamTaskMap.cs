using DreamCatcher.Domain.DreamAgg.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamCatcher.Infra.Data.Mapping
{
    public class DreamTaskMap : ClassMapping<DreamTask>
    {
        public DreamTaskMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));

            Property(x => x.Title);
            Property(x => x.IsDone, m => m.Column(c => c.Default(0)));
            Property(x => x.IdDream);

            ManyToOne(x => x.Dream, m =>
            {
                m.Column("dreamId");
            });

        }
    }
}
