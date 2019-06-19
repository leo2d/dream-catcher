using DreamCatcher.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace DreamCatcher.Domain.DreamAgg.Contracts
{
    public interface IDreamService
    {
        IEnumerable<DreamVIewModel> GetByUserId(Guid id);
        void Create(DreamVIewModel dreamVIewModel);
    }
}
