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
            ViewBag.Edit = false;
            return PartialView("DreamModal", new DreamVIewModel() { RegisterDate = DateTime.Now });
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

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            try
            {
                ViewBag.Edit = true;

                var dream = _dreamService.GetById(id);

                if(null != dream)
                    return PartialView("DreamModal", dream);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View("Error");
                throw;
            }

        }


        [HttpPost]
        public ActionResult Edit(DreamVIewModel dreamVIewModel)
        {
            try
            {
                dreamVIewModel.IDUser = SessionHelper.Getuser().Id;
                _dreamService.Update(dreamVIewModel);
            }
            catch (Exception ex)
            {
                return View("Error");

                throw;
            }

            return RedirectToAction("Index");
        }
    }
}