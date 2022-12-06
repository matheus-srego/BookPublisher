FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BookPublisher.API/BookPublisher.API.csproj", "BookPublisher.API/"]
RUN dotnet restore "BookPublisher.API/BookPublisher.API.csproj"
COPY . .
WORKDIR "/src/BookPublisher.API"
RUN dotnet build "BookPublisher.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookPublisher.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookPublisher.API.dll"]
