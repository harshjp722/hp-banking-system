FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/Services/Accounts/Accounts.Api/Accounts.Api.csproj src/Services/Accounts/Accounts.Api/
COPY src/BuildingBlocks/WebHost.Customization/WebHost.Customization.csproj src/BuildingBlocks/WebHost.Customization/
RUN dotnet restore src/Services/Accounts/Accounts.Api/Accounts.Api.csproj
COPY . .
WORKDIR /src/Services/Accounts/Accounts.Api
RUN dotnet build Accounts.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Accounts.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Accounts.Api.dll"]
