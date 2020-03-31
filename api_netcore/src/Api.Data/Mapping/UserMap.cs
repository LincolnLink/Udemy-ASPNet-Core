using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            //Definindo o nome da tabela
            builder.ToTable("User");

            //Definindo a chave primaria
            builder.HasKey(p => p.Id);

            //Criando um Index e Definindo como campo unico
            builder.HasIndex(p => p.Email)
                   .IsUnique();

            //Definindo como requirido e um tamanho maximo
            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(60);

            //Definindo um tamanho maximo
            builder.Property(u => u.Email)
                   .HasMaxLength(100);
        }
    }
}
