using DreamCatcher.Domain.DreamAgg;
using DreamCatcher.Domain.DreamAgg.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DreamCatcher.Web.Controllers
{
    [AllowAnonymous]
    public class DreamController : Controller
    {
        private IDreamService _dreamService;

        public DreamController(IDreamService dreamService)
        {
            _dreamService = dreamService;
        }

    }
}