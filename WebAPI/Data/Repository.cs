using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll() => _context.Set<T>().AsEnumerable();

        public virtual T GetById(Guid id) => _context.Set<T>().Find(id);

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public bool Exists(T entity)
        {
           return _context.Set<T>().Any(en => en.Id == entity.Id);
        }
    }
}