FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["InsuranceService.AddOrder/InsuranceService.AddOrder.csproj", "InsuranceService.AddOrder/"]
RUN dotnet restore "InsuranceService.AddOrder/InsuranceService.AddOrder.csproj"
COPY . .
WORKDIR "/src/InsuranceService.AddOrder"
RUN dotnet build "InsuranceService.AddOrder.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "InsuranceService.AddOrder.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InsuranceService.AddOrder.dll"]
