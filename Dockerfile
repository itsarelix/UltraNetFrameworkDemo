# Use the official .NET 8 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything and restore
COPY . . 
RUN dotnet restore UltraNetDemo.sln

# Build the project
RUN dotnet publish UltraNetDemo.sln -c Release -o /app/publish

# Use the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 80
EXPOSE 80

# Run the app
ENTRYPOINT ["dotnet", "UltraNet.UI.dll"]