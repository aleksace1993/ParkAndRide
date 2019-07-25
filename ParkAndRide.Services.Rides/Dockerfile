
FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
#Copy the folders from the HD to the Container (avoid copying everything, since we're working 1 directory behind)
COPY ["ParkAndRide.Services.Rides/", "ParkAndRide.Services.Rides/"]
COPY ["ParkAndRide.Common/", "ParkAndRide.Common/"]

#this coppies all the files from the PC dir to the Container dir (not needed cause it will copy the Api project and others also)
#COPY . .

#run the publish inside the app/out folder
FROM build as publish
#this restores all the dependencies of Rides and Common and puts them into app/out... in publish layer
RUN dotnet publish "ParkAndRide.Services.Rides/ParkAndRide.Services.Rides.csproj" -c Release -o /app/out

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS final
#use this to inspect directories without dotnet entrypoint
#FROM ubuntu:18.04
WORKDIR /app 
#copy everything from app/out
COPY --from=publish /app/out .
EXPOSE 5000
ENTRYPOINT ["dotnet", "ParkAndRide.Services.Rides.dll"]
