#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app

COPY . .
EXPOSE 80
EXPOSE 443
#FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
#WORKDIR /src
#COPY ["DockerNetwork/DockerNetwork.csproj", "DockerNetwork/"]
#RUN dotnet restore "DockerNetwork/DockerNetwork.csproj"
#COPY . .
#WORKDIR "/src/DockerNetwork"
#RUN dotnet build "DockerNetwork.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "DockerNetwork.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerNetwork.dll"]