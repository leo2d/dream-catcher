using DreamCatcher.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace DreamCatcher.Domain.DreamAgg.Contracts
{
    public interface IDreamService
    {
        IEnumerable<DreamVIewModel> GetDreamByUserId(Guid id);
        void CreateDream(DreamVIewModel dreamVIewModel);
        DreamVIewModel GetDreamById(Guid id);
        void UpdateDream(DreamVIewModel dreamVIewModel);
        void DeleteDream(Guid id);
    }
}
