using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicReader.QueryBuilders
{
    public static class UserQueryBuilder
    {
        public static string GetAll()
        {
            return "select * from users";
        }

        public static string GetByEntityId(Guid id)
        {
            return $"select * from users where entityId == { id }";
        }
    }
}
