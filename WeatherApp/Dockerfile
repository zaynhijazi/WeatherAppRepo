#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WeatherApp/WeatherApp.csproj", "WeatherApp/"]
COPY ["WeatherApp.Common/WeatherApp.Common.csproj", "WeatherApp.Common/"]
COPY ["WeatherData.Business/WeatherApp.Business.csproj", "WeatherData.Business/"]
RUN dotnet restore "WeatherApp/WeatherApp.csproj"
COPY . .
WORKDIR "/src/WeatherApp"
RUN dotnet build "WeatherApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherApp.dll"]
