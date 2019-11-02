# Udemy-ASPNet-Core
Desenvolvendo uma API com ajuda de um curso da Udemy

- [x] Dot.Net 2.2
- [x] MySQL
- [x] Entity Framework Core
- [x] Swagger 4.0.1

## Extension install

- [x] C#
- [x] C# Extensions
- [x] C# XML Documentation Comments
- [x] vscode-icons

cmd personalizado: https://cmder.net/

# Lista de opções de projetos

`dotnet new`


# Comando para criar uma solution

`dotnet new sln --name CSharpBasico`


# Criando um projeto em console com uma pasta 

`dotnet new console -n HelloWorld -o helloWorld`

- -n: nome do projeto console!
- -o: nome da pasta!


# Vinculando um projeto a uma solução existente

`dotnet sln add 'nomeDoProjeto'`


# Executando um projeto

`dotnet run`

# Buildando 

`dotnet build`


# Limpando a aplicação

`dotnet clean`


# Restalrando a aplicação

`dotnet restore`


# Criando Pagina 

`md "nome da pagina"`


# Abrir o codigo no VS code

`code .`


# Configurando o VS code para dotnet core (#33)

files -> referencia -> settings

# Baixando extenções

https://www.nuget.org/

CLI do .NET :

ex: dotnet add package Microsoft.EntityFrameworkCore - versão 2.2.6

dotnet add package Pomelo.EntityFrameworkCore.MySql --version 3.0.0-rc1.final

# API e Micro serviços (#37)

- API: 
Quando você desenvolve um sistea completo ultilizando o mesmo banco de dados,
exemplo: faturamento, estoque, Financeiro, Vendas, etc.

Irasubir esta aplicação em uma instancia e consegue escalar aumentando recursos!


- MS: 
O conceito principal é quebrar a API, cria um MS para faturamento, usando um banco de dados só para ele, cria outro MS de estoque, ultilizando um outro banco de dados só para ele!

Com isso você consegue por cada micro servico em uma instancia diferente, e até mesmo escrevendo com linguagens de programação diferentes e banco de dados diferentes!

Para fazer os MS conversar, precisa criar um Orquestrador!

# Rotas / REST / RESTFULL

- Rotas: 

ex: http://site.com.br/clientes(GET,POST), http://site.com.br/clientes(GET,UPDATE,PATCH,DELETE)


- REST: 
É uma arquitetura que propõe basicamente a padronização de rotas de API na comunicação cliente/servidor.

requisições HTTP enviadas: http://site.com.br/objeto/ação e retornos de texto puro ou dados estruturados e serializados como JSOM E XML.


- RESTFULL
É um sistemas API arquitetados como vistas a acessos REST e uso semantico dos métodos HTTP GET, POST, PUT, PATCH, DELETE são chamados RESTFULL.

RESTFULL endereça nomes de recursos junto a métodos HTTP para realizar operações.



# Criando uma aplicação em WebApi (Aplication)

`dotnet new webapi -n Application -o Api.Application --no-https`

- -n : nome da aplicação
- -o : nome da pasta
- --no-https: configuração temporaria.

# Adicionando aplicação com solução! 

`dotnet sln add Api.Application`

- 1° depois disso deve buildar `dotnet build`, 
- 2° depois voltar para a raiz `cd ..`,
- 3° depois disso deve abrir o codigo `code .` , vai aparecer uma mensagem, pedindo para debugar, clica em YES! 

