#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["glkt.Vod/glkt.Vod.csproj", "glkt.Vod/"]
RUN dotnet restore "glkt.Vod/glkt.Vod.csproj"
COPY . .
WORKDIR "/src/glkt.Vod"
RUN dotnet build "glkt.Vod.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "glkt.Vod.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "glkt.Vod.dll"]