using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
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
            serviceCollection.AddScoped(typeof(IUserRepository), typeof(UserImplementation));

            /*Nova, do SqlServe*/
            serviceCollection.AddDbContext<MyContext>(
               options => options.UseSqlServer("Server=.\\SQLEXPRESS2017;Database=dbAPI;User Id=sa;Password=root123")
            );

            /*Antiga, do MySql*/
            /*serviceCollection.AddDbContext<MyContext>(
               options => options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=root123")
            );*/  
        }
    }
}
