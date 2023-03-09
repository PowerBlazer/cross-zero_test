FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80
COPY . .
CMD dotnet watch run --project "Cross-Zero.WebAPI" --launch-profile "http"