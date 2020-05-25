# Udemy-ASPNet-Core
Desenvolvendo uma API com ajuda de um curso da Udemy

- [x] Dot.Net 2.2/3.0/3.1
- [x] MySQL
- [x] Entity Framework Core 2.2.6
- [x] Swagger 4.0.1
- [x] SQL Server 2017 express
- [x] JWT 6.6.0

# Extension install

- [x] C#
- [x] C# Extensions
- [x] C# XML Documentation Comments
- [x] vscode-icons

# Programas

- [x] cmd personalizado: https://cmder.net/
- [x] Visual Studio Code

# Link's Que me ajudou com o projeto

- Comandos do GitHub

    https://gist.github.com/leocomelli/2545add34e4fec21ec16

- Curso do DotNet Core 2.2/3.0/3.1

    https://www.udemy.com/course/aspnet-core-22-c-api-com-arquitetura-ddd-na-pratica/


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

- Comando para criar uma solution!

    <blockquote>dotnet new sln --name CSharpBasico</blockquote>

- Comando que lista opções de projetos!

    <blockquote>dotnet new</blockquote>

- Comando para criar um projeto, com uma pasta!

    <blockquote>dotnet new console -n HelloWorld -o helloWorld</blockquote>

    - -n: nome do projeto console!
    - -o: nome da pasta!

- Comando que Vincula um projeto a uma solução existente

    <blockquote>dotnet sln add 'nomeDoProjeto'</blockquote>

- Comando que limpando a aplicação

    <blockquote>dotnet clean</blockquote>

- Comando que restalra a aplicação

    <blockquote>dotnet restore</blockquote>

- Comando para Buildar a aplicação!

    <blockquote>dotnet build</blockquote>

- Comando que Executa um projeto

    <blockquote>dotnet run</blockquote>

- Comando que Abre o codigo no VS code

    <blockquote>code .</blockquote>

- Comando que criando uma pasta

    <blockquote>md "nome da pagina"</blockquote>



# Configurando o VS code para dotnet core (#33)

- Aconfiguração está na video aula #33

    <blockquote> files -> referencia -> settings</blockquote>



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

    - UserMigration nome da migração, pode ser chamado de "First_Migration" caso seja a primeira!

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


# Configurando o projeto Api.CrossCutting

- Adiciona mais ferefencia no projeto Api.CrossCutting

    <blockquote>dotnet add .\Api.CrossCutting\ reference .\Api.Domain\</blockquote>

    <blockquote>dotnet add .\Api.CrossCutting\ reference .\Api.Service\</blockquote>

    <blockquote>dotnet add .\Api.CrossCutting\ reference .\Api.Data\</blockquote>

    Vai aparecer um erro de referencia circular, para resolver remova a referencia CrossCutting do projeto de service, caso tenha!

- instala o AutoMaper no projeto Api.CrossCutting

    Comando que cria o AutoMaper

    <blockquote>
        dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 7.0.0
    </blockquote>


# Configurando a Injeção de dependencia

- Configurando a Injeção de dependencia do serviço!

    O projeto Api.CrossCutting, serve para o projeto Api.Aplication continuar não tendo acesso ao projeto Api.Data, por isso se deve por a configuração de Injeção de Dependencia nesse projeto, também serve para deixar a classe Startup mais limpa!

    No projeto Api.CrossCutting cria uma pasta com o nome de "DependencyInjection"!
    Nessa pasta crie um arquivo chamado "ConfigureService"!
    Cria um método static para que seja chamado, sem precisar criar objeto!

    <blockquote>

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

            //método .AddScoped: usa a mesma instancia(usar em conexão de banco).

            serviceCollection.AddTransient<IUserService, UserService>();

        }

    }

    </blockquote>

    No método "ConfigureServices" da classe "Startup" do projeto Api.Aplication, chama a classe de configuração das Injeção de dependencia, passando o parametro padrão que o método "ConfigureServices" recebe, exemplo: 

    <blockquote>

        public void ConfigureServices(IServiceCollection services)        
        {

            /// Configuração da Injeção de dependencia do serviço

            ConfigureService.ConfigureDependenciesService(services);

            /// Configuração da Injeção de dependencia do repositorio

            ConfigureRepository.ConfigureDependenciesRepository(services);

        }

    </blockquote>

- Configurando a Injeção de dependencia do repositorio!

    Na pasta "DependencyInjection" cria uma classe chamada "ConfigureRepository"
    Nessa classe cria um método static chamado "ConfigureDependenciesRepository"
    Quando a Interface é generica se deve por o método "typeof()"!    

    <blockquote>
        public class ConfigureRepository
        {

            public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
            {

                //método .AddSingleton: ele não muda a instancia.

                //método .AddTransient: sempre cria uma nova instancia.

                //método .AddScoped: usa a mesma instancia.

                serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

                serviceCollection.AddDbContext<MyContext>( options => 
                options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=84190162")

                );

            }

        }

    </blockquote>

