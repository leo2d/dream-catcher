using DreamCatcher.Domain.DreamAgg.Contracts;
using DreamCatcher.Domain.DreamAgg.Entities;
using DreamCatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DreamCatcher.Domain.DreamAgg.Services
{
    public class DreamTaskService : IDreamTaskService
    {
        private readonly IDreamTaskRepository _taskRepository;

        public DreamTaskService(IDreamTaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        #region mapping
        private IEnumerable<DreamTaskViewModel> MapToViewModel(IEnumerable<DreamTask> tasks)
        {
            var result = new List<DreamTaskViewModel>();

            foreach (var task in tasks)
            {
                var taskVm = MapToViewModel(task);
                result.Add(taskVm);
            }

            return result;
        }
        private DreamTaskViewModel MapToViewModel(DreamTask task)
        {
            return new DreamTaskViewModel()
            {
                Id = task.Id,
                IsDone = task.IsDone,
                Title = task.Title,
                IdDream = task.IdDream
            };
        }
        private DreamTask MapToDomain(DreamTaskViewModel taskVm)
        {
            return new DreamTask()
            {
                IsDone = taskVm.IsDone,
                Title = taskVm.Title,
                Id = taskVm.Id,
                IdDream = taskVm.IdDream
            };
        }
        #endregion

        public IEnumerable<DreamTaskViewModel> GetTasksByDreamId(Guid dreamId)
        {
            try
            {
                var tasks = _taskRepository.GetByDreamId(dreamId);

                var tasksVm = MapToViewModel(tasks);

                return tasksVm;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public DreamTaskViewModel GetTasksById(Guid id)
        {
            try
            {
                var task = _taskRepository.GetById(id);

                var taskVm = MapToViewModel(task);

                return taskVm;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Create(DreamTaskViewModel taskViewModel)
        {
            try
            {
                var task = MapToDomain(taskViewModel);

                _taskRepository.Create(task);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Update(DreamTaskViewModel taskViewModel)
        {
            try
            {
                var task = MapToDomain(taskViewModel);

                _taskRepository.Update(task);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                var task = _taskRepository.GetById(id);

                _taskRepository.Delete(task);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void MarkDone(Guid id)
        {
            try
            {
                var task = _taskRepository.GetById(id);
                task.IsDone = true;

                _taskRepository.Update(task);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}