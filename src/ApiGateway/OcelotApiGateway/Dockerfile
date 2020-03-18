FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/ApiGateway/OcelotApiGateway/OcelotApiGateway.csproj src/ApiGateway/OcelotApiGateway/
RUN dotnet restore src/ApiGateway/OcelotApiGateway/OcelotApiGateway.csproj
COPY . .
WORKDIR /src/src/ApiGateway/OcelotApiGateway
RUN dotnet build OcelotApiGateway.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish OcelotApiGateway.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OcelotApiGateway.dll"]
