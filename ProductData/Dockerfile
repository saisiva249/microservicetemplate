# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy and restore as distinct layers
COPY . ./
RUN dotnet restore ./Onion.Api/Onion.Api.csproj
RUN dotnet publish ./Onion.Api/Onion.Api.csproj -c Release -o out

# Final Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app

EXPOSE 8080

COPY --from=build /app/out ./
ENV ASPNETCORE_URLS=http://*:8080

# Set the entry point
ENTRYPOINT ["dotnet", "Onion.Api.dll"]

ENV POSTGRES_USER postgres
ENV POSTGRES_PASSWORD AD11**in
ENV POSTGRES_DB Product
ENV DB_SERVER postgres-app
