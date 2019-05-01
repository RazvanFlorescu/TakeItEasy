using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessReader.Abstractions
{
    public interface IRepository
    {
        List<T> ExecuteQuery<T>(string query)
            where T : BaseDto;

        T ExecuteQueryFirstOrDefault<T>(string query)
            where T : BaseDto;
    }
}
