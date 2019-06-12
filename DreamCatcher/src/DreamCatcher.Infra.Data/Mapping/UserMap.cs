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
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Id(x => x.Id, y => y.Generator(Generators.Guid));

            Property(x => x.Name);
            Property(x => x.Login);
            Property(x => x.Password);

        }
    }
}
