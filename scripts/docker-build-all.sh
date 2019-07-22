#!/bin/bash
BUILD=./scripts/docker-build.sh
REPOSITORIES=(ParkAndRide.Services.Rides)

for REPOSITORY in ${REPOSITORIES[*]}
do
	 cd ..
	 echo ========================================================
	 echo Building a local Docker image: $REPOSITORY
	 echo ========================================================
     cd $REPOSITORY
     $BUILD 
done