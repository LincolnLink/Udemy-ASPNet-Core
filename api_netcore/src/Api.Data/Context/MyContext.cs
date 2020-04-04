using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        //Toda tabela nova, deve se adicionar um contexto aqui, alem de criar a entidade e o map!
        public DbSet<UserEntity> Users { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Toda tabela nova, se cria o map e chama ele aqui!
            //Depois de criar o mapeamento, chama o método que faz a configuração!
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);

        }





    }
}
