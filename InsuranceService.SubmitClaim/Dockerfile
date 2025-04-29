FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["InsuranceService.SubmitClaim/InsuranceService.SubmitClaim.csproj", "InsuranceService.SubmitClaim/"]
RUN dotnet restore "InsuranceService.SubmitClaim/InsuranceService.SubmitClaim.csproj"
COPY . .
WORKDIR "/src/InsuranceService.SubmitClaim"
RUN dotnet build "InsuranceService.SubmitClaim.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "InsuranceService.SubmitClaim.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InsuranceService.SubmitClaim.dll"]
