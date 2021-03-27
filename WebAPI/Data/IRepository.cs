using System;
using System.Collections.Generic;

namespace WebAPI.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}
