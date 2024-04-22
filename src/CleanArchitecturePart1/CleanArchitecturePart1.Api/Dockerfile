FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80


#FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-windowsservercore-ltsc2019 AS build
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/CleanArchitecturePart1/CleanArchitecturePart1.Domain/CleanArchitecturePart1.Domain.csproj", "src/CleanArchitecturePart1/CleanArchitecturePart1.Domain/"]
COPY ["src/CleanArchitecturePart1/CleanArchitecturePart1.Application/CleanArchitecturePart1.Application.csproj", "src/CleanArchitecturePart1/CleanArchitecturePart1.Application/"]
COPY ["src/CleanArchitecturePart1/CleanArchitecturePart1.Infrastructure/CleanArchitecturePart1.Infrastructure.csproj", "src/CleanArchitecturePart1/CleanArchitecturePart1.Infrastructure/"]
COPY ["src/CleanArchitecturePart1/CleanArchitecturePart1.Api/CleanArchitecturePart1.Api.csproj", "src/CleanArchitecturePart1/CleanArchitecturePart1.Api/"]
RUN dotnet restore "src/CleanArchitecturePart1/CleanArchitecturePart1.Api/CleanArchitecturePart1.Api.csproj"
COPY . .
WORKDIR "/src/src/CleanArchitecturePart1/CleanArchitecturePart1.Api"
RUN dotnet build "CleanArchitecturePart1.Api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "CleanArchitecturePart1.Api.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleanArchitecturePart1.Api.dll"]
