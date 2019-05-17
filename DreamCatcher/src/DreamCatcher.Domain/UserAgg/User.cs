using DreamCatcher.Domain.SharedKernel.Entities;

namespace DreamCatcher.Domain.UserAgg
{
    public class User : BaseEntity<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
