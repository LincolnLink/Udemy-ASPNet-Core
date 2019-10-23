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



# Criando uma aplicação em WebApi

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