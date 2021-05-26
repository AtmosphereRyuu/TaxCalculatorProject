using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;

namespace DataAccess.EFCore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationContext Context;
        public GenericRepository(ApplicationContext context)
        {
            Context = context;
        }
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }
        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        public T GetById(Guid id)
        {
            return Context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
        public void Complete()
        {
            Context.SaveChanges();
        }
    }
}
