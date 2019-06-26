using Entities;
using System.Collections.Generic;

namespace DataAccessReader.Abstractions
{
    public interface IRepository
    {
        List<T> ExecuteQuery<T>(string query)
            where T : BaseEntity;

        T ExecuteQueryFirstOrDefault<T>(string query)
            where T : BaseEntity;
    }
}
