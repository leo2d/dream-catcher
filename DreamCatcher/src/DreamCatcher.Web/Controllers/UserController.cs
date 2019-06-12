using DreamCatcher.Domain.UserAgg.Contracts;
using DreamCatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult Test()
        {
            return View("Index");
        }

        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userService.Create(userViewModel);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userService.DoLogin(userViewModel);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return RedirectToAction("Dreams");
        }
    }
}