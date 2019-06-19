using DreamCatcher.Domain.SharedKernel.Helpers;
using DreamCatcher.Domain.UserAgg.Contracts;
using DreamCatcher.Models.ViewModels;
using System;

namespace DreamCatcher.Domain.UserAgg.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Create(UserViewModel userViewModel)
        {
            try
            {
                var user = MapViewModelToDomain(userVm: userViewModel);

                _userRepository.Create(user);

                SessionHelper.Setuser(user);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DoLogin(string login, string password)
        {
            try
            {
                var user = _userRepository
                    .GetByLoginAndPassword(login, password);

                if (null != user)
                {
                    SessionHelper.Setuser(user);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DoLogout(UserViewModel userViewModel)
        {
            try
            {
                var user = MapViewModelToDomain(userViewModel);

                SessionHelper.RemoveUser();

                return true;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Update(UserViewModel userViewModel)
        {
            try
            {
                var user = MapViewModelToDomain(userViewModel);

                _userRepository.Update(user);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private UserViewModel MapDomainToViewModel(User user)
        {
            return new UserViewModel()
            {
                Password = user.Password,
                ConfirmationPassword = user.Password,
                Name = user.Name,
                Login = user.Login,
                Id = user.Id
            };
        }

        private User MapViewModelToDomain(UserViewModel userVm)
        {
            return new User()
            {
                Password = userVm.Password,
                Name = userVm.Name,
                Login = userVm.Login,
                Id = userVm.Id ?? Guid.Empty
            };
        }

    }
}
