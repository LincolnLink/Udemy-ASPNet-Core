using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Repository;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    /// <summary>Implementa a interface: ILoginService</summary>
    public class LoginService : ILoginService
    {

        /// <summary> Propriedade que recebe o repositorio de login</summary>
        private IUserRepository _repository;

        private SigningConfigurations _signingConfigurations;

        private TokenConfigurations _tokenConfigurations;

        private IConfiguration _configuration;

        public LoginService(IUserRepository repository,
                            SigningConfigurations signingConfigurations,
                            TokenConfigurations tokenConfigurations,
                            IConfiguration configuration)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
        }

        /// <summary>
        /// Método que busca o usuario pelo email e retorna uma respota com o token configurado
        /// </summary>
        /// <param name="user">Objeto com tratamento que serve para fazer uma autenticação!</param>
        /// <returns>Um objeto autenticado com um token!</returns>
        public async Task<object> FindByLogin(LoginDto user)
        {

            var baseUser = new UserEntity();
            
            if(user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                
                baseUser =  await _repository.FindByLogin(user.Email);

                if(baseUser == null)
                {
                    return new {
                        authenticated = false,
                        message = "Falha ao autenticar"

                    };
                }
                else
                {
                    // Criando uma identidade para o token                  
                    ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.Email),
                        new[]
                        {   //Jti O id do Token
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                        }
                    );

                    // O tempo que foi criado, e o tempo que vai expirar
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                    var handler = new JwtSecurityTokenHandler();

                    // Cria um token
                    string token = CreateToken(identity, createDate, expirationDate, handler);

                    // Retorna uma resposta com o token criado
                    return SuccessObject(createDate, expirationDate, token, user);

                }
               
            }
            else
            {
                return null;
            }            
        }

        /// <summary>
        /// Criando um Token
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="createDate"></param>
        /// <param name="expirationDate"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,                
            });

            var token = handler.WriteToken(securityToken);
            return token;

        }


        /// <summary>
        /// Método que retorna uma resposta!
        /// </summary>
        /// <param name="createDate"></param>
        /// <param name="expirationDate"></param>
        /// <param name="token"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, LoginDto user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = user.Email,
                message = "Usuario Logado com sucesso"
            };

        }

    }
}