#!/bin/bash
#this shell script is used only from the build-all.sh file, it WONT work if you run it solo.
docker build -t parkandride.services.rides -f Dockerfile ..