Com essa configuração é possivel debugar a aplicação!! (#42)

# Criando o Dominio, bibliotecas de classe (Domain)

`dotnet new classlib -n Domain -f netcoreapp2.2 -o Api.Domain`

- -n: nome da biblioteca de classe.
- -f tipo da biblioteca de classe.
- -o cria uma pasta para a biblioteca de classe

# Adicionando a lib na solução

`dotnet sln add Api.Domain`

- "Api.Domain" nome da pasta da lib !

# Criando a lib Api.CrossCutting e Api.Data (Infra Estrutura)

`dotnet new classlib -n CrossCutting -f netcoreapp2.2 -o ApiCrossCutting`

`dotnet new classlib -n Data -f netcoreapp2.2 -o Api.Data  `

- -n CrossCutting: nome da classlib
- -f netcoreapp2.2: o tipo da classlib
- -o ApiCrossCutting: criando a pasta da lib

# Adicionando a lib na solução

`dotnet sln add Api.CrossCutting`
`dotnet sln add Api.Data`

depois pode buildar usando `dotnet build`


# Instalando o EntityFrameWork (Microsoft.EntityFrameworkCore.Tools)

Site: https://www.nuget.org/

- NET CLI do pacote Entity

`dotnet add package Microsoft.EntityFrameworkCore.Tools --version 2.2.6`

`dotnet add package Microsoft.EntityFrameworkCore.Design --version 2.2.6`

`dotnet add package Pomelo.EntityFrameworkCore.MySql --version 2.2.6`


# Configurando o EntityFrameWork

Criando MyContext e referenciar Api.Data com Api.Domain

- Comando que adiciona referencia

`dotnet add .\Api.Data\ reference .\Api.Domain\`

<blockquote> Iniciando o Contexto </blockquote>

1° Foi criada uma pasta para o coxtet e uma classe(MyContext), nela foi exdada uma classe chamada 'DbContext', iniciado uma propriedade(prop) chamada 'User' do tipo generico DbSet<T>, aonde T recebe a entidade que deve ser mapeada!

`public DbSet<UserEntity> Users { get; set; }`

2° no método construtor, é passado pelo parametro chamado options do tipo generico DbContextOptions<T>, aonde T é a propria classe de contexto! 

`public MyContext(DbContextOptions<MyContext> options) : base(options){}`

3° Foi feito um override da classe OnModelCreating(), aonde recebe o ModelBuilder como parametro!

`

 protected override void OnModelCreating(ModelBuilder modelBuilder)
 {

 	base.OnModelCreating(modelBuilder);

 }

 `

<blockquote> Criando uma fabrica de contexto</blockquote> 


Criando uma Conexão

- 1°Cria uma classe chamada 'CotextFactory', depois herda a classe 'IDesignTimeDbContextFactory<MyContext>' faz a referencia que pedir, e implementa a interface
- 2° No método do contrato cria uma variavel para receber a sua connectionString!
E outra variavel para receber uma instancia de DbContextOptionsBuilder<MyContext>();
- 3° Use o método 'UserMySql' para fazer uma Conexão!
- 4° Retorne uma instancia do MyContext, recebendo o Options como parametro!

`

        public MyContext CreateDbContext(string[] args)
        {
            //Usando para criar a migrações
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=''";

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            optionsBuilder.UseMySql(connectionString);

            return new MyContext(optionsBuilder.Options);
        }
`

Com isso você consegue criar as migrações!

<blockquote> Mapeando a classe para o EF</blockquote> 

Cria uma classe com nome de UserMap, na pasta Mapping, implementa a interface generica do tipo da classe da sua Domain!

` IEntityTypeConfiguration<UserEntity> `

Bota as referencias, e implementa a interface, assim aparece um método para você criar regras para a tabela do banco e suas propriedades!



`public void Configure(EntityTypeBuilder<UserEntity> builder){


            //Definindo o nome da tabela
            builder.ToTable("User");

            //Definindo a chave primaria            
            builder.HasKey(p => p.Id);

            //Definindo como campo unico
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
`

Configura o mapeamento no context

`
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }
`

<blockquote> Configurando a migração! </blockquote> 

No prompt comando entra na pasta Api.Data, o unico projeto que tem o EF, para digitar o comando:

` dotnet ef --help` esse comando informa os comandos principais do EF! 

Adicionando na migração!

`dotnet ef migrations add UserMigration`

Monstrando qual banco deve user

`dotnet ef database update`

<blockquote> Criando o Repositorio </blockquote> 


- Método insert do formato async!

`
public async Task<T> InsertAsync(T item)
        {


            try
            {

                //Caso o ID esteja vasio, é criado um id
                if (item.Id == Guid.Empty)
                {

                    item.Id = Guid.NewGuid();

                }


                //Salva a data da criação
                item.CreateAt = DateTime.UtcNow;
                _dataset.Add(item);

                //o termo await faz parte do método async, salva o objeto usnado o contexto
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return item;
        }

`

- Método update do formato async!

`
public async Task<T> UpdateAsync(T item)
{


    try
    {

    //Procura o objeto no banco!

    var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

        if (result == null)
        {
            return null;
        }


        //Caso ele exista informa a data de modificação e reforça a de criação!
        item.UpdateAt = DateTime.UtcNow;


        item.CreateAt = result.CreateAt;


        //Atualiza as informações novas e salva no banco!


        _context.Entry(result).CurrentValues.SetValues(item);


        //ele faz o commit ou o roolback


        await _context.SaveChangesAsync();


    }

    catch (Exception ex)
    {


        throw ex;


    }


    //retorna o que foi atualizado
    return item;


}


`


- Método deletar do formato async!

`public async Task<bool> DeleteAsync(Guid id)

        {

            try
            {

                //Procura o objeto no banco!

                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));

                if (result == null)
                {

                    return false;


                }

                _dataset.Remove(result);


                await _context.SaveChangesAsync();


                return true;


            }


            catch (Exception ex)
            {
                throw ex;
            }


        }`

- Método async que seleciona todos ou um unico objeto!

`

