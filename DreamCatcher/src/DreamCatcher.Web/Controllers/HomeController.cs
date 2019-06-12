using DreamCatcher.Domain.DreamAgg.Contracts;
using DreamCatcher.Domain.UserAgg.Contracts;
using DreamCatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DreamCatcher.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDreamService _dreamService;
        private IUserService _userService;


        public HomeController(IDreamService dreamService)
        {
            _dreamService = dreamService;
        }
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}