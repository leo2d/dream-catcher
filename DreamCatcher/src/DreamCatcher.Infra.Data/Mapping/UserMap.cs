using DreamCatcher.Domain.UserAgg;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace DreamCatcher.Infra.Data.Mapping
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Id(x => x.Id, y => y.Generator(Generators.Guid));

            Property(x => x.Name);
            Property(x => x.Login);
            Property(x => x.Password);

            Bag(x => x.Dreams, m =>
            {
                m.Inverse(true);
                m.Cascade(Cascade.DeleteOrphans);
                m.Lazy(CollectionLazy.Lazy);
                m.Key(k => k.Column("userId"));
            },
              o => o.OneToMany()
          );
        }
    }
}
