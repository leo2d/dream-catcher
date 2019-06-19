using DreamCatcher.Domain.DreamAgg;
using DreamCatcher.Domain.DreamAgg.Contracts;
using DreamCatcher.Domain.SharedKernel.Helpers;
using DreamCatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DreamCatcher.Web.Controllers
{

    [AllowAnonymous]
    public class DreamController : Controller
    {
        private readonly IDreamService _dreamService;

        public DreamController(IDreamService dreamService)
        {
            _dreamService = dreamService;
        }

        public ActionResult Index()
        {
            try
            {
                var user = SessionHelper.Getuser();
                if (null != user)
                {
                    var dreams = _dreamService.GetByUserId(user.Id);
                    return View(dreams);

                }

                return View(new List<Dream>());
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DreamVIewModel dreamVIewModel)
        {
            try
            {
                _dreamService.Create(dreamVIewModel);
            }
            catch (Exception ex)
            {

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}