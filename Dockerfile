FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
# Copia los archivos .csproj
COPY ["WebApi/WebApi.csproj", "WebApi/"]
COPY ["UseCases/UseCases.csproj", "UseCases/"]
COPY ["Persistence/Persistence.csproj", "Persistence/"]
COPY ["Adapters/Adapters.csproj", "Adapters/"]
COPY ["Domain/Domain.csproj", "Domain/"]
# Restaura las dependencias
RUN dotnet restore "WebApi/WebApi.csproj"
COPY . .

# Construye la aplicación
WORKDIR "/src/WebApi"
RUN dotnet build "WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build
# Publica la aplicación
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
# Copia todo desde el directorio de publicación al contenedor
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]
