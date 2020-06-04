using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User
{
    /// <summary>Implementada na classe: UserService, Faz CRUD com o projeto Api.Data</summary>
    public interface IUserService
    {
        Task<UserEntity> Get(Guid id);

        Task<IEnumerable<UserEntity>> GetAll();

        Task<UserEntity> Post(UserEntity user);

        Task<UserEntity> Put(UserEntity user);

        Task<bool> Delete(Guid id);
    }
}
