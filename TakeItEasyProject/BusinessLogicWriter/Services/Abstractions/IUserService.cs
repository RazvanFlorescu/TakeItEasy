using System;
using Models;

namespace BusinessLogicWriter.Services.Abstractions
{
    public interface IUserService
    {
        void Register(UserDto user);
        void RemoveAccount(Guid id);
    }
}
