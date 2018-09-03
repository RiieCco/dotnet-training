FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Dependencies/Dependencies.csproj Dependencies/
RUN dotnet restore Dependencies/Dependencies.csproj
COPY . .
WORKDIR /src/Dependencies
RUN dotnet build Dependencies.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Dependencies.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Dependencies.dll"]
