FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Deserialization.API/Deserialization.API.csproj Deserialization.API/
RUN dotnet restore Deserialization.API/Deserialization.API.csproj
COPY . .
WORKDIR /src/Deserialization.API
RUN dotnet build Deserialization.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Deserialization.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Deserialization.API.dll"]
