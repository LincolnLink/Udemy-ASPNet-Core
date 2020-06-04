using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Services.User;


namespace Api.Service.Services
{
    /// <summary>Implementa a interface: ILoginService</summary>
    public class LoginService : ILoginService
    {

        /// <summary> Propriedade que recebe o repositorio de login</summary>
        private IUserRepository _repository;

        public LoginService(IUserRepository repository )
        {
            _repository = repository;
        }

        /// <summary>
        /// Método que busca o usuario pelo email
        /// </summary>
        /// <param name="user">Objeto com tratamento que serve para fazer uma autenticação!</param>
        /// <returns>Um objeto autenticado com um token!</returns>
        public async Task<object> FindByLogin(LoginDto user)
        {
            
            if(user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                
                return await _repository.FindByLogin(user.Email);;
               
            }
            else
            {
                return null;
            }            
        }
    }
}