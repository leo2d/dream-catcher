using DreamCatcher.Domain.DreamAgg;
using DreamCatcher.Domain.SharedKernel.Entities;
using System.Collections.Generic;

namespace DreamCatcher.Domain.UserAgg
{
    public class User : BaseEntity<User>
    {

        public User()
        {
            Dreams = new List<Dream>();
        }

        public virtual string Name { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }

        public virtual IList<Dream> Dreams { get; set; }
    }
}
