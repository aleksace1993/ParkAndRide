FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ParkAndRide.Api/ParkAndRide.Api.csproj", "ParkAndRide.Api/"]
COPY ["ParkAndRide.Common/ParkAndRide.Common.csproj", "ParkAndRide.Common/"]
RUN dotnet restore "ParkAndRide.Api/ParkAndRide.Api.csproj"
COPY . .
WORKDIR "/src/ParkAndRide.Api"
RUN dotnet build "ParkAndRide.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ParkAndRide.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ParkAndRide.Api.dll"]