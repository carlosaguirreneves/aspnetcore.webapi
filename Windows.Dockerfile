FROM microsoft/dotnet:2.2-sdk AS build-env

WORKDIR /app

EXPOSE 80

COPY . ./
RUN dotnet restore 
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime

WORKDIR /app

COPY ./AspnetCore.WebAPI/Data ./Data
COPY --from=build-env /app/AspnetCore.Domain/out .
COPY --from=build-env /app/AspnetCore.Repository/out .
COPY --from=build-env /app/AspnetCore.Util/out .
COPY --from=build-env /app/AspnetCore.WebAPI/out .

ENTRYPOINT ["dotnet", "AspnetCore.WebAPI.dll"]