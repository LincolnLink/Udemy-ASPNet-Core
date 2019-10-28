using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        /// <summary>
        /// Uma configuração de injeção de dependencia, também pode ser achado na classe StartUp!
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            //método .AddSingleton: ele não muda a instancia.
            //método .AddTransient: sempre cria uma nova instancia.
            //método .AddScoped: usa a mesma instancia.
            serviceCollection.AddTransient<IUserService, UserService>();
        }
    }
}
