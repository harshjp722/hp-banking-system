FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/Services/Loans/Loans.Api/Loans.Api.csproj src/Services/Loans/Loans.Api/
COPY src/BuildingBlocks/WebHost.Customization/WebHost.Customization.csproj src/BuildingBlocks/WebHost.Customization/
RUN dotnet restore src/Services/Loans/Loans.Api/Loans.Api.csproj
COPY . .
WORKDIR /src/Services/Loans/Loans.Api
RUN dotnet build Loans.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Loans.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Loans.Api.dll"]
