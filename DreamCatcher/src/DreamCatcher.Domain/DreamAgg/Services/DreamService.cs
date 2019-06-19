using DreamCatcher.Domain.DreamAgg.Contracts;
using DreamCatcher.Domain.SharedKernel.Helpers;
using DreamCatcher.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DreamCatcher.Domain.DreamAgg.Services
{
    public class DreamService : IDreamService
    {
        private readonly IDreamRepository _dreamRepository;

        public DreamService(IDreamRepository dreamRepository)
        {
            _dreamRepository = dreamRepository;
        }

        public void Create(DreamVIewModel dreamVIewModel)
        {
            try
            {
                
                var dream = MapToDomain(dreamVIewModel);

                dream.RegisterDate = DateTime.Now;
                dream.IDUser = SessionHelper.Getuser().Id;

                _dreamRepository.Create(dream);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<DreamVIewModel> GetByUserId(Guid id)
        {
            try
            {
                var dreams = _dreamRepository.GetByUserId(id);
                var dreamsVm = MapToViewModel(dreams);

                return dreamsVm;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private IEnumerable<DreamVIewModel> MapToViewModel(IEnumerable<Dream> dreams)
        {
            var result = new List<DreamVIewModel>();

            foreach (var dream in dreams)
            {
                var dreamVm = MapToViewModel(dream);
                result.Add(dreamVm);
            }

            return result;
        }
        private DreamVIewModel MapToViewModel(Dream dream)
        {
            return new DreamVIewModel()
            {
                IDUser = dream.IDUser,
                IsDone = dream.IsDone,
                Title = dream.Title,
                User = dream.User.Name,
                Id = dream.Id,
                Tasks = new List<DreamTaskViewModel>()
            };
        }

        private Dream MapToDomain(DreamVIewModel dreamVm)
        {
            return new Dream()
            {
                IDUser = dreamVm.IDUser,
                IsDone = dreamVm.IsDone,
                Title = dreamVm.Title,
                Id = dreamVm.Id,
                User = SessionHelper.Getuser(),
            };
        }
    }
}
