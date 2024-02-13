#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Presentations/StandardAutoresponder.WorkerService/StandardAutoresponder.WorkerService.csproj", "Presentations/StandardAutoresponder.WorkerService/"]
RUN dotnet restore "./Presentations/StandardAutoresponder.WorkerService/./StandardAutoresponder.WorkerService.csproj"
COPY . .
WORKDIR "/src/Presentations/StandardAutoresponder.WorkerService"
RUN dotnet build "./StandardAutoresponder.WorkerService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StandardAutoresponder.WorkerService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StandardAutoresponder.WorkerService.dll"]