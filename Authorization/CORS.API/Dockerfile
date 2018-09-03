FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY CORS.API/CORS.API.csproj CORS.API/
RUN dotnet restore CORS.API/CORS.API.csproj
COPY . .
WORKDIR /src/CORS.API
RUN dotnet build CORS.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CORS.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CORS.API.dll"]
