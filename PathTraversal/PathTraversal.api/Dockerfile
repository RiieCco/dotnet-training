FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY PathTraversal.api/PathTraversal.api.csproj PathTraversal.api/
RUN dotnet restore PathTraversal.api/PathTraversal.api.csproj
COPY . .
WORKDIR /src/PathTraversal.api
RUN dotnet build PathTraversal.api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PathTraversal.api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PathTraversal.api.dll"]
