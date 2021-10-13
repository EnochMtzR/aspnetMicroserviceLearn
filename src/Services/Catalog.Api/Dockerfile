FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/services/Catalog.Api/", "Services/Catalog.Api/"]
RUN dotnet restore "Services/Catalog.Api/Catalog.API.csproj"
COPY . .
WORKDIR "/src/Services/Catalog.Api"
RUN dotnet build "Catalog.API.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.API.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.API.dll"]