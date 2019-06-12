using DreamCatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamCatcher.Domain.UserAgg.Contracts
{
    public interface IUserService
    {
        bool DoLogin(UserViewModel userViewModel);
        bool DoLogout(UserViewModel userViewModel);
        void Create(UserViewModel userViewModel);
        void Update(UserViewModel userViewModel);
    }
}
