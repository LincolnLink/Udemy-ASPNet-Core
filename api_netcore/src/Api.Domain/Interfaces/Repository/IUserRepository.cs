using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.RepositoryBase;

namespace Api.Domain.Interfaces.Repository
{

    /// <summary> Implementada na classe: UserImplementation, Pega o usuario para fazer autenticação </summary>
    public interface IUserRepository: IRepository<UserEntity>
    {
        /// <summary>
        /// Um método de extenção??
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<UserEntity> FindByLogin (string email);
    }
}