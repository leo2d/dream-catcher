using DreamCatcher.Domain.SharedKernel.Entities;

namespace DreamCatcher.Domain.UserAgg
{
    public class User : BaseEntity<User>
    {
        public virtual string Name { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
    }
}