# Criando a classe de controle (projeto Api.Aplication)  

- 1° Adicione algumas referencias no projeto Api.Aplication !!

    <blockquote>dotnet add Api.Application reference Api.Domain</blockquote>

    <blockquote>dotnet add Api.Application reference Api.Service</blockquote>

    <blockquote>dotnet add Api.Application reference Api.CrossCutting</blockquote>

- 2° Cria uma classe com nome de "UsersController"

    Toda classe de controller deve herdar a classe ControllerBase, para ser reconhecida como um controle!
    No método construtor bota um injeção de dependencia da interface "IUserService"!

    <blockquote>

        //Define uma rota, define que é o controle de uma API! e não de MVC
        [ Route(" api/[controller]")] 

        //Define que é WebApi
        [ ApiController] 

        public class UsersController : ControllerBase
        {

            private IUserService _service;
            public UsersController(IUserService service)
            {
                _service = service;
            }

        }
    
    </blockquote>

- GetAll

    No codigo o parametro que declada um serviço: "[ FromServices] IUserService service" foi removido

    "ModelState.IsValid" é uma variavel do proprio ASP.NET Core, que serve para validar oque está vindo na rota!

    ArgumentException: Trata erro de controller!

    <blockquote>

        [ HttpGet] 
        public async Task< ActionResult> GetAll()                
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

    Vai da erro na injeção de dependencia, precisa configurar a injeção de dependencia no projeto CrossCutting para dar continuidade ao controle!

- Get

    <blockquote>

        [ HttpGet]    
        [ EnableCors("CorsPolicy")]
        [Route("{id}", Name = "GetWithId")]
        public async Task< ActionResult> Get(Guid id)
        {
            //Verifica se a informação que está vindo da rota é valida!
            
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState); //400 bad request - solicitação invalida!

            }

            try
            {

                return Ok(await _service.Get(id));

            }
            catch (ArgumentException e) //trata erros de controller!
            {

                //Resposta para o navegador! - erro 500

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);

            }

        }

    </blockquote>

- Post

    <blockquote>

        [HttpPost]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult> Post([FromBody] UserEntity user)
        {
            
            //Verifica se a informação que está vindo da rota é valida!
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }

            try
            {

                var result = await _service.Post(user);
                if (result != null)
                {

                    return Created(new Uri(Url.Link("GetWithId", new { id = result.Id })), result);

                }
                else
                {

                    return BadRequest();

                }

            }
            catch (ArgumentException e)
            {

                //Resposta para o navegador! - erro 500

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);

            }
        }

    </blockquote>

- Put

    <blockquote>

        [ HttpPut]

        [ EnableCors("CorsPolicy")]

        public async Task<ActionResult> Put([FromBody] UserEntity user)
        {

            //Verifica se a informação que está vindo da rota é valida!

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }

            try
            {

                var result = await _service.Put(user);

                if (result != null)
                {

                    return Ok(result);

                }
                else
                {

                    return BadRequest();

                }

            }
            catch (ArgumentException e)
            {

                //Resposta para o navegador! - erro 500

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);

            }

        }

    </blockquote>

- Delete 

    <blockquote>

        [ HttpDelete("{id}")] //("{id}")
        [ EnableCors("CorsPolicy")]

        public async Task< ActionResult> Delete(Guid id)
        {

            //Verifica se a informação que está vindo da rota é valida!

            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);

            }

            try
            {

                var result = await _service.Delete(id);

                if (result)
                {

                    return Ok(result);

                }
                else
                {

                    return BadRequest();

                }

            }
            catch (ArgumentException e)
            {

                //Resposta para o navegador! - erro 500

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);

            }

        }

    </blockquote>


# Instalando e usando o Swagger! no projeto Api.Application

- Procura o "Swashbuckle.Aps.NetCore" no nuget

    https://www.nuget.org/packages/Swashbuckle.AspNetCore/5.0.0-rc4

    Documentação: 
    https://github.com/domaindrivendev/Swashbuckle.AspNetCore

    foi instalada na Api.Application !

    Escolhe a opção: .Net CLI !

    <blockquote> dotnet add package Swashbuckle.AspNetCore --version 4.0.1</blockquote>    
    

- Configuração do Swagger! (antes do addMVC)

    Configuração feita na classe Startup, no método "ConfigureServices()"

    <blockquote>

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

    </blockquote>



- Ativando middlewares paa uso do Swagger (no método Configure, antes do app.usemvc)

    Configuração feita na classe Startup, no método "Configure"

    <blockquote>

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = string.Empty;
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API com AspNetCore 2.2");
    });

    </blockquote>


