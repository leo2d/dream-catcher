using DreamCatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamCatcher.Domain.DreamAgg.Contracts
{
    public interface IDreamTaskService
    {
        IEnumerable<DreamTaskViewModel> GetTasksByDreamId(Guid dreamId);
        DreamTaskViewModel GetTasksById(Guid id);
        void Create(DreamTaskViewModel taskViewModel);
        void Update(DreamTaskViewModel taskViewModel);
        void MarkDone(Guid id);
        void Delete(Guid id);
    }
}
