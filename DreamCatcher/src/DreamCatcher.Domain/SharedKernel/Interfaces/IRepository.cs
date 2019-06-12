using System;
using System.Collections.Generic;

namespace DreamCatcher.Domain.SharedKernel.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        //void Delete(Guid id);
        IEnumerable<T> GetAll();
        T GetById(Guid id);
    }
}
