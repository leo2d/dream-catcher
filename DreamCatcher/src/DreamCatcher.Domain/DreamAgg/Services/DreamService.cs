using DreamCatcher.Domain.DreamAgg.Contracts;
using System;
using System.Collections.Generic;

namespace DreamCatcher.Domain.DreamAgg.Services
{
    public class DreamService : IDreamService
    {
        private readonly IDreamRepository _dreamRepository;

        public string GetTest()
        {
            return "FUNCIONOOOOOOOOOOOU!";
        }

        public void Delete(Guid Id)
        {
            try
            {
                var dream = _dreamRepository.GetById(Id) ;

                _dreamRepository.Delete(dream);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<Dream> GetByUserId(Guid id)
        {
            try
            {
                var dreams = _dreamRepository.GetByUserId(id);
                return dreams;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
