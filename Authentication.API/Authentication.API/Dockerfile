FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Authentication.API/Authentication.API.csproj Authentication.API/
RUN dotnet restore Authentication.API/Authentication.API.csproj
COPY . .
WORKDIR /src/Authentication.API
RUN dotnet build Authentication.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Authentication.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Authentication.API.dll"]
