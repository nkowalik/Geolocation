FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Geolocation.Api/Geolocation.Api.csproj", "Geolocation.Api/"]
RUN dotnet restore "Geolocation.Api/Geolocation.Api.csproj"
COPY . .
WORKDIR "/src/Geolocation.Api"
RUN dotnet build "Geolocation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Geolocation.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Geolocation.Api.dll"]