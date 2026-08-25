# Project Development Rules

## Architecture

This is a small proof-of-concept.

Use ONE ASP.NET Core service.

Do not introduce microservices, worker services,
message queues, or background processing unless explicitly requested.

## Backend

- ASP.NET Core
- Entity Framework Core
- SQL Server
- EF Core migrations
- REST API
- Swagger/OpenAPI

Use EF Core directly. Do not introduce a generic repository
or unit-of-work abstraction.

Do not use MediatR.

Do not use AutoMapper.

## Databases

There are two SQL Server databases:

- FakeErp
- FinancialAnalytics

FakeErp is the operational source.

FinancialAnalytics is the analytical/reporting database.

## ETL

The ETL runs inside the ASP.NET Core service.

The pipeline has four stages:

1. Extract
2. Transform
3. Validate
4. Load

Keep these stages explicit and easy to understand.

Do not create a separate ETL service.

Do not create an AccountMapping table yet.

Do not create PipelineStepRun.

## Testing

Use xUnit.

Use FluentAssertions.

Integration tests should use WebApplicationFactory
and Testcontainers with SQL Server.

Prefer real database integration tests over mocking EF Core.

## API

Use focused REST endpoints.

Do not generate CRUD endpoints for every database table.

The API should expose pipeline inspection,
reporting, and transaction lineage.

## General

Prefer simple, explicit code over abstractions.

Do not add libraries or architectural patterns unless
they solve a demonstrated problem in this project.

Do not over-engineer for future requirements.

If a feature is not required by the POC specification,
ask before introducing it.