using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usando para criar a migrações
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=84190162";

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            optionsBuilder.UseMySql(connectionString);
            
            return new MyContext(optionsBuilder.Options);
        }
    }
}
