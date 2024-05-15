# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /app

# install dotnet-ef tools for database migrations
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# copy csproj and restore as distinct layers
COPY product-Crud-Dotnet/*.csproj .
RUN dotnet restore

# copy everything else and build app
COPY product-Crud-Dotnet/. ./
RUN dotnet ef database update
RUN dotnet publish -c Release -o ./build

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS publish
WORKDIR /app
COPY --from=build /app/build ./
EXPOSE 8080
ENTRYPOINT ["dotnet", "product-Crud-Dotnet.dll"]
