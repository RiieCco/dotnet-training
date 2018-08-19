FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ParameterBinding.API/ParameterBinding.API.csproj ParameterBinding.API/
RUN dotnet restore ParameterBinding.API/ParameterBinding.API.csproj
COPY . .
WORKDIR /src/ParameterBinding.API
RUN dotnet build ParameterBinding.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ParameterBinding.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ParameterBinding.API.dll"]
