﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ManagingProducts.BLL.API;
using ManagingProducts.Common.DTO;
using ManagingProducts.DAL.Entities;
using ManagingProducts.DAL.IRepositories;

namespace ManagingProducts.BLL.Handler
{
    public class UserHandler : BaseHandler, IHandler<UserDto>
    {
        public UserHandler(IRepository repository)
            : base(repository)
        {
        }

        public IEnumerable<UserDto> GetAll()
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(repository.GetAll<User>());
        }

        public UserDto Get(int id)
        {
            return Mapper.Map<User, UserDto>(repository.Get<User>(id));
        }

        public void Add(UserDto userDto)
        {
            var user = repository.GetAll<User>().FirstOrDefault(i => i.Login == userDto.Login);
            if (user == null)
            {
                var newUser = Mapper.Map<UserDto, User>(userDto);
                repository.Add(newUser);
                repository.Save();
            }
        }

        public void Update(UserDto userDto)
        {
            var user = repository.Get<User>(userDto.Id);
            
            Mapper.Map(userDto, user);
            repository.Save();
        }

        public void Delete(int id)
        {
            repository.Delete<UserDto>(id);
            
            repository.Save();
        }
    }
}