public async Task<IEnumerable<T>> SelectAcync()
{

            try
            {

                return await _dataset.ToListAsync();

            }
            catch (Exception ex)
            {


                throw ex;

            }
}
`


´
public async Task<T> SelectAsync(Guid id)
{    
    try
    {
        return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
    }
    catch (Exception ex)
    {

        throw ex;
    }
}

´

# Api.Service



<blockquote> Implementando o Service </blockquote> 


- 1° cria uma interface no projeto de Domain, com os contratos!

`


namespace Api.Domain.Interfaces.Services.User
{

    public interface IUserService
    {

        Task<UserEntity> Get(Guid id);

        Task<IEnumerable<UserEntity>> GetAll();

        Task<UserEntity> Post(UserEntity user);

        Task<UserEntity> Put(UserEntity user);

        Task<bool> Delete(Guid id);
    }
}`



- 2° Cria referencias para a Service!

`dotnet add .\Api.Service\ reference .\Api.Domain\`

`dotnet add .\Api.Service\ reference .\Api.Data\`

`dotnet add .\Api.Service\ reference .\Api.CrossCutting\`

- 3° A implementação

Cria uma pasta chamada Service, e dentro dela uma classe chamada "UserService", implementa a interface UserService, passa as referencias para tirar os erros, e implementa a interface para poder exibir os métodos do contrato!


`



namespace Api.Service.Services
{
    public class UserService : IUserService
    {

        private IRepository<UserEntity> _repository;

        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository.SelectAcync();
        }

        public async Task<UserEntity> Post(UserEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}


`


Em cada método desse é possivel por as regras de negocio, o projeto de Api.Service serve para ser um intermediario do projeto Api.Aplicação para a Api.Infra/Data ! 
OBS: não se deve por validação! 



# Tratando o projeto Api.Aplication


<blockquote> Criando a classe de controle! </blockquote> 

- Adicione algumas referencias !!

`dotnet add Api.Application reference Api.Domain`

`dotnet add Api.Application reference Api.Service`

`dotnet add Api.Application reference Api.CrossCutting`


- Cria uma classe com nome de "UsersController"


Criando o GetAll com tratamento

`


[HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IUserService service) //faz referencia do service
        {
            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação invalida!
            }

            try
            {
                return Ok(await service.GetAll());
            }
            catch (ArgumentException e) //trata erros de controller!
            {
                //Resposta para o navegador! - erro 500
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

`
vai da erro precisa tratar a injeção de dependencia e o projeto CrossCutting


- Adiciona mais ferefencia

`dotnet add .\Api.CrossCutting\ reference .\Api.Domain\`

`dotnet add .\Api.CrossCutting\ reference .\Api.Service\`

`dotnet add .\Api.CrossCutting\ reference .\Api.Data\`

Vai aparecer outro erro de , referencia circular , para re solver re mova a referencia CrossCutting do projeto de service

- instala o AutoMaper

`dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 7.0.0`




.............

# Instalando e usando o Swagger!

- Swashbuckle.Aps.NetCore

https://www.nuget.org/packages/Swashbuckle.AspNetCore/5.0.0-rc4

dotnet add package Swashbuckle.AspNetCore --version 4.0.1
<blockquote>foi instalada na Api.Application !</blockquote> 

configuração feita na classe Startup

- Configuração do Swagger! (antes do addMVC)

`

services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                new Info
                {
                    Title = "API AspNetCore 2.2",
                    Version = "v1",
                    Description = "Exemplo de API REST criado com ASP.NET Core",
                    Contact = new Contact
                    {
                        Name = "Lincoln Ferreira Campos",
                        Url = "https://github.com/LincolnLink"
                    }
                });
            });


`



- Ativando middlewares paa uso do Swagger (no método Configure, antes do app.usemvc)


`


app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API com AspNetCore 2.2");
            });
`


- Redireciona o Link para o Swagger, quando acessar a rota principal (no método Configure, antes do app.usemvc)

`



var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

`