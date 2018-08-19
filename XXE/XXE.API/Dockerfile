FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY XXE.API/XXE.API.csproj XXE.API/
RUN dotnet restore XXE.API/XXE.API.csproj
COPY . .
WORKDIR /src/XXE.API
RUN dotnet build XXE.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish XXE.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "XXE.API.dll"]
