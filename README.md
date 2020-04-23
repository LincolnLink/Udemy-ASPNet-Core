# Udemy-ASPNet-Core
Desenvolvendo uma API com ajuda de um curso da Udemy

- [x] Dot.Net 2.2
- [x] MySQL
- [x] Entity Framework Core 2.2.6
- [x] Swagger 4.0.1

## Extension install

- [x] C#
- [x] C# Extensions
- [x] C# XML Documentation Comments
- [x] vscode-icons

## Programas

- [x] cmd personalizado: https://cmder.net/
- [x] Visual Studio Code



# API e Micro serviços (#37)

- API: 
    Quando você desenvolve um sistema completo ultilizando o mesmo banco de dados,
    exemplo: faturamento, estoque, Financeiro, Vendas, etc.

    Ira subir esta aplicação em uma instancia e consegue escalar aumentando recursos!

- Microsserviços (MS): 
    O conceito principal é quebrar a API, cria um MS para faturamento, usando um banco de dados só para ele, cria outro MS de estoque, ultilizando um outro banco de dados só para ele!

    Com isso você consegue por cada MS em uma instancia diferente, e até mesmo escrevendo com linguagens de programação diferentes e banco de dados diferentes!

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



# Comandos basicos do DotNet

### Comando para criar uma solution!

<blockquote>dotnet new sln --name CSharpBasico</blockquote>

### Comando que lista opções de projetos!

<blockquote>dotnet new</blockquote>

### Comando para criar um projeto, com uma pasta!

<blockquote>dotnet new console -n HelloWorld -o helloWorld</blockquote>

- -n: nome do projeto console!
- -o: nome da pasta!

### Comando que Vincula um projeto a uma solução existente

<blockquote>dotnet sln add 'nomeDoProjeto'</blockquote>

### Comando que limpando a aplicação

<blockquote>dotnet clean</blockquote>

### Comando que restalra a aplicação

<blockquote>dotnet restore</blockquote>

### Comando para Buildar a aplicação!

<blockquote>dotnet build</blockquote>

### Comando que Executa um projeto

<blockquote>dotnet run</blockquote>

### Comando que Abre o codigo no VS code

<blockquote>code .</blockquote>

### Comando que criando uma pasta

<blockquote>md "nome da pagina"</blockquote>



# Configurando o VS code para dotnet core (#33)

<blockquote>files -> referencia -> settings</blockquote>



# Criando uma aplicação em WebApi e o projeto principal (Application)

- Você deve criar uma solução, com o nome de "Api"!

    <blockquote> dotnet new sln --name Api</blockquote>

