using DreamCatcher.Domain.DreamAgg.Contracts;
using DreamCatcher.Domain.SharedKernel.Helpers;
using DreamCatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DreamCatcher.Web.Controllers
{
    [AllowAnonymous]
    public class DreamTaskController: Controller
    {

        private readonly IDreamTaskService _taskService;

        public DreamTaskController(IDreamTaskService taskService)
        {
            _taskService = taskService;
        }

        public ActionResult Index(Guid dreamId)
        {
            try
            {
                if (dreamId != Guid.Empty)
                {
                    var dreams = _taskService.GetTasksByDreamId(dreamId);
                    return View(dreams);

                }

                return View(new List<DreamTaskViewModel>());
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public ActionResult Create(Guid dreamId)
        {
            ViewBag.Edit = false;
            return PartialView("DreamTaskModal", new DreamTaskViewModel() { IdDream = dreamId });
        }

        [HttpPost]
        public ActionResult Create(DreamTaskViewModel taskViewModel)
        {
            try
            {
                _taskService.Create(taskViewModel);
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

                var task = _taskService.GetTasksById(id);

                if (null != task)
                    return PartialView("DreamTaskModal", task);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View("Error");
                throw;
            }

        }

        [HttpPost]
        public ActionResult Edit(DreamTaskViewModel DreamTaskViewModel)
        {
            try
            {
                _taskService.Update(DreamTaskViewModel);
            }
            catch (Exception ex)
            {
                return View("Error");

                throw;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            try
            {
                _taskService.Delete(id);
            }
            catch (Exception ex)
            {

                throw;
            }

            return RedirectToAction("Index");

        }
    }
}