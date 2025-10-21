# Use the official .NET 9 SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY DotnetAppSample/DotnetAppSample.csproj DotnetAppSample/
RUN dotnet restore DotnetAppSample/DotnetAppSample.csproj

# Copy all source code
COPY DotnetAppSample/ DotnetAppSample/

# Build and publish the application
WORKDIR /src/DotnetAppSample
RUN dotnet build DotnetAppSample.csproj -c Release -o /app/build
RUN dotnet publish DotnetAppSample.csproj -c Release -o /app/publish

# Use the official .NET 9 runtime image for running
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy the published application
COPY --from=build /app/publish .

# Expose the port the app runs on
EXPOSE 8080
EXPOSE 8081

# Set the entry point
ENTRYPOINT ["dotnet", "DotnetAppSample.dll"]
