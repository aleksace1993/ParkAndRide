
FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["ParkAndRide.Services.Rides/ParkAndRide.Services.Rides.csproj", "ParkAndRide.Services.Rides/"]
COPY ["ParkAndRide.Common/ParkAndRide.Common.csproj", "ParkAndRide.Common/"]

#restore and build common
RUN dotnet build "/src/ParkAndRide.Common/ParkAndRide.Common.csproj" -c Release -o /src/ParkAndRide.Common

#restore  Rides
RUN dotnet restore "/src/ParkAndRide.Services.Rides/ParkAndRide.Services.Rides.csproj"
COPY . .

FROM build AS publish
WORKDIR "/src/ParkAndRide.Services.Rides"
#run the publish inside the app/out folder
RUN dotnet publish "ParkAndRide.Services.Rides.csproj" -c Release -o /app/out

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS final
WORKDIR /app 
#copy everything from app/out
COPY --from=publish /app/out .
EXPOSE 5000
ENTRYPOINT ["dotnet", "ParkAndRide.Services.Rides.dll"]