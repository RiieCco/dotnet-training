FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Products.API/Products.API.csproj Products.API/
RUN dotnet restore Products.API/Products.API.csproj
COPY . .
WORKDIR /src/Products.API
RUN dotnet build Products.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Products.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Products.API.dll"]
