FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /CustomerSpike
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 8080
WORKDIR /CustomerSpike
COPY --from=build-env /CustomerSpike/out .
ENTRYPOINT ["dotnet", "CustomerAPI.dll"]
