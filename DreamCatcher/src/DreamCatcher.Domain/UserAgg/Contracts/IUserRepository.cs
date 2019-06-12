using DreamCatcher.Domain.SharedKernel.Interfaces;

namespace DreamCatcher.Domain.UserAgg.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByLoginAndPassword(string login, string password);
    }
}
