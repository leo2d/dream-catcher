using DreamCatcher.Domain.DreamAgg;
using DreamCatcher.Domain.DreamAgg.Contracts;
using DreamCatcher.Domain.SharedKernel.Helpers;
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

        public ActionResult Dreams()
        {
            var dreams = _dreamService.GetByUserId(SessionHelper.Getuser().Id);

            return View(dreams);
            
        }

    }
}