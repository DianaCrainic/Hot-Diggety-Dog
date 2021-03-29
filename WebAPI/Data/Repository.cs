using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        void IRepository<T>.Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        IEnumerable<T> IRepository<T>.GetAll() => _context.Set<T>().AsEnumerable();

        T IRepository<T>.GetById(Guid id) => _context.Set<T>().Find(id);

        void IRepository<T>.Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        void IRepository<T>.Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        bool IRepository<T>.Exists(T entity)
        {
           return _context.Set<T>().Any(en => en.Id == entity.Id);
        }
    }
}