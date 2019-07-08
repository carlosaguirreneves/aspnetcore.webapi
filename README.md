## Desafio DotnetCore

Para implementação da API Contato, utilizei DotNet Core 2.2 (WebApi).
Adicionei ao projeto os recursos:

 - EntityFramewordCore: Para acessar e gerar ao banco de dados. Utilizei o Sqlite apenas para nível de teste.
 - Autenticação: Para atender o requisito de statuscode 401 descrito no contato.yml
 - Swagger: Após rodar a aplicação abrir o browser com a URL http://localhost:5000/swagger/
 - Postman: Para cobrir alguns cenários de testes.

Passo 1: Instalar os seguintes frameworks.

- DotNet Core 2.2.300
- NodeJs

Passo 2: Instalar o plugin do Postman

npm install -g newman

Passo 3: Executar os comandos para rodar a aplicação. Necessário estar dentro do diretório startup de projeto: Desafio.WebAPI

cd Desafio.WebAPI
dotnet restore
dotnet build
dotnet run

Passo 4: Com o seguinte comando é possível executar os testes de integração.

newman run Desafio.postman_collection.json
