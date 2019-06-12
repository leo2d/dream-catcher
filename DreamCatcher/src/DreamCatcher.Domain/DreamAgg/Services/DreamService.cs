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

    }
}
