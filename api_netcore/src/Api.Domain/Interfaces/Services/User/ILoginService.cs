using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User
{
    /// <summary>Implementada na classe: LoginService, busca o uruario pelo email</summary>
    public interface ILoginService
    {
         Task<object> FindByLogin(LoginDto user);
    }
}