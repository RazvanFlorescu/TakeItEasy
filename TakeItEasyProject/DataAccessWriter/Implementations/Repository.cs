using Entities;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccessWriter.Abstractions;

namespace DataAccessWriter.Implementations
{
    public class Repository : IRepository
    {
        private readonly TakeItEasyContext _context;

        public Repository(TakeItEasyContext context)
        {
            _context = context;
        }

        public ICollection<T> GetCollectionByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity
        {
            return _context.Set<T>().Where(filter).ToList();
        }

        public T GetByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity
        {
            return _context.Set<T>().FirstOrDefault(filter);
        }

        public T GetLastByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity
        {
            return _context.Set<T>().OrderByDescending(obj => obj.LastChangedDate).FirstOrDefault(filter);
        }

        public void Insert<T>(T entity)
            where T : BaseEntity
        {
            entity.LastChangedDate = DateTime.Now;
            _context.Set<T>().Add(entity);
        }

        public virtual void Update<T>(T entity)
            where T : BaseEntity
        {
            _context.Set<T>().Add(entity);
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }
    }
}