- Redireciona o Link para o Swagger, quando acessar a rota principal (no método Configure, antes do app.usemvc)

    <blockquote>

        var option = new RewriteOptions();
        option.AddRedirect("^$", "swagger");
        app.UseRewriter(option);

    </blockquote>


# Resolvendo problema com politica de requisição

- Solução para politica de requisição, deve por um metadata em cada endpoint

    https://stackoverflow.com/questions/54085677/how-to-configure-angular-6-with-net-core-2-to-allow-cors-from-any-host

    Configure na classe "Startup" no método "Configure"

    <blockquote>

    app.UseCors("CorsPolicy");

    </blockquote>

# Instalando SQL no projeto!

- Microsoft® SQL Server® 2017 Express    

    https://www.microsoft.com/pt-br/download/details.aspx?id=55994 

- SQL Server Management Studio

    https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15

- Instalando o pacote do SQL no projeto Api.Data

    Microsoft EntityFrameworkCore SqlServer (Versão 2.2.6)
    <blockquote>
        dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 2.2.6
    </blockquote>

    Microsoft EntityFrameworkCore SqlServer Design
    <blockquote>
        dotnet add package Microsoft.EntityFrameworkCore.SqlServer.Design --version 1.1.6
    </blockquote>

- Configurando o pacote do SQL no projeto Api.Data na classe "ContextFactory"

    Troca a connectionString do MySql pela do SqlServe

    - Antiga

    <blockquote>
    var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=root123";
    optionsBuilder.UseMySql(connectionString);
    </blockquote>

    - Nova

    <blockquote>
    var connectionString = "Server=.\ \SQLEXPRESS2017;Database=dbAPI;User Id=sa;Password=root123";
    optionsBuilder.UseSqlServer(connectionString);
    </blockquote>

    Quando trocar executa o comando do EF para atualizar!

    <blockquote>dotnet ef database update</blockquote>

- No projeto Api.CrossCutting na classe "ConfigureRepository", deve trocar a conexão do MySql pela do SqlServer!

    - Antiga

    <blockquote> 

    serviceCollection.AddDbContext< MyContext>(

    options => options.UseMySql("Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=root123")

    );
    
    </blockquote>

    - Nova

    <blockquote> 
    
    serviceCollection.AddDbContext< MyContext>(
        options => options.UseSqlServer("Server=.\ \SQLEXPRESS2017;Database=dbAPI;User Id=sa;Password=root123")
    );
    
    </blockquote>

# Migração automatica (Opcional)

    No método construtor da classe "MyContext()" foi colocado um método!

    <blockquote>
        Database.Migrate();
    </blockquote>


# JWT

- JWT(JSON Web Token) é um sistema de transferência de dados que pode ser enviado via POST ou em um cabeçalho HTTP (header).
    JWT é um padrão de mercado que define um token em formato JSON para troca de informações leve e segura!

- Características: 

    - Leve: Adota Json para troca de informação

    - AutoContido: Traz consigo toda as informação necessárias para o seu processamento

    - Seguro: Ultiliza Algoritimo de hashing para validação da integridade do token

- Quando Ultilizar o JWT

    - Para troca de informação entre aplicações

    - Em mecanismo de Autenticação como por exemplo Autenticar Pessoas em Endpoint que não são púclicos

    Como um Token você deixa de ficar fazendo login a cada requesição enviada em cada requisição REST, isto deixa seus endpoint mais leves, eficiente e Segura.

    Token tem uma validade quando seu prazo termina o token vai ser descartado.

- Resumo: Quando se loga pela primeira vez é gerado um token que tem um tempo de vida curto(2h), quando o usuario precisa fazer outra requisição, é enviado apenas o token, para não precisar ter que fazer outra requisição! 

- O JWT é dividido em 3 partes!

    - header
    - payload
    - signature

- Criando um método de extensão para criar um método que faça login(Começando no projeto Api.Data e Api.Domain)

    - Criando uma Interface que tem o método extendido que trata o login do Usuario

    Cria uma pasta com o nome de "Repository" no projeto Api.Domain, dentro da pasta cria uma interface chamada "IUserRepository", aonde Implementa a interface "IRepository< UserEntity>"


    <blockquote>
            
        namespace Api.Domain.Interfaces
        {
            public interface IUserRepository: IRepository< UserEntity>
            {

                Task<UserEntity> FindByLogin (string email);
            }
        }
    </blockquote>

    - Criando uma classe que implementa a interface que tem o método extendido que trata o login do Usuario!

    Cria uma pasta com o nome "Implementations" no projeto Api.Data, na pasta cria uma classe com o nome "UserImplementation", que herda a classe "BaseRepository< UserEntity>" e implementa a interface "IUserRepository", para fazer o método extendido ter um corpo!

    <blockquote>

        public class UserImplementation: BaseRepository< UserEntity>, IUserRepository
        {
            private DbSet<UserEntity> _dataset;

            public UserImplementation(MyContext context) : base(context)
            {

                _dataset = context.Set< UserEntity>();

            }

            public async Task< UserEntity> FindByLogin(string email)
            {

                return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));

            }
        }

    </blockquote>
    

