# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy project files
COPY . .

# Publish the app
RUN dotnet publish "API/API.csproj" -c Release -o /app/publish

# Use the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Set the port (Render uses 10000 by default)
ENV ASPNETCORE_URLS=http://+:10000

# Start the app
ENTRYPOINT ["dotnet", "API.dll"]