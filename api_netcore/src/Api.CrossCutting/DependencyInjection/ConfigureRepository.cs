using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            //método .AddSingleton: ele não muda a instancia.
            //método .AddTransient: sempre cria uma nova instancia.
            //método .AddScoped: usa a mesma instancia.
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddDbContext<MyContext>(
               options => options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=root123")
           );
        }
    }
}
