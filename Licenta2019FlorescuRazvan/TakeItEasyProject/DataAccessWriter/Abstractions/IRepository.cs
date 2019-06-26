using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessWriter.Abstractions
{
    public interface IRepository
    {
        ICollection<T> GetCollectionByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity;

        T GetByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity;

        T GetLastByFilter<T>(Expression<Func<T, bool>> filter)
            where T : BaseEntity;

        void Insert<T>(T entity)
            where T : BaseEntity;

        void Update<T>(T entity)
            where T : BaseEntity;

        void Save();
    }
}
