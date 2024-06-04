FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App
 
# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore "ProjetVeloBackEnd.API/ProjetVeloBackEnd.API.csproj"
# Build and publish a release
WORKDIR "/App/ProjetVeloBackEnd.API"
RUN dotnet build "ProjetVeloBackEnd.API.csproj" -c Release -o /App/build
 
RUN dotnet publish "ProjetVeloBackEnd.API.csproj" -c Release -o /App/publish
 
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /App
COPY --from=build-env /App/build .
ENTRYPOINT ["dotnet", "ProjetVeloBackEnd.API.dll"]