

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["ParkAndRide.Services.Rides/ParkAndRide.Services.Rides.csproj", "ParkAndRide.Services.Rides/"]
COPY ["ParkAndRide.Common/ParkAndRide.Common.csproj", "ParkAndRide.Common/"]

#restore and build common
RUN dotnet build "/src/ParkAndRide.Common/ParkAndRide.Common.csproj" -c Release -o /app

#restore  Rides
RUN dotnet restore "/src/ParkAndRide.Services.Rides/ParkAndRide.Services.Rides.csproj"
COPY . .

FROM build AS publish
WORKDIR "/src/ParkAndRide.Services.Rides"
RUN dotnet publish "ParkAndRide.Services.Rides.csproj" -c Release -o /app

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000 
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ParkAndRide.Services.Rides.dll"]