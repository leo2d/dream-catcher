using DreamCatcher.Domain.UserAgg;
using DreamCatcher.Domain.UserAgg.Contracts;
using DreamCatcher.Infra.Data.Config;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamCatcher.Infra.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(NHibernateConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        //public UserRepository(ISession session) : base(session)
        //{
        //}

        public User GetByLoginAndPassword(string login, string password)
        {
            var result = Session.Query<User>().FirstOrDefault(x =>
                    x.Login.ToLower().Equals(login.Trim().ToLower()) &&
                    x.Password.Equals(password)
                );

            return result;
        }
    }
}
