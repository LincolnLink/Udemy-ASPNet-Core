# Udemy-ASPNet-Core
Desenvolvendo uma API com ajuda de um curso da Udemy

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

# Vinculando aplicação com solução! 

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

1° Foi criada uma pasta para o cextet e uma classe(MyContext), nela foi exdada uma classe chamada 'DbContext', iniciado uma propriedade(prop) chamada 'User' do tipo generico DbSet<T>, aonde T recebe a entidade que deve ser mapeada!

`public DbSet<UserEntity> Users { get; set; }`

2° no método construtor, é passado pelo parametro chamado options do tipo generico DbContextOptions<T>, aonde T é a propria classe de contexto! 

`public MyContext(DbContextOptions<MyContext> options) : base(options){}`

3° Foi feito um override da classe OnModelCreating(), aonde recebe o ModelBuilder como parametro!

`protected override void OnModelCreating(ModelBuilder modelBuilder)
 {
 	base.OnModelCreating(modelBuilder);
 }`

<blockquote> Criando uma fabrica de contexto</blockquote> 