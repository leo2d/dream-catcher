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
    public class DreamTaskController : Controller
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
                    ViewBag.IdDream = dreamId;

                    var tasks = _taskService.GetTasksByDreamId(dreamId);
                    return View(tasks);

                }

                return View(new List<DreamTaskViewModel>());
            }
            catch (Exception ex)
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

            return RedirectToAction("Index", new { dreamId = taskViewModel.IdDream });
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

                return RedirectToAction("Index", new { dreamId = task.IdDream });

            }
            catch (Exception ex)
            {
                return View("Error");
                throw;
            }

        }

        [HttpGet]
        public ActionResult MarkDone(Guid id)
        {
            try
            {
                if (Guid.Empty != id)
                    _taskService.MarkDone(id);

                var idDream = _taskService.GetTasksById(id).IdDream;

                return RedirectToAction("Index", new { dreamId = idDream });


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

            return RedirectToAction("Index", new { dreamId = DreamTaskViewModel.IdDream });

        }

        public ActionResult Delete(Guid id)
        {
            Guid idDream;
            try
            {
                idDream = _taskService.GetTasksById(id).IdDream;
                _taskService.Delete(id);
            }
            catch (Exception ex)
            {

                throw;
            }

            return RedirectToAction("Index", new { dreamId = idDream });

        }
    }
}