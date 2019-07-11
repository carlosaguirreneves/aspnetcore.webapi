FROM microsoft/dotnet:2.2-sdk AS build-env

WORKDIR /app

EXPOSE 80

COPY . ./
RUN dotnet restore 
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime

WORKDIR /app

COPY --from=build-env /app/Desafio.Domain/out .
COPY --from=build-env /app/Desafio.Repository/out .
COPY --from=build-env /app/Desafio.Util/out .
COPY --from=build-env /app/Desafio.WebAPI/out .

ENTRYPOINT ["dotnet", "Desafio.WebAPI.dll"]