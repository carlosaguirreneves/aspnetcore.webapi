FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build-env

WORKDIR /app

EXPOSE 80

COPY . ./
RUN dotnet restore 
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim

WORKDIR /app

COPY ./AspnetCore.WebAPI/Data ./Data
COPY --from=build-env /app/AspnetCore.Domain/out .
COPY --from=build-env /app/AspnetCore.Repository/out .
COPY --from=build-env /app/AspnetCore.Util/out .
COPY --from=build-env /app/AspnetCore.WebAPI/out .

ENTRYPOINT ["dotnet", "AspnetCore.WebAPI.dll"]