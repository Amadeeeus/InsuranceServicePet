FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["InsuranceService.GenerateDocument/InsuranceService.GenerateDocument.csproj", "InsuranceService.GenerateDocument/"]
RUN dotnet restore "InsuranceService.GenerateDocument/InsuranceService.GenerateDocument.csproj"
COPY . .
WORKDIR "/src/InsuranceService.GenerateDocument"
RUN dotnet build "InsuranceService.GenerateDocument.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "InsuranceService.GenerateDocument.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InsuranceService.GenerateDocument.dll"]
