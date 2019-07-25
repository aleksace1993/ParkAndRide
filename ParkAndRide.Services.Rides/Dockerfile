FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app
COPY ["ParkAndRide.Common/ParkAndRide.Common.csproj", "ParkAndRide.Common/"]
COPY ["ParkAndRide.Services.Rides/ParkAndRide.Services.Rides.csproj", "ParkAndRide.Services.Rides/"]
#restore and build common
RUN dotnet build "ParkAndRide.Common/ParkAndRide.Common.csproj" -c Release --output /app/out
#restore  Rides
#RUN dotnet restore "ParkAndRide.Services.Rides/ParkAndRide.Services.Rides.csproj"
#LOOKS LIKE : this thing copies the whole directory into APP
COPY . .
#run the publish inside the app/out folder

RUN dotnet publish "ParkAndRide.Services.Rides/ParkAndRide.Services.Rides.csproj" -c Release -o /app/out

#WE GET A HEARTBEAT EXCEPTION MONGO CANNOT ESTABLISH CONNECTION TO THE SERVER


FROM microsoft/dotnet:2.2-aspnetcore-runtime AS final
# app of the final
WORKDIR /app
#copy everything from publish's app/out into app
COPY --from=build /app/out .
EXPOSE 5000
RUN echo hello world