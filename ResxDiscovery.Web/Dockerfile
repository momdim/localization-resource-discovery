FROM mcr.microsoft.com/dotnet/sdk:6.0 AS buildmachine
WORKDIR /build

RUN apt-get update && apt-get install npm -y && npm install yarn -g

FROM buildmachine AS restore
WORKDIR /src
COPY . ./
RUN dotnet restore

FROM restore
EXPOSE 80

WORKDIR /src/ResxDiscovery.Web

ENTRYPOINT dotnet run --no-launch-profile

