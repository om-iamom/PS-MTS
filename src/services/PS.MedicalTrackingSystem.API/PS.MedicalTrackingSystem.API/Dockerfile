#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PS.MedicalTrackingSystem.API/PS.MedicalTrackingSystem.API.csproj", "PS.MedicalTrackingSystem.API/"]
RUN dotnet restore "PS.MedicalTrackingSystem.API/PS.MedicalTrackingSystem.API.csproj"
COPY . .
WORKDIR "/src/PS.MedicalTrackingSystem.API"
RUN dotnet build "PS.MedicalTrackingSystem.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PS.MedicalTrackingSystem.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PS.MedicalTrackingSystem.API.dll"]