using System;
using AutoMapper;
using BusinessLogicWriter.Helpers;
using BusinessLogicWriter.Services.Abstractions;
using DataAccessWriter.Abstractions;
using Entities;
using Models;

namespace BusinessLogicWriter.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
            AutoMapperHelper.IntializeMapper();
        }
        public void Register(UserDto user)
        {
            User entity = Mapper.Map<UserDto, User>(user);
            entity.Id = Guid.NewGuid();
            entity.EntityId = Guid.NewGuid();
            entity.LastChangedDate = DateTime.Now;

            _repository.Insert(entity);
        }

        public void RemoveAccount(Guid id)
        {
            User user = _repository.GetByFilter<User>(opt => opt.EntityId == id);

            user.DeletedDate = DateTime.Now;
            user.LastChangedDate = DateTime.Now;

            _repository.Update(user);
        }
    }
}
