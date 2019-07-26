FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["ParkAndRide.Api/", "ParkAndRide.Api/"]
COPY ["ParkAndRide.Common/", "ParkAndRide.Common/"]

FROM build AS publish
RUN dotnet publish "ParkAndRide.Api/ParkAndRide.Api.csproj" -c Release -o /app/out

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS final
WORKDIR /app
#copy the published files from /app/out to current workdir
COPY --from=publish /app/out .
ENV ASPNETCORE_ENVIRONMENT docker
ENV ASPNETCORE_URLS http://*:5000

EXPOSE 5000
ENTRYPOINT ["dotnet", "ParkAndRide.Api.dll"]