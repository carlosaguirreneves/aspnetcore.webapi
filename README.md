# DotnetCore WebAPI

Esta aplicação visa implementar um simples projeto Web API apenas para demonstrar a utilização do .NetCore 2.2 Web API usando EntityFrameworkCore e, para não deixar a API aberta ao público, foi implementado autenticação usando o padrão Token JWT. Neste projeto você vai encontrar os seguintes recursos:

 - EntityFrameworkCore: Para gerar e acessar o banco de dados Sqlite. Está disponível em ./AspnetCore.WebAPI/Data/BancoSqLite.db
 - Autenticação: Para atender o requisito de statuscode 401 descrito no Contato.yaml
 - Swagger: Após rodar a aplicação abrir o browser com a URL http://localhost:5000/swagger/
 - Postman: Para cobrir alguns cenários de testes.

## Executando a aplicação localmente

Para executar a aplicação localmente e rodar os testes de integração automatizados, basta seguir os seguintes passos abaixo.

Passo 1: Instalar os seguintes frameworks.

- DotNet Core 2.2.300
- NodeJs

Passo 2: Instalar o plugin do Postman

- npm install -g newman

Passo 3: Executar os comandos para rodar a aplicação. Necessário estar dentro do diretório de startup do projeto: AspnetCore.WebAPI

- cd AspnetCore.WebAPI
- dotnet restore
- dotnet build
- dotnet run

Passo 4: Com o seguinte comando é possível executar os testes de integração. É necessário estar na raiz do projeto.

Executar usando Postman:
- newman run IntegrationTest.postman_collection.json --global-var="url=http://localhost:5000"

Executar usando .Net Core Xunit:
- dotnet test

Passo 5: Para ver os endpoints que foram criados e os cenários de testes implementados, você deve importar o arquivo IntegrationTest.postman_collection.json no Postman.

## Executando a aplicação em Container Docker

Caso você queria executar a aplicação em um container docker siga os seguintes passos abaixo:

### Pré requisito

- Docker
- Docker Compose

### Executando o container

O comando abaixo cria a imagem e executa o container. Após rodar o comando a aplicação já estará disponível através da url: http://localhost:5000/swagger. Todos os campos devem ser executados dentro do diretório raiz da aplicação.

- docker-compose build && docker-compose up

O seguite comando encerra o processo responsável pelo container.

- docker-compose down

## Comandos úteis do Docker Compose

Abaixo segue alguns comandos que são úteis quando se trabalha com Docker usando Docker Compose.

- docker config: Exibe as configurações do arquivo docker-compose.yml

- docker-compose build: Cria a imagem que é usada para executar o container.

- docker-compose up: Executa o container.

- docker-compose down --rmi all: Encerrar o processo, remove a imagem e os recursos alocados.
