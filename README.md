## Desafio DotnetCore

Para implementação da API Contato, utilizei DotNet Core 2.2 (WebApi).
Adicionei ao projeto os recursos:

 - EntityFramewordCore: Para gerar e acessar o banco de dados Sqlite. Está disponível em ./Desafio.WebAPI/Data/Desafio.db
 - Autenticação: Para atender o requisito de statuscode 401 descrito no contato.yaml
 - Swagger: Após rodar a aplicação abrir o browser com a URL http://localhost:5000/swagger/
 - Postman: Para cobrir alguns cenários de testes.

Passo 1: Instalar os seguintes frameworks.

- DotNet Core 2.2.300
- NodeJs

Passo 2: Instalar o plugin do Postman

- npm install -g newman

Passo 3: Executar os comandos para rodar a aplicação. Necessário estar dentro do diretório de startup do projeto: Desafio.WebAPI

- cd Desafio.WebAPI
- dotnet restore
- dotnet build
- dotnet run

Passo 4: Com o seguinte comando é possível executar os testes de integração.

- newman run Desafio.postman_collection.json
