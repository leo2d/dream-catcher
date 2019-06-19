using DreamCatcher.Domain.UserAgg.Contracts;
using DreamCatcher.Models.ViewModels;
using System;
using System.Web.Mvc;

namespace DreamCatcher.Web.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userService.Create(userViewModel);
                    return RedirectToAction("Index", "Dream");

                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login(string login, string password)
        {
            if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
            {
                try
                {
                    var success = _userService.DoLogin(login, password);

                    if (success)
                    {
                        return RedirectToAction("Index", "Dream");
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return RedirectToAction("Index", "Home");

        }
    }
}