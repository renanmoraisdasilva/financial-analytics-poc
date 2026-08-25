# Financial Analytics POC

A small financial analytics data foundation that demonstrates how raw operational data can be extracted, staged, transformed, validated, modeled, and exposed as financial metrics and reports.

## Architecture

```text
                           DATA FLOW

┌─────────────┐
│   Fake ERP  │
│             │
│ Transactions│
│ Accounts    │
│ Entities    │
└──────┬──────┘
       │
       │ Extract
       ▼
┌─────────────────────┐
│      Staging        │
│                     │
│ Preserve source     │
│ records for the run │
└──────────┬──────────┘
           │
           │ Transform
           ▼
┌─────────────────────┐
│      Validate       │
│                     │
│ Mapping, integrity  │
│ & reconciliation    │
└──────────┬──────────┘
           │
           │ Load
           ▼
┌───────────────────────┐
│      SQL SERVER       │
│                       │
│ FactGL                │
│ DimAccount            │
│ DimEntity             │
│ DimDate               │
│ DimCurrency           │
└──────────┬────────────┘
           │
           │ SQL
           ▼
┌───────────────────────┐
│       .NET API        │
│                       │
│ Metrics               │
│ Reports               │
│ Pipeline inspection   │
└──────────┬────────────┘
           │
           │ JSON
           ▼
┌───────────────────────┐
│        REACT          │
│                       │
│ Pipeline              │
│ Reports               │
│ Metrics               │
└───────────────────────┘
```
## Project layout

```text
src/FinancialAnalytics.Api/       ASP.NET Core 8 host, EF Core models and migrations
web/financial-analytics-web/      Vite React TypeScript frontend
ui-renderings/                    Original interaction references
```

## Implemented scope

- ERP to staging to transformation to validation to `FactGL`
- Separate SQL Server databases for `FakeErp` and `FinancialAnalytics`
- Pipeline inspection, validation diagnostics, metrics, and financial reports
- Source, staging, transformation, and analytical-record APIs
- SQL-side pagination on the collection read endpoints
- Deterministic seed data with 10,000 ERP transactions and a 20-transaction demo scenario
- Transactional pipeline loading with EF Core migrations and seed data
- Validation results persisted with each pipeline run and returned by the validation endpoint

Drill-down UI and API capabilities are not implemented yet.

The full 10,000-row seed is useful for demonstrating pagination and end-to-end processing. The regular demo scenarios use the first 20 transactions for a smaller, repeatable workflow.

The following engineering improvements remain suitable for the backlog: chunked or keyset ERP extraction, reducing whole-run in-memory ETL processing, and query-plan-confirmed indexes for the main pagination paths.

## Run locally

### API

```powershell
dotnet run --project src/FinancialAnalytics.Api/FinancialAnalytics.Api.csproj --urls http://localhost:5080
```

The API listens at `http://localhost:5080` and Swagger is available at `http://localhost:5080/swagger`.

Run backend tests with coverage:

```bash
./scripts/test-coverage.sh
```

Coverage output is written under `TestResults/coverage`.

### Docker SQL Server

The local development database runs in one SQL Server container named `financial-analytics-sql`.
It uses SQL authentication with the development-only `sa` password `Strong_password123!`.
The container is exposed on host port `11433` to avoid conflicts with other local SQL Server containers; SQL Server still listens on port `1433` inside the container.
The data is persisted in the Docker volume `financial-analytics-sql-data`.

The service creates two separate databases by applying the existing EF Core migrations:

- `FakeErp` for the operational source data
- `FinancialAnalytics` for staging, dimensions, pipeline runs, and `FactGL`

Build and start the complete application with:

```bash
docker compose up --build
```

The Bash convenience script is `scripts/start-dev.sh`, and runs the same Compose workflow. The API applies both EF Core migration sets when it starts, after SQL Server becomes healthy. The frontend is served at `http://localhost:3001` and the API at `http://localhost:5080`.

To stop the database container without deleting its data:

```powershell
docker compose down
```

To delete the container and its persisted database volume:

```powershell
docker compose down -v
```

For manual API setup, set both SQL-authenticated connection strings in environment configuration and set `UseDemoData=false`:

```powershell
$env:ConnectionStrings__FakeErp="Server=localhost,11433;Database=FakeErp;User Id=sa;Password=Strong_password123!;TrustServerCertificate=True"
$env:ConnectionStrings__FinancialAnalytics="Server=localhost,11433;Database=FinancialAnalytics;User Id=sa;Password=Strong_password123!;TrustServerCertificate=True"
dotnet tool install --global dotnet-ef --version 8.0.19
dotnet ef migrations add InitialCreate --project src/FinancialAnalytics.Api --context FakeErpDbContext --output-dir Migrations/FakeErp
dotnet ef migrations add InitialCreate --project src/FinancialAnalytics.Api --context FinancialAnalyticsDbContext --output-dir Migrations/FinancialAnalytics
dotnet ef database update --project src/FinancialAnalytics.Api --context FakeErpDbContext
dotnet ef database update --project src/FinancialAnalytics.Api --context FinancialAnalyticsDbContext
```

The migrations seed 4 ERP accounts, 2 ERP entities, 10,000 deterministic ERP transactions, the canonical dimensions, the full 2025-2026 date dimension, one completed pipeline run, staging rows, and 20 `FactGL` rows. The pipeline scenarios use the first 20 transactions as a small deterministic UI dataset. Their signed source total is `$44,000`; reporting totals are Product Revenue `$57,000`, Service Revenue `$17,000`, Revenue `$74,000`, COGS `$23,000`, Gross Profit `$51,000`, Operating Expenses `$7,000`, and Net Income `$44,000`.

### Web

```powershell
cd web/financial-analytics-web
npm install
npm run dev
```

The frontend uses `VITE_API_BASE_URL` when provided and defaults to `http://localhost:5080`.

