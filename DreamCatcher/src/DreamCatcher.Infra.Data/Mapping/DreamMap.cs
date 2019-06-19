using DreamCatcher.Domain.DreamAgg;
using DreamCatcher.Domain.UserAgg;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamCatcher.Infra.Data.Mapping
{
    public class DreamMap : ClassMapping<Dream>
    {
        public DreamMap()
        {
            Id(x => x.Id, y => y.Generator(Generators.Guid));

            Property(x => x.IsDone, m => m.Column(c => c.Default(0)));
            Property(x => x.IDUser);
            Property(x => x.RegisterDate);
            Property(x => x.Title);

            ManyToOne<User>(x => x.User, m =>
            {
                m.Column("userId");
            });

            Bag(x => x.Tasks, m =>
            {
                m.Inverse(true);
                m.Cascade(Cascade.DeleteOrphans);
                m.Lazy(CollectionLazy.Lazy);
                m.Key(k => k.Column("dreamId"));
            },
               o => o.OneToMany()
           );
        }

    }
}
