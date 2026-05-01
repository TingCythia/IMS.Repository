FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY IMS.CoreBusiness/IMS.CoreBusiness.csproj IMS.CoreBusiness/
COPY IMS.UseCases/IMS.UseCases.csproj IMS.UseCases/
COPY IMS.Plugins/IMS.Plugins.InMemory/IMS.Plugins.InMemory.csproj IMS.Plugins/IMS.Plugins.InMemory/
COPY IMS.WebApp/IMS.WebApp.csproj IMS.WebApp/

RUN dotnet restore IMS.WebApp/IMS.WebApp.csproj

COPY IMS.CoreBusiness/ IMS.CoreBusiness/
COPY IMS.UseCases/ IMS.UseCases/
COPY IMS.Plugins/ IMS.Plugins/
COPY IMS.WebApp/ IMS.WebApp/

RUN dotnet publish IMS.WebApp/IMS.WebApp.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "IMS.WebApp.dll"]
