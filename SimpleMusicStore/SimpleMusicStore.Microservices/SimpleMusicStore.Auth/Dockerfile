FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["SimpleMusicStore.Microservices/SimpleMusicStore.Auth/SimpleMusicStore.Auth.csproj", "SimpleMusicStore.Microservices/SimpleMusicStore.Auth/"]
RUN dotnet restore "SimpleMusicStore.Microservices/SimpleMusicStore.Auth/SimpleMusicStore.Auth.csproj"
COPY . .
WORKDIR "/src/SimpleMusicStore.Microservices/SimpleMusicStore.Auth"
RUN dotnet build "SimpleMusicStore.Auth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleMusicStore.Auth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleMusicStore.Auth.dll"]