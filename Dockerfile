# Establecer la imagen base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MatrizWebApplication.csproj", "MatrizWebApplication/"]
RUN dotnet restore "MatrizWebApplication/MatrizWebApplication.csproj"
COPY . .
WORKDIR "/src/MatrizWebApplication"
RUN dotnet build "MatrizWebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MatrizWebApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MatrizWebApplication.dll"]
