FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["SimpleMusicStore.Api/SimpleMusicStore.Api.csproj", "SimpleMusicStore.Api/"]
RUN dotnet restore "SimpleMusicStore.Api/SimpleMusicStore.Api.csproj"
COPY . .
WORKDIR "/src/SimpleMusicStore.Api"
RUN dotnet build "SimpleMusicStore.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleMusicStore.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleMusicStore.Api.dll"]