- Criando o projeto chamado "Application"!

    <blockquote> dotnet new webapi -n Application -o Api.Application --no-https</blockquote>

    - -n : nome da aplicação
    - -o : nome da pasta
    - --no-https: configuração temporaria.

    Adicionando aplicação com solução:

    <blockquote> dotnet sln add Api.Application</blockquote>

    Com essa configuração é possivel debugar a aplicação!! (#42)



# Criando o projeto Dominio (Domain)

- Criando o projeto chamado "Domain" com uma pasta!

    <blockquote>dotnet new classlib -n Domain -f netcoreapp2.2 -o Api.Domain</blockquote>

    - -n: nome da biblioteca de classe.
    - -f tipo da biblioteca de classe.
    - -o cria uma pasta para a biblioteca de classe

    Adicionando a lib na solução:

    <blockquote>dotnet sln add Api.Domain</blockquote>


# Criando o projeto Service (Service)

- Criando o projeto chamado "Service" com uma pasta!

    <blockquote>dotnet new classlib -n Service -f netcoreapp2.2 -o Api.Service</blockquote>

    - -n: nome da biblioteca de classe.
    - -f tipo da biblioteca de classe.
    - -o cria uma pasta para a biblioteca de classe

    Adicionando a lib na solução:

    <blockquote>dotnet sln add Api.Service</blockquote>



# Criando a lib Api.CrossCutting e Api.Data (Infra Estrutura)

- Criando o projeto chamado "Api.Data" e Api.CrossCutting com uma pasta!

    <blockquote>dotnet new classlib -n CrossCutting -f netcoreapp2.2 -o ApiCrossCutting</blockquote>

    <blockquote>dotnet new classlib -n Data -f netcoreapp2.2 -o Api.Data</blockquote>

    - -n CrossCutting: nome da classlib
    - -f netcoreapp2.2: o tipo da classlib
    - -o ApiCrossCutting: criando a pasta da lib

    Adicionando a lib na solução:

    <blockquote>dotnet sln add Api.CrossCutting</blockquote>
    <blockquote>dotnet sln add Api.Data</blockquote>

    depois pode buildar usando <blockquote>dotnet build</blockquote>



# Criando e configurando uma Entidade!

- Uma Entidade é ultilizada para representar uma tabela de dados, a entidade "BaseEntity" é a classe que tem as propriedades padrão, propriedades que toda entidade vai ter, ela foi criada separada pra que toda entidade herda ela!

    <blockquote>

        public abstract class BaseEntity
        {
            [Key]
            public Guid Id { get; set; }

            private DateTime? _createAt;
            public DateTime? CreateAt
            {
                get { return _createAt; }
                set { _createAt = (value == null ? DateTime.UtcNow : value); }
            }

            public DateTime? UpdateAt { get; set; }
        }


        public class UserEntity : BaseEntity
        {
            public string Name { get; set; }

            public string Email { get; set; }

        }
    </blockquote>



# Instalando e configurando o EntityFrameWork

Site: https://www.nuget.org/

- Instala no projeto "Data", os 3 pacotes do EntityFrameWorkCore version 2.2.6 

    O ef não faz mais parte do dotnet core, depois da versão 3, devemos instalar o dotnet-ef de forma global!

    <blockquote>dotnet tool install --global dotnet-ef --version 3.0.0</blockquote>

    Pacotes:

    <blockquote>dotnet add package Microsoft.EntityFrameworkCore.Tools --version 2.2.6</blockquote>

    <blockquote>dotnet add package Microsoft.EntityFrameworkCore.Design --version 2.2.6</blockquote>

    <blockquote>dotnet add package Pomelo.EntityFrameworkCore.MySql --version 2.2.6</blockquote>



- Criando uma referencia do projeto "Domain" para o projeto "Data"!

    Execute na pasta /src digita o comando: 

    <blockquote>dotnet add .\Api.Data\ reference .\Api.Domain\</blockquote>



- Criando as pastas da configuração no projeto "Data"!

    Foi criada as pastas: "Context", "Mapping" e "Repository"

    <blockquote>md nomeDaPasta</blockquote>



- Criando e configurando o arquivo da classe "MyContext.cs"

    1° A classe "MyContext" fica dentro da pasta "Context", ela herdada uma classe chamada 'DbContext',
    cria uma propriedade(prop) chamada 'User' do tipo generico DbSet< T>,
    aonde T recebe a entidade que deve ser mapeada!

    <blockquote>public DbSet< UserEntity> Users { get; set; }</blockquote>

    2° No método construtor da classe MyContext.cs, se passa um parametro chamado "options",
    do tipo generico DbContextOptions< T>, aonde T é a propria classe de contexto, criando uma configração de base!

    <blockquote>public MyContext(DbContextOptions< MyContext> options) : base(options){}</blockquote>

    3° Foi feito um override da classe OnModelCreating(), aonde recebe o ModelBuilder como parametro!

    <blockquote>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    </blockquote>



- Criando e configurando o arquivo de classe "CotextFactory.cs", prove uma conexao com o banco de dados!

    1° Dentro da pasta Context cria uma classe chamada 'CotextFactory', depois implementa uma interface chamada  'IDesignTimeDbContextFactory< T>', tipando a interface com a classe "MyContext"

    2° No método do contrato cria uma variavel(connectionString) para receber a sua connectionString!
    e outra variavel(optionsBuilder) para receber uma instancia de DbContextOptionsBuilder< T>(), tipando com MyContext;

    3° Com o a variavel(optionsBuilder), use o método optionsBuilder.UseMySql(connectionString), 
    passando o "connectionString" como parametro!

    4° Retorne uma instancia do MyContext, recebendo o "optionsBuilder.Options" como parametro!

    Com isso você consegue criar as migrações!

    <blockquote>    
    public class ContextFactory : IDesignTimeDbContextFactory< MyContext>
    {     

        public MyContext CreateDbContext(string[] args)
        {         

            //Usando para criar a migrações              
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=root123";

            var optionsBuilder = new DbContextOptionsBuilder< MyContext>();

            optionsBuilder.UseMySql(connectionString);

            return new MyContext(optionsBuilder.Options);

        }

    }

    </blockquote>




- Criando Mapeamento das classes no EF

    Cria uma classe com nome de "UserMap", "User" é o nome da tabela, na pasta Mapping, implementa a interface generica do tipo da classe da sua Domain!

    <blockquote> IEntityTypeConfiguration< UserEntity> </blockquote>

    Bota as referencias, e implementa a interface, assim aparece um método para você criar regras para a tabela do banco e suas propriedades!

    <blockquote>
    public void Configure(EntityTypeBuilder< UserEntity> builder){

            //Definindo o nome da tabela
            builder.ToTable("User");

            //Definindo a chave primaria            
            builder.HasKey(p => p.Id);

            //Criando um Index e Definindo como campo unico
            builder.HasIndex(p => p.Email)
                   .IsUnique();

            //Criando uma propriedade
            //E definindo como obrigatorio e um tamanho maximo
            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(60);

            //Definindo um tamanho maximo
            builder.Property(u => u.Email)
                   .HasMaxLength(100);
    }
    </blockquote>

    Configura o mapeamento no context

    <blockquote>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Depois de criar o mapeamento, chama o método que faz a configuração!                        
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }
    </blockquote>


- Configurando a migração!

    No prompt comando entra na pasta Api.Data, o unico projeto que tem o EF, para digitar o comando:

    <blockquote> dotnet ef --help</blockquote> esse comando informa os comandos principais do EF! 

    Adicionando uma configuração na migração!

    <blockquote>dotnet ef migrations add UserMigration</blockquote>

    - -UserMigration nome da migração, pode ser chamado de "First_Migration" caso seja a primeira!

    No arquivo "ContextFactory" você alem de por a senha e usuario do servidor MySql, define o banco da migração, caso seja a primeira migração, cria um nome para o seu banco de dados!

    Comando que atualiza a migração!

    <blockquote>dotnet ef database update</blockquote>

# Como atualizar uma tabela

- Com a tabela criada e com a primeira migração já feita!

    1° Devemos criar uma nova propriedade ou remover da entidade e por final executar o comando que atualiza a migração, porem coso queira uma nova tabela, cria uma nova entidade!

    2° No arquivo "MyContext" cria uma propriedade do tipo DbSet<T>, o T você troca pela entidade da nova tebela, caso queira criar uma nova tabela!

    <blockquote> public DbSet< NovaEntidade> Users { get; set; }</blockquote>

    3° Na pasta Mapping cria um novo arquivo de mapeamento, caso tenha criado uma nova tabela

    4° No arquivo "MyContext", dentro do método "OnModelCreating" chama a nova configuração de mapeamento, caso tenha criado uma nova tabela!

    <blockquote> modelBuilder.Entity< NovaEntidade>(new UserMap().Configure);</blockquote>

    5° Executa o comando para atualizar a migração!
    
    <blockquote>dotnet ef database update</blockquote>

# Criando o Repositorio (#56)

- No Projeto Api.Domain cria um arquivo de Interface chamado "IRepository", que tenha um tipo generico < T> , Aonde T tenha herança de BaseEntity, criad o CRUD generico, todo os métodos é tratado com o retorno Task< T> para informar que o método é Async!

    <blockquote>

    public interface IRepository<T> where T : BaseEntity
    {

        Task<T> InsertAsync(T item);

        Task<T> UpdateAsync(T item);

        Task<bool> DeleteAsync(Guid id);

        Task<T> SelectAsync(Guid id);

        Task<IEnumerable<T>> SelectAcync();
        
    }

    </blockquote>

    A interface é a penas um contrato aonde tem o nome, retorno e parametros dos métodos, o seu corpo é vazio!


- Implementando a Interface em uma classe base generica!

    Na pasta de "Repository" que fica no projeto Api.Data, cria um classe chamada "BaseRepository"!

    Esta classe vai servir para implementar a interface "IRepository", vai aparecer varios métodos da interface "IRepository" para poder criar o conteudo do corpo de cada uma das classes, porem antes disso deve criar o contrutor da classe(ctor + 2xTAB), com isso você faz uma injeção de dependencia da classe "MyContext" passando um parametro na classe contrutora com o tipo "MyContext", essa classe faz conexão com o banco!

    Cria uma variavel chamada "_context" para atribuir o parametro do tipo "MyContext"

    Cria uma variavel chamada "_dataset" para atribuir _context.Set< T>();

    <blockquote>

    protected readonly MyContext _context;

    private DbSet< T> _dataset;

    public BaseRepository(MyContext context)
    {

        _context = context;

        _dataset = _context.Set< T>();

    }

    </blockquote>
    

- Método insert do formato async!

    <blockquote>

    public async Task< T> InsertAsync(T item)

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

            //o termo await faz parte do método async, salva o objeto usando o contexto
            await _context.SaveChangesAsync();

        }
        catch (Exception ex)
        {

            throw ex;

        }

        return item;

    }

    </blockquote>

- Método update do formato async!

    <blockquote>

    public async Task< T> UpdateAsync(T item)

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

    </blockquote>

- Método deletar do formato async!

    <blockquote>

    public async Task< bool> DeleteAsync(Guid id)

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

    }

    </blockquote>

- Método que seleciona todos de forma async!

    <blockquote>

    public async Task< IEnumerable< T>> SelectAcync()

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

    </blockquote>

- Método async que seleciona um objeto pelo ID

    <blockquote>

    public async Task< T> SelectAsync(Guid id)
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

    <blockquote>

- Método async que verifica se tem 

    <blockquote>

    public async Task<bool> ExistAsync(Guid id)
    {

        return await _dataset.AnyAsync(p => p.Id.Equals(id));
        
    }

    </blockquote>


# Implementando o Service (Api.Service)


- 1° cria uma interface no projeto de Domain, com os contratos!

    <blockquote>

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

    }

    </blockquote> 



- 2° Cria referencias para a Service!

    <blockquote>dotnet add .\Api.Service\ reference .\Api.Domain\</blockquote> 

    <blockquote> dotnet add .\Api.Service\ reference .\Api.Data\</blockquote> 

     

- 3° A implementação

    Cria uma pasta chamada Service, e dentro dela uma classe chamada "UserService", implementa a interface UserService, passa as referencias para tirar os erros, e implementa a interface para poder exibir os métodos do contrato!


    <blockquote>

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

    <blockquote>


    Em cada método desse é possivel por as regras de negocio, o projeto de Api.Service serve para ser um intermediario do projeto Api.Aplicação para a Api.Infra/Data ! 
    OBS: não se deve por validação! 



# Tratando o projeto Api.Aplication


- Criando a classe de controle!    

    Adicione algumas referencias no projeto Api.Aplication !!

    <blockquote>dotnet add Api.Application reference Api.Domain</blockquote>

    <blockquote>dotnet add Api.Application reference Api.Service</blockquote>

    <blockquote>dotnet add Api.Application reference Api.CrossCutting</blockquote>

    Cria uma classe com nome de "UsersController"

    Criando o GetAll com tratamento

    <blockquote>

        [ HttpGet]

        //faz referencia do service

        public async Task< ActionResult> GetAll([FromServices] IUserService service) 
               
        {

            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {

                //400 bad request - solicitação invalida!
                return BadRequest(ModelState); 

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

    <blockquote>

    vai da erro precisa tratar a injeção de dependencia e o projeto CrossCutting


- Adiciona mais ferefencia no projeto Api.CrossCutting

    <blockquote>dotnet add .\Api.CrossCutting\ reference .\Api.Domain\</blockquote>

    <blockquote>dotnet add .\Api.CrossCutting\ reference .\Api.Service\</blockquote>

    <blockquote>dotnet add .\Api.CrossCutting\ reference .\Api.Data\</blockquote>

    Vai aparecer outro erro de , referencia circular , para re solver re mova a referencia CrossCutting do projeto de service

- instala o AutoMaper

    <blockquote>dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 7.0.0</blockquote>




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


# Resolvendo problema com politica de requisição

https://stackoverflow.com/questions/54085677/how-to-configure-angular-6-with-net-core-2-to-allow-cors-from-any-host