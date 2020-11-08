FROM mcr.microsoft.com/powershell:lts-debian-buster-slim

RUN apt-get -y update && \
    apt-get -y install git && \
    apt-get clean && rm -rf /var/lib/apt/lists/
