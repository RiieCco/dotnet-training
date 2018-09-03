FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY FileUpload/FileUpload.csproj FileUpload/
RUN dotnet restore FileUpload/FileUpload.csproj
COPY . .
WORKDIR /src/FileUpload
RUN dotnet build FileUpload.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish FileUpload.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FileUpload.dll"]
