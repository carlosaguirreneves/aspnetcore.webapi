FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build-env

WORKDIR /app

EXPOSE 80

COPY . ./
RUN dotnet restore 
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim

WORKDIR /app

COPY --from=build-env /app/Desafio.Domain/out .
COPY --from=build-env /app/Desafio.Repository/out .
COPY --from=build-env /app/Desafio.Util/out .
COPY --from=build-env /app/Desafio.WebAPI/out .

ENTRYPOINT ["dotnet", "Desafio.WebAPI.dll"]