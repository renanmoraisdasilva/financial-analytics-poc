FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/FinancialAnalytics.Api/FinancialAnalytics.Api.csproj", "src/FinancialAnalytics.Api/"]
RUN dotnet restore "src/FinancialAnalytics.Api/FinancialAnalytics.Api.csproj"
COPY . .
RUN dotnet publish "src/FinancialAnalytics.Api/FinancialAnalytics.Api.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "FinancialAnalytics.Api.dll"]