- Método de Login no projeto Api.Service

    - Cria uma interface com o nome de "ILoginService", na pasta "Service/User" no projeto "Api.Domain"!

    <blockquote> 

    public interface ILoginService
    {
         Task< object> FindByLogin(UserEntity user);
    }

    </blockquote>

    - Cria uma classe chamada "LoginService" no projeto "Api.Service", aonde ele implementa a interface "ILoginService"

    <blockquote>

        public class LoginService : ILoginService
        {
            private IUserRepository _repository;

            public LoginService(IUserRepository repository )
            {

                _repository = repository;

            }

            public async Task<object> FindByLogin(UserEntity user)
            {
                if(user != null && !string.IsNullOrWhiteSpace(user.Email))
                {

                    return await _repository.FindByLogin(user.Email);

                }
                else
                {

                    return null;

                }
            }
        }

    </blockquote>

- Método de Login no projeto Api.Application

    Crie uma classe chamada "LoginController", herda a classe "ControllerBase"!

    - Nesse exemplo de controller, a injeção de dependencia vai ser diretamente no método!

    <blockquote>

        [Route("login/[controller]")] //Define um roteamento
        [ApiController] //Define que é WebApi
        public class LoginController: ControllerBase
        {   

            [HttpPost]
            [EnableCors("CorsPolicy")]
            public async Task<ActionResult> Login([FromBody] UserEntity userEntity,[FromServices] ILoginService service)
            {                
                //Verifica se a informação que está vindo da rota é valida!
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if(userEntity == null)
                {
                    return BadRequest();
                }

                try
                {
                    var result =  await service.FindByLogin(userEntity);
                    if(result != null )
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                catch(ArgumentException e){

                    //Resposta para o navegador! - erro 500
                    return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);

                }

            }
        }
    </blockquote>

# DTO - Data Transfer Object (É como se fosse a MODEL do MVC)

- Crie uma pasta chamada Dtos no projeto Api.Domain, depois crie uma classe com o nome de "LoginDto", ela recebe uma propriedade string chamada "email", nessa propriedade é feita varias validações do valor!

    <blockquote>
    
        public class LoginDto
        {
            [Required(ErrorMessage = "E-mail é um campo obrigatorio para login!")]
            [EmailAddress(ErrorMessage = "E-mail com formato invalido!")]
            [StringLength(100, ErrorMessage = "Email deve ter no maximo {1} caracteres")]
            public string Email { get; set; }
        }

    </blockquote>

- Na interface "ILoginService" troca o tipo do parametro que é passado no método "FindByLogin" para o tipo "LoginDto", com isso vai dar erro em outras classe, assim você deve trocar as outras também!

    <blockquote>

        public interface ILoginService
        {
            Task<object> FindByLogin(LoginDto user);
        }

    </blockquote>

- Implementa o "LoginDto" no lugar de "UserEntity" nas operações referente ao Login!

    Ao subistituir aparece erros facil de resolver informando o "using"

    Depois disso dara erro na requisição de login caso os valores não esteja na validação!

    LoginDto avalia os dados antes mesmo de entrar na requisição !

- Implementar Classe SigningConfigurations e TokenConfigurations


    Instala o pacote! da opção .NET CLI, dentro do projeto Api.Domain!

    link do site: https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt/

    <blockquote>        

        dotnet add package System.IdentityModel.Tokens.Jwt --version 6.6.0

    </blockquote>

    Crie uma pasta no projeto Api.Domain, chamada "Security" dentro dessa pasta cria uma classe chamada "TokenConfiguration", essa classe recebe 3 propriedades!
 
    <blockquote>
    
        public class TokenConfiguration
        {
            //Publico
            public string Audience { get; set; }

            //Emissor
            public string Issuer { get; set; }

            //Segundos de validade
            public int Seconds { get; set; }
        }

    </blockquote>

    Cria uma segunda classe chamada "SigningConfigurations" na pasta "Security", ela recebe 2 propriedades!

    Uma propriedade do tipo "SecurityKey" e outra do tipo "SigningCredentials"

    No método construtor é feito uma instancia da classe "RSACryptoServiceProvider" e é passado uma chave "2048", essa chave representa o bit, uma variavel recebe essa instancia!

    Dentro do método construtor a propriedade do tipo "SecurityKey" recebe uma instancia da classe "RsaSecurityKey", e é passado a variavel por parametro!

    Quando se cria variavel usando Using, é uma forma de descartar a variavel na memoria depois de usada!

    <blockquote>

    </blockquote>

    <blockquote>

    </blockquote>












