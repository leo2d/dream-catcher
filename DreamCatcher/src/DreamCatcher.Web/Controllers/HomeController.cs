using DreamCatcher.Domain.DreamAgg.Contracts;
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
        public HomeController(IDreamService dreamService)
        {
            _dreamService = dreamService;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}