#!/bin/bash
DOTNET_RUN=./scripts/dotnet-run.sh
REPOSITORIES=(ParkAndRide.Api ParkAndRide.Services.Rides)

for REPOSITORY in ${REPOSITORIES[*]}
do
	 cd ..
	 echo ========================================================
	 echo Production service $REPOSITORY
	 echo ========================================================
     cd $REPOSITORY
     $DOTNET_RUN 
done