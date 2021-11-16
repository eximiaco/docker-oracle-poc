FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["docker-oracle-poc/docker-oracle-poc.csproj", "docker-oracle-poc/"]
RUN dotnet restore "docker-oracle-poc/docker-oracle-poc.csproj"
COPY . .
WORKDIR "/src/docker-oracle-poc"
RUN dotnet build "docker-oracle-poc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "docker-oracle-poc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "docker-oracle-poc.dll"]
