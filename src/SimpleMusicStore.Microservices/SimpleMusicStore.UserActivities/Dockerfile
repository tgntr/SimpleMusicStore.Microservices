FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["SimpleMusicStore.CurrentUserActivities/SimpleMusicStore.CurrentUserActivities.csproj", "SimpleMusicStore.CurrentUserActivities/"]
RUN dotnet restore "SimpleMusicStore.CurrentUserActivities/SimpleMusicStore.CurrentUserActivities.csproj"
COPY . .
WORKDIR "/src/SimpleMusicStore.CurrentUserActivities"
RUN dotnet build "SimpleMusicStore.CurrentUserActivities.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleMusicStore.CurrentUserActivities.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleMusicStore.CurrentUserActivities.dll"]