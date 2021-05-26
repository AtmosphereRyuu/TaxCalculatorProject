using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(Guid guid);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void Complete();
    }
}
