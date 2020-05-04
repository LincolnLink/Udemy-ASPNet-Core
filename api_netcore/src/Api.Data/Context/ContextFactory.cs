using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usando para criar a migrações
            //MySql
            //var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=root123";
            //SqlServer
            var connectionString = "Server=.\\SQLEXPRESS2017;Database=dbAPI;User Id=sa;Password=root123";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionsBuilder.UseMySql(connectionString);  
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
