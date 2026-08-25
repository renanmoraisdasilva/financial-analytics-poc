Absolutely. Here's the **updated backend specification** with `PipelineStepRun` and `AccountMapping` removed. This is the version I'd use as our implementation document.

# Financial Analytics POC — Backend Specification

## 1. Purpose

Build a small financial analytics platform that demonstrates the complete flow from operational ERP data to financial reporting:

```text
Fake ERP
   ↓
C# ETL
   ↓
SQL Server
   ↓
Fact + Dimensions
   ↓
SQL Queries
   ↓
.NET API
   ↓
React Report
```

The POC uses **one fake ERP** initially.

The architecture should leave room for additional ERP sources later, but no second ERP or generalized mapping framework will be implemented in v1.

The primary goal is to demonstrate:

* extracting operational data
* transforming source data
* validating data
* loading an analytical model
* querying that model
* defining financial metrics
* reporting those metrics
* tracing reported numbers back to source transactions

---

# 2. Architecture

There are two SQL Server databases.

```text
SQL Server
│
├── FakeErp
│   ├── Account
│   ├── Entity
│   └── Transaction
│
└── FinancialAnalytics
    ├── PipelineRun
    ├── StgTransaction
    │
    ├── DimAccount
    ├── DimEntity
    ├── DimDate
    ├── DimCurrency
    └── FactGL
```

Application flow:

```text
┌─────────────────────┐
│      Fake ERP       │
│                     │
│ Account             │
│ Entity              │
│ Transaction         │
└──────────┬──────────┘
           │
           │ Read
           ▼
┌─────────────────────┐
│      C# ETL         │
│                     │
│ Extract             │
│ Transform           │
│ Validate            │
│ Load                │
└──────────┬──────────┘
           │
           │ Write
           ▼
┌─────────────────────┐
│ FinancialAnalytics  │
│                     │
│ Staging             │
│ Fact                 │
│ Dimensions           │
└──────────┬──────────┘
           │
           │ Read
           ▼
┌─────────────────────┐
│      .NET API       │
└──────────┬──────────┘
           │
           │ JSON
           ▼
┌─────────────────────┐
│        React        │
│                     │
│ Data Pipeline       │
│ Financial Report    │
└─────────────────────┘
```

---

# 3. FakeErp Database

The Fake ERP represents an operational system.

It is intentionally simple.

```text
FakeErp
│
├── Account
├── Entity
└── Transaction
```

The ERP is the **source of truth for the original operational records**.

The analytical database should not be treated as another version of the ERP.

---

## 3.1 Account

Represents the ERP's account catalog.

### Columns

| Column        | Type           | Constraints      | Description               |
| ------------- | -------------- | ---------------- | ------------------------- |
| `AccountId`   | `int`          | PK               | Internal ERP identifier   |
| `AccountCode` | `varchar(50)`  | Unique, Not Null | ERP-specific account code |
| `AccountName` | `varchar(200)` | Not Null         | ERP account name          |

Example:

| AccountId | AccountCode | AccountName   |
| --------: | ----------- | ------------- |
|         1 | 4000        | Product Sales |
|         2 | 4010        | Service Sales |
|         3 | 5000        | Materials     |
|         4 | 6000        | Salaries      |

Important:

These names represent the **ERP vocabulary**, not necessarily the vocabulary used by the analytical model.

---

# 4. Entity

Represents an organization/entity inside the ERP.

### Columns

| Column        | Type           | Constraints      |
| ------------- | -------------- | ---------------- |
| `EntityId`    | `int`          | PK               |
| `EntityCode`  | `varchar(50)`  | Unique, Not Null |
| `EntityName`  | `varchar(200)` | Not Null         |
| `CountryCode` | `char(2)`      | Not Null         |

Initial data:

| EntityId | EntityCode | EntityName   | CountryCode |
| -------: | ---------- | ------------ | ----------- |
|        1 | US         | Northstar US | US          |

---

# 5. Transaction

This is the main operational ERP table.

### Columns

| Column            | Type            | Constraints  |
| ----------------- | --------------- | ------------ |
| `TransactionId`   | `varchar(50)`   | PK           |
| `TransactionDate` | `date`          | Not Null     |
| `AccountId`       | `int`           | FK → Account |
| `EntityId`        | `int`           | FK → Entity  |
| `Amount`          | `decimal(18,2)` | Not Null     |
| `CurrencyCode`    | `char(3)`       | Not Null     |
| `Description`     | `varchar(500)`  | Nullable     |
| `CreatedAt`       | `datetime2`     | Not Null     |

Example:

| TransactionId | Date       | Account | Entity | Amount | Currency |
| ------------- | ---------- | ------- | ------ | -----: | -------- |
| A001          | 2026-01-05 | 4000    | US     | 10,000 | USD      |
| A002          | 2026-01-08 | 4000    | US     | 15,000 | USD      |
| A003          | 2026-01-15 | 4010    | US     |  5,000 | USD      |
| A004          | 2026-01-20 | 5000    | US     | -8,000 | USD      |

---

# 6. FinancialAnalytics Database

This database is designed for **analysis and reporting**, not transaction processing.

```text
FinancialAnalytics
│
├── PipelineRun
├── StgTransaction
│
├── DimAccount
├── DimEntity
├── DimDate
├── DimCurrency
└── FactGL
```

There are two conceptual areas:

```text
Pipeline / staging
        │
        ▼
Analytical model
```

---

# 7. PipelineRun

Tracks an execution of the ETL.

We deliberately use **one pipeline execution table** instead of creating a separate table for every pipeline step.

### Columns

| Column               | Type          | Constraints |
| -------------------- | ------------- | ----------- |
| `PipelineRunId`      | `bigint`      | PK          |
| `StartedAt`          | `datetime2`   | Not Null    |
| `CompletedAt`        | `datetime2`   | Nullable    |
| `Status`             | `varchar(30)` | Not Null    |
| `RecordsExtracted`   | `int`         | Not Null    |
| `RecordsTransformed` | `int`         | Not Null    |
| `RecordsValidated`   | `int`         | Not Null    |
| `RecordsLoaded`      | `int`         | Not Null    |
| `RecordsFailed`      | `int`         | Not Null    |

Possible statuses:

```text
Running
Completed
Failed
```

Example:

| Run | Status    | Extracted | Transformed | Validated | Loaded | Failed |
| --: | --------- | --------: | ----------: | --------: | -----: | -----: |
|   1 | Completed |        20 |          20 |        20 |     20 |      0 |

This directly supports the Pipeline UI.

---

# 8. StgTransaction

`StgTransaction` represents the data captured from the ERP during extraction.

Think:

> "What did the ERP give us?"

It is deliberately close to the source structure.

### Columns

| Column                | Type            | Constraints      |
| --------------------- | --------------- | ---------------- |
| `StgTransactionId`    | `bigint`        | PK               |
| `PipelineRunId`       | `bigint`        | FK → PipelineRun |
| `SourceTransactionId` | `varchar(50)`   | Not Null         |
| `TransactionDate`     | `date`          | Not Null         |
| `SourceAccountCode`   | `varchar(50)`   | Not Null         |
| `SourceAccountName`   | `varchar(200)`  | Not Null         |
| `SourceEntityCode`    | `varchar(50)`   | Not Null         |
| `Amount`              | `decimal(18,2)` | Not Null         |
| `CurrencyCode`        | `char(3)`       | Not Null         |
| `Description`         | `varchar(500)`  | Nullable         |

Example:

| Source ID | Account | Description   |  Amount |
| --------- | ------- | ------------- | ------: |
| A001      | 4000    | Product Sales | $10,000 |
| A002      | 4000    | Product Sales | $15,000 |
| A003      | 4010    | Service Sales |  $5,000 |

This is the data immediately after **Extract**.

---

# 9. Transformation

There is intentionally **no AccountMapping table in v1**.

The mapping logic lives in the C# transformation code.

For example:

```text
4000 → Product Revenue
4010 → Service Revenue
5000 → Materials
6000 → Salaries
```

The transformation produces the canonical values that will eventually be loaded into the analytical model.

If we later add a second ERP and discover that maintaining mappings in code is becoming a real problem, we can introduce a mapping table then.

For the POC, it would be unnecessary complexity.

---

# 10. DimAccount

This is the canonical financial account structure.

### Columns

| Column             | Type           | Constraints               |
| ------------------ | -------------- | ------------------------- |
| `AccountKey`       | `int`          | PK                        |
| `AccountCode`      | `varchar(50)`  | Unique, Not Null          |
| `AccountName`      | `varchar(200)` | Not Null                  |
| `AccountCategory`  | `varchar(50)`  | Not Null                  |
| `ParentAccountKey` | `int`          | Nullable, FK → DimAccount |

Example:

| Key | Code     | Name            | Category          |
| --: | -------- | --------------- | ----------------- |
|   1 | REV-PROD | Product Revenue | Revenue           |
|   2 | REV-SERV | Service Revenue | Revenue           |
|   3 | COGS-MAT | Materials       | COGS              |
|   4 | OPEX-SAL | Salaries        | Operating Expense |

The distinction is important:

```text
Fake ERP:

4000 → Product Sales

        ↓ transformation

Analytics:

REV-PROD → Product Revenue
```

---

# 11. DimEntity

### Columns

| Column        | Type           | Constraints      |
| ------------- | -------------- | ---------------- |
| `EntityKey`   | `int`          | PK               |
| `EntityCode`  | `varchar(50)`  | Unique, Not Null |
| `EntityName`  | `varchar(200)` | Not Null         |
| `CountryCode` | `char(2)`      | Not Null         |

Initial data:

```text
1 | US | Northstar US | US
```

---

# 12. DimDate

The date dimension supports time-based analysis.

### Columns

| Column      | Type          | Constraints      |
| ----------- | ------------- | ---------------- |
| `DateKey`   | `int`         | PK               |
| `Date`      | `date`        | Unique, Not Null |
| `Day`       | `tinyint`     | Not Null         |
| `Month`     | `tinyint`     | Not Null         |
| `MonthName` | `varchar(20)` | Not Null         |
| `Quarter`   | `tinyint`     | Not Null         |
| `Year`      | `smallint`    | Not Null         |

Example:

|  DateKey | Date       | Month | Quarter | Year |
| -------: | ---------- | ----: | ------- | ---: |
| 20260105 | 2026-01-05 |     1 | 1       | 2026 |

---

# 13. DimCurrency

### Columns

| Column         | Type           | Constraints      |
| -------------- | -------------- | ---------------- |
| `CurrencyKey`  | `int`          | PK               |
| `CurrencyCode` | `char(3)`      | Unique, Not Null |
| `CurrencyName` | `varchar(100)` | Not Null         |

Initial data:

```text
1 | USD | US Dollar
```

We are **not implementing currency conversion in v1**.

The dimension exists because currency is a meaningful analytical dimension and gives us room to extend the model later.

---

# 14. FactGL

This is the central analytical fact table.

### Columns

| Column                | Type            | Constraints      |
| --------------------- | --------------- | ---------------- |
| `FactGLKey`           | `bigint`        | PK               |
| `SourceSystem`        | `varchar(50)`   | Not Null         |
| `SourceTransactionId` | `varchar(50)`   | Not Null         |
| `DateKey`             | `int`           | FK → DimDate     |
| `AccountKey`          | `int`           | FK → DimAccount  |
| `EntityKey`           | `int`           | FK → DimEntity   |
| `CurrencyKey`         | `int`           | FK → DimCurrency |
| `Amount`              | `decimal(18,2)` | Not Null         |

Example:

| FactGLKey | Source  | Source ID | Account         | Entity | Amount |
| --------: | ------- | --------- | --------------- | ------ | -----: |
|         1 | FakeERP | A001      | Product Revenue | US     | 10,000 |
|         2 | FakeERP | A002      | Product Revenue | US     | 15,000 |
|         3 | FakeERP | A003      | Service Revenue | US     |  5,000 |
|         4 | FakeERP | A004      | Materials       | US     | -8,000 |

### Fact grain

The grain of `FactGL` is:

> **One row represents one financial transaction from the source system.**

This is important.

It means we can aggregate the table by:

* account
* entity
* date
* currency
* source

without changing what a row means.

---

# 15. Star schema

The final analytical model is:

```text
                  DimAccount
                       │
                       │
DimEntity ──────── FactGL ──────── DimDate
                       │
                       │
                  DimCurrency
```

The fact table contains measurements and foreign keys.

The dimensions provide the context used to analyze those measurements.

---

# 16. ETL process

The C# ETL has four logical stages.

```text
Extract
   ↓
Transform
   ↓
Validate
   ↓
Load
```

## Extract

Read from:

```text
FakeErp.Transaction
```

and write to:

```text
FinancialAnalytics.StgTransaction
```

At this point, data should remain close to the source representation.

---

## Transform

Transform staging records into canonical analytical concepts.

Example:

```text
4000
Product Sales
$10,000
```

becomes:

```text
REV-PROD
Product Revenue
$10,000
```

The transformation is implemented in C# for v1.

---

## Validate

Validate:

* required fields
* account mappings
* valid entity
* valid dates
* valid amounts
* duplicate source transaction IDs
* source/target totals

Example:

```text
20 records received
20 valid
0 duplicates
0 unmapped accounts

Source total:      $85,000
Transformed total: $85,000

✓ Reconciliation passed
```

---

## Load

Load:

```text
DimAccount
DimEntity
DimDate
DimCurrency
FactGL
```

The API and reporting layer only read from the analytical database.

---

# 17. Data ownership

The architecture should follow this rule:

```text
Fake ERP
    │
    │ READ
    ▼
   ETL
    │
    │ WRITE
    ▼
FinancialAnalytics
    │
    │ READ
    ▼
.NET API
    │
    │ READ
    ▼
React
```

The React application does not directly access SQL Server.

The API does not write to `FactGL`.

The ETL is responsible for loading the analytical model.

---

# 18. API

The API is organized around two concepts:

```text
Pipeline
Reports
Lineage
```

We intentionally do **not** expose generic CRUD endpoints for every database table.

The API should expose the operations the application actually needs.

---

# 19. Pipeline endpoints

## Start pipeline

```http
POST /api/pipeline/runs
```

Starts an ETL execution.

For the POC, this can run synchronously because the dataset is tiny.

### Response

```json
{
  "pipelineRunId": 1,
  "status": "Completed"
}
```

A future version could make this asynchronous, but that isn't necessary now.

---

## Get pipeline run

```http
GET /api/pipeline/runs/{runId}
```

Example:

```http
GET /api/pipeline/runs/1
```

### Response

```json
{
  "pipelineRunId": 1,
  "status": "Completed",
  "startedAt": "2026-08-21T14:32:00Z",
  "completedAt": "2026-08-21T14:32:01Z",
  "recordsExtracted": 20,
  "recordsTransformed": 20,
  "recordsValidated": 20,
  "recordsLoaded": 20,
  "recordsFailed": 0
}
```

This powers the **Execution Status** card.

---

# 20. Source data endpoint

```http
GET /api/pipeline/runs/{runId}/source
```

Example:

```http
GET /api/pipeline/runs/1/source
```

Returns the source/staging records associated with the pipeline run.

### Response

```json
[
  {
    "sourceTransactionId": "A001",
    "date": "2026-01-05",
    "accountCode": "4000",
    "accountName": "Product Sales",
    "entityCode": "US",
    "amount": 10000,
    "currency": "USD",
    "description": "Product Sales"
  },
  {
    "sourceTransactionId": "A002",
    "date": "2026-01-08",
    "accountCode": "4000",
    "accountName": "Product Sales",
    "entityCode": "US",
    "amount": 15000,
    "currency": "USD",
    "description": "Product Sales"
  }
]
```

This powers:

**Source Data — Fake ERP**

---

# 21. Transformation endpoint

```http
GET /api/pipeline/runs/{runId}/transformations
```

Example:

```http
GET /api/pipeline/runs/1/transformations
```

### Response

```json
[
  {
    "sourceTransactionId": "A001",
    "sourceAccountCode": "4000",
    "sourceAccountName": "Product Sales",
    "canonicalAccountCode": "REV-PROD",
    "canonicalAccountName": "Product Revenue",
    "amount": 10000
  },
  {
    "sourceTransactionId": "A002",
    "sourceAccountCode": "4000",
    "sourceAccountName": "Product Sales",
    "canonicalAccountCode": "REV-PROD",
    "canonicalAccountName": "Product Revenue",
    "amount": 15000
  }
]
```

This powers the **Transformation Preview**.

---

# 22. Validation endpoint

```http
GET /api/pipeline/runs/{runId}/validation
```

Example:

```http
GET /api/pipeline/runs/1/validation
```

### Response

```json
{
  "recordsReceived": 20,
  "accountsMapped": 20,
  "validDates": 20,
  "duplicates": 0,
  "invalidAmounts": 0,
  "sourceTotal": 85000,
  "transformedTotal": 85000,
  "reconciliationPassed": true
}
```

This powers the validation panel.

---

# 23. Loaded FactGL endpoint

```http
GET /api/pipeline/runs/{runId}/fact-gl
```

Example:

```http
GET /api/pipeline/runs/1/fact-gl
```

### Response

```json
[
  {
    "sourceTransactionId": "A001",
    "date": "2026-01-05",
    "account": "Product Revenue",
    "entity": "Northstar US",
    "amount": 10000
  },
  {
    "sourceTransactionId": "A002",
    "date": "2026-01-08",
    "account": "Product Revenue",
    "entity": "Northstar US",
    "amount": 15000
  }
]
```

This powers the **Load / FactGL preview**.

---

# 24. Reporting endpoints

## Income statement

```http
GET /api/reports/income-statement
```

Parameters:

```text
entity
year
quarter
```

Example:

```http
GET /api/reports/income-statement?entity=US&year=2026&quarter=1
```

### Response

```json
{
  "period": "Q1 2026",
  "entity": "Northstar US",
  "currency": "USD",
  "revenue": 74000,
  "cogs": 23000,
  "grossProfit": 51000,
  "grossMargin": 0.689,
  "operatingExpenses": 7000,
  "netIncome": 44000
}
```

---

# 25. Revenue breakdown

```http
GET /api/reports/revenue/breakdown
```

Parameters:

```text
entity
year
quarter
```

Example:

```http
GET /api/reports/revenue/breakdown?entity=US&year=2026&quarter=1
```

### Response

```json
[
  {
    "account": "Product Revenue",
    "amount": 57000
  },
  {
    "account": "Service Revenue",
    "amount": 17000
  }
]
```

This powers the Revenue detail drawer.

---

# 26. Revenue transactions

```http
GET /api/reports/revenue/transactions
```

Parameters:

```text
entity
year
quarter
account
```

Example:

```http
GET /api/reports/revenue/transactions?entity=US&year=2026&quarter=1&account=REV-PROD
```

### Response

```json
[
  {
    "sourceTransactionId": "A001",
    "date": "2026-01-05",
    "account": "Product Revenue",
    "amount": 10000
  },
  {
    "sourceTransactionId": "A002",
    "date": "2026-01-08",
    "account": "Product Revenue",
    "amount": 15000
  }
]
```

---

# 27. Transaction lineage

This is the most important endpoint for demonstrating traceability.

```http
GET /api/lineage/transactions/{sourceTransactionId}
```

Example:

```http
GET /api/lineage/transactions/A001
```

### Response

```json
{
  "source": {
    "system": "FakeERP",
    "transactionId": "A001",
    "accountCode": "4000",
    "accountName": "Product Sales",
    "amount": 10000,
    "currency": "USD",
    "date": "2026-01-05"
  },
  "transformation": {
    "canonicalAccountCode": "REV-PROD",
    "canonicalAccountName": "Product Revenue"
  },
  "analytical": {
    "factGLKey": 1,
    "account": "Product Revenue",
    "entity": "Northstar US",
    "amount": 10000,
    "currency": "USD"
  }
}
```

This lets the UI show:

```text
Fake ERP
A001
4000 — Product Sales
$10,000
       ↓
ETL Transformation
4000 → REV-PROD
       ↓
FactGL
Product Revenue
Northstar US
$10,000
```

---

# 28. Complete API surface

This is the entire initial API:

```text
PIPELINE

POST   /api/pipeline/runs

GET    /api/pipeline/runs/{runId}

GET    /api/pipeline/runs/{runId}/source

GET    /api/pipeline/runs/{runId}/transformations

GET    /api/pipeline/runs/{runId}/validation

GET    /api/pipeline/runs/{runId}/fact-gl


REPORTING

GET    /api/reports/income-statement

GET    /api/reports/revenue/breakdown

GET    /api/reports/revenue/transactions


LINEAGE

GET    /api/lineage/transactions/{sourceTransactionId}
```

That's the API I'd implement for v1.

---

# 29. UI → API mapping

The Stitch UI can now map cleanly to the backend.

| UI                   | Endpoint                                  |
| -------------------- | ----------------------------------------- |
| Fake ERP             | `GET /pipeline/runs/{id}/source`          |
| Extract              | `GET /pipeline/runs/{id}/source`          |
| Transform            | `GET /pipeline/runs/{id}/transformations` |
| Validate             | `GET /pipeline/runs/{id}/validation`      |
| Load                 | `GET /pipeline/runs/{id}/fact-gl`         |
| Run Pipeline         | `POST /pipeline/runs`                     |
| Execution Status     | `GET /pipeline/runs/{id}`                 |
| Income Statement     | `GET /reports/income-statement`           |
| Revenue breakdown    | `GET /reports/revenue/breakdown`          |
| Revenue transactions | `GET /reports/revenue/transactions`       |
| Transaction lineage  | `GET /lineage/transactions/{id}`          |

So there shouldn't be any mysterious frontend-only data.

**Every important thing visible in the UI has a real backend concept behind it.**

---

# 30. What we're intentionally NOT building

For v1:

* ❌ `PipelineStepRun`
* ❌ `AccountMapping`
* ❌ second ERP
* ❌ currency conversion
* ❌ background jobs
* ❌ queues
* ❌ Kafka
* ❌ generic ETL framework
* ❌ generic report builder
* ❌ authentication
* ❌ Excel integration
* ❌ cloud deployment

If we finish early, we can add one of these **because we've earned the need for it**, not because the architecture says we might someday need it.

---

# 31. The complete POC

At the end, we should be able to demonstrate this exact chain:

```text
                  SOURCE
                    │
                    ▼
             ┌─────────────┐
             │   Fake ERP  │
             │             │
             │ A001        │
             │ 4000        │
             │ $10,000     │
             └──────┬──────┘
                    │
                    │ Extract
                    ▼
             ┌─────────────┐
             │ StgTransaction
             │             │
             │ A001        │
             │ 4000        │
             │ $10,000     │
             └──────┬──────┘
                    │
                    │ Transform
                    ▼
             ┌─────────────┐
             │ Canonical   │
             │             │
             │ Product     │
             │ Revenue     │
             │ $10,000     │
             └──────┬──────┘
                    │
                    │ Validate
                    ▼
             ┌─────────────┐
             │   Valid ✓   │
             └──────┬──────┘
                    │
                    │ Load
                    ▼
             ┌─────────────┐
             │   FactGL    │
             │             │
             │ Product     │
             │ Revenue     │
             │ $10,000     │
             └──────┬──────┘
                    │
                    │ SQL
                    ▼
             ┌─────────────┐
             │   Revenue   │
             │   $74,000   │
             └──────┬──────┘
                    │
                    ▼
             ┌─────────────┐
             │    React    │
             │   Report    │
             └─────────────┘
```

**That's our implementation target.**

And I think this version is at exactly the right complexity for the four-day constraint: enough real data engineering to demonstrate the gap Keith identified, but small enough that you can understand and explain every table, transformation, query, and endpoint in the interview.


Yes. I would **lock down the technology choices now**, specifically so Copilot doesn't turn a small POC into a 14-project enterprise architecture.

My recommendation:

## 1. One backend service

**Yes — one .NET service.**

```text
FinancialAnalytics.sln

src/
  FinancialAnalytics.Api/

tests/
  FinancialAnalytics.Tests/
  FinancialAnalytics.IntegrationTests/

web/
  financial-analytics-web/
```

The .NET service owns:

```text
API
ETL
Business logic
Database access
Validation
```

No:

* microservices
* separate ETL service
* worker service
* message broker
* CQRS framework
* MediatR
* repository-per-table abstraction
* generic architecture framework

For this POC, one service is the right call.

---

# 2. Dapper vs Entity Framework

For **this particular project**, I'd actually choose **EF Core**, not Dapper.

Earlier we discussed Dapper as an option, but now that we're defining the actual application, I think EF Core fits the project better.

Why?

We're going to have:

```text
FakeErp
FinancialAnalytics
```

with a real relational model:

```text
FactGL
   ↓
DimAccount
DimEntity
DimDate
DimCurrency
```

EF Core gives us:

* migrations
* strongly typed entities
* relationships
* DbContext
* SQL Server integration
* easy seeding
* testability
* less hand-written mapping code

And **EF Core is perfectly capable of running the analytical SQL queries we need**.

We aren't building a high-performance reporting engine with millions of rows.

For a POC with hundreds/thousands of records, EF Core is more than sufficient.

### The bigger reason

You want to be able to explain the code.

With EF:

```csharp
var transactions = await db.FactGl
    .Include(x => x.Account)
    .Where(x => x.Entity.EntityCode == "US")
    .ToListAsync();
```

It's easy to understand what we're doing.

And when we need a query where explicit SQL is actually clearer, we can use:

```csharp
FromSqlInterpolated(...)
```

or a raw SQL query.

So we don't have to make this an ideological choice.

### My choice

**EF Core for persistence + migrations.**

We can introduce Dapper later if we discover a specific reporting query where it genuinely helps.

---

# 3. EF Core migrations

Definitely.

I'd use migrations for **both databases**.

Something like:

```text
Data/
  FakeErp/
    FakeErpDbContext.cs
    Migrations/

  FinancialAnalytics/
    FinancialAnalyticsDbContext.cs
    Migrations/
```

The application has two connection strings:

```json
{
  "ConnectionStrings": {
    "FakeErp": "...",
    "FinancialAnalytics": "..."
  }
}
```

Then:

```text
FakeErpDbContext
       ↓
FakeErp database

FinancialAnalyticsDbContext
       ↓
FinancialAnalytics database
```

This is much better than having Copilot generate a giant SQL initialization script.

---

# 4. Don't use EF entities directly as API models

I'd make a very small separation:

```text
Database Entity
      ↓
Application Model / DTO
      ↓
API Response
```

For example:

```csharp
public sealed record RevenueBreakdownDto(
    string Account,
    decimal Amount);
```

rather than returning `DimAccount` directly from the API.

This prevents the database model from becoming our API contract.

But don't overdo it.

We don't need:

```text
DomainEntity
PersistenceEntity
ApplicationEntity
Command
CommandHandler
Query
QueryHandler
Response
Mapper
Repository
UnitOfWork
```

for every operation.

That's exactly the sort of thing I want Copilot **not** to invent.

---

# 5. Architecture inside the one service

I'd use a simple structure:

```text
FinancialAnalytics.Api
│
├── Controllers/
│
├── Services/
│   ├── PipelineService.cs
│   ├── ReportingService.cs
│   └── LineageService.cs
│
├── Data/
│   ├── FakeErp/
│   │   ├── FakeErpDbContext.cs
│   │   └── Entities/
│   │
│   └── FinancialAnalytics/
│       ├── FinancialAnalyticsDbContext.cs
│       └── Entities/
│
├── Etl/
│   ├── ErpExtractor.cs
│   ├── DataTransformer.cs
│   ├── DataValidator.cs
│   └── DataLoader.cs
│
├── Contracts/
│   ├── Pipeline/
│   ├── Reports/
│   └── Lineage/
│
└── Program.cs
```

This is plenty.

The flow becomes:

```text
Controller
    ↓
Service
    ↓
DbContext / ETL component
    ↓
SQL Server
```

---

# 6. ETL should have explicit stages

This is one place where I **do** want separation.

Not separate services.

Separate classes.

```text
PipelineService
     │
     ├── Extractor
     │
     ├── Transformer
     │
     ├── Validator
     │
     └── Loader
```

For example:

```csharp
public interface IErpExtractor
{
    Task<IReadOnlyList<StgTransaction>> ExtractAsync(...);
}
```

```csharp
public interface IDataTransformer
{
    IReadOnlyList<TransformedTransaction> Transform(...);
}
```

```csharp
public interface IDataValidator
{
    ValidationResult Validate(...);
}
```

```csharp
public interface IDataLoader
{
    Task LoadAsync(...);
}
```

That makes the pipeline easy to understand and test.

---

# 7. xUnit

**Yes.**

Use xUnit for unit tests.

Test the stuff where the logic actually matters.

For example:

### Transformation

```text
4000 → Product Revenue
4010 → Service Revenue
5000 → Materials
```

Tests:

```text
4000 is transformed to Product Revenue
4010 is transformed to Service Revenue
unknown account is rejected
```

### Validation

```text
valid transaction passes
missing account fails
invalid date fails
duplicate transaction fails
```

### Financial calculations

```text
Revenue = Product + Service
Gross Profit = Revenue - COGS
Gross Margin = Gross Profit / Revenue
```

Those are valuable tests.

---

# 8. Integration tests

**Definitely.**

This project is actually a good candidate for integration testing because the database is an important part of what we're demonstrating.

I'd use:

**xUnit + WebApplicationFactory + SQL Server/Testcontainers**

That gives us:

```text
Test
 ↓
Real .NET API
 ↓
Real EF Core
 ↓
Real SQL Server
```

rather than mocking everything.

For example:

```text
POST /api/pipeline/runs
```

Integration test:

1. Seed Fake ERP transaction A001.
2. Run pipeline.
3. Query FactGL.
4. Assert A001 exists.
5. Call income statement endpoint.
6. Assert revenue is correct.

That's an **excellent test for this project**.

It proves the entire pipeline actually works.

---

# 9. Testcontainers

I'd add this.

Use:

```text
Testcontainers for .NET
```

to spin up SQL Server for integration tests.

Then we don't have:

```text
"Works on my machine because my local database happens to have the right data."
```

The test creates a clean SQL Server container.

This is especially nice to mention in an interview:

> "The integration tests run against an actual SQL Server instance rather than mocking EF."

That's much more convincing for this project.

---

# 10. FluentAssertions

I'd add **FluentAssertions**.

It makes tests much easier to read.

Instead of:

```csharp
Assert.Equal(74000, result.Revenue);
```

you get:

```csharp
result.Revenue.Should().Be(74000);
```

Not essential, but useful.

---

# 11. Logging

Use the built-in:

```text
Microsoft.Extensions.Logging
```

No Serilog unless we actually need it.

During a pipeline execution:

```text
Starting pipeline run 1
Extracted 20 records
Transformed 20 records
Validation passed
Loaded 20 records
Pipeline run 1 completed
```

This is particularly useful while we're developing.

---

# 12. Swagger / OpenAPI

**Yes.**

Absolutely.

The API should have Swagger enabled in development.

Then you can literally demonstrate:

```text
POST /api/pipeline/runs

GET /api/pipeline/runs/1/source

GET /api/pipeline/runs/1/transformations

GET /api/reports/income-statement
```

It's also useful while building the React frontend.

---

# 13. FluentValidation?

I'd say **no, initially**.

ASP.NET's built-in validation is enough for our small number of request models.

We're not building a huge API with complicated request validation.

Don't add a dependency just because it's popular.

---

# 14. AutoMapper?

**No.**

This is one of the first things I'd explicitly tell Copilot:

> Do not introduce AutoMapper.

Our mappings are simple enough that explicit mapping is clearer:

```csharp
return new RevenueBreakdownDto(
    account.AccountName,
    amount);
```

That's easier to understand.

---

# 15. MediatR?

**Absolutely not.**

This is exactly the kind of POC where Copilot might decide:

```text
Controller
 ↓
MediatR
 ↓
Command
 ↓
Handler
 ↓
Repository
 ↓
UnitOfWork
 ↓
DbContext
```

when we actually need:

```text
Controller
 ↓
ReportingService
 ↓
DbContext
```

Keep it boring.

---

# 16. Repository pattern?

Also **no generic repository**.

EF Core already gives us:

```csharp
DbContext
DbSet<T>
```

Don't build:

```csharp
IRepository<T>
Repository<T>
IUnitOfWork
```

just to wrap EF Core.

If a particular piece of data access becomes complicated, we can create a focused query/service later.

---

# 17. Frontend

For React:

```text
React
TypeScript
Vite
```

I'd use something lightweight.

For API calls:

```text
fetch
```

or Axios.

I'd actually use **fetch** for this POC.

No need for Redux.

No need for React Query initially either.

Something like:

```text
src/
├── api/
│   ├── pipelineApi.ts
│   └── reportsApi.ts
│
├── pages/
│   ├── PipelinePage.tsx
│   └── ReportPage.tsx
│
├── components/
│   ├── PipelineArchitecture.tsx
│   ├── TransformationTable.tsx
│   ├── ValidationPanel.tsx
│   └── FinancialReport.tsx
│
└── App.tsx
```

---

# 18. Database initialization / seed data

We absolutely need deterministic seed data.

The Fake ERP should start with **20 transactions**.

And the data should produce our report numbers.

For example:

```text
Product Revenue    $57,000
Service Revenue    $17,000
────────────────────────
Revenue            $74,000

Materials          $23,000
────────────────────────
Gross Profit       $51,000

Operating Expense   $7,000
────────────────────────
Net Income          $44,000
```

That way our tests can assert exact numbers.

---

# 19. One important thing: don't make the ETL magical

I would make the pipeline implementation extremely explicit.

Something like:

```csharp
public async Task<PipelineRun> RunAsync()
{
    var run = await StartRunAsync();

    var source = await extractor.ExtractAsync();

    var staged = await StageAsync(source);

    var transformed = transformer.Transform(staged);

    validator.Validate(transformed);

    await loader.LoadAsync(transformed);

    await CompleteRunAsync(run, ...);

    return run;
}
```

When Keith asks:

> "What happens between the ERP and FactGL?"

you can walk him through the code.

That's much better than having a generic framework hide everything.

---

# 20. The stack I'd lock down

### Backend

| Technology   | Decision                         |
| ------------ | -------------------------------- |
| .NET         | **ASP.NET Core**                 |
| Architecture | **One service**                  |
| ORM          | **EF Core**                      |
| Database     | **SQL Server**                   |
| Migrations   | **EF Core Migrations**           |
| API          | **REST**                         |
| API docs     | **Swagger/OpenAPI**              |
| Logging      | **Microsoft.Extensions.Logging** |
| Validation   | **Built-in initially**           |

### ETL

| Technology           | Decision        |
| -------------------- | --------------- |
| Extract              | EF Core         |
| Transform            | Plain C#        |
| Validate             | Plain C#        |
| Load                 | EF Core         |
| Mapping table        | **No, for now** |
| Separate ETL service | **No**          |

### Testing

| Technology  | Decision                          |
| ----------- | --------------------------------- |
| Unit tests  | **xUnit**                         |
| Assertions  | **FluentAssertions**              |
| Integration | **xUnit + WebApplicationFactory** |
| Database    | **Testcontainers + SQL Server**   |

### Frontend

| Technology       | Decision                  |
| ---------------- | ------------------------- |
| UI               | **React**                 |
| Language         | **TypeScript**            |
| Build            | **Vite**                  |
| API client       | **fetch**                 |
| State management | **React state initially** |

---

# 21. And I'd put this in `AGENTS.md`

This is probably the **single most useful thing we can do for Copilot**.

At the repo root:

```text
AGENTS.md
```

with rules like:

```markdown
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
```

That last sentence is especially important:

> **"If a feature is not required by the POC specification, ask before introducing it."**

Because otherwise Copilot sees `FactGL` and starts building a financial data platform with 47 abstractions. 😄

For this project, **simple + explainable + tested** is much more valuable than "enterprise architecture."

## Docker

The project must support Docker Compose.

Docker Compose should provide:

- SQL Server
- ASP.NET Core API
- React frontend

A single SQL Server container hosts both databases:

- FakeErp
- FinancialAnalytics

The project should support:

docker compose up

to start the complete application.

Database initialization and EF Core migrations
should be automated as part of the application startup
or container initialization.

Do not introduce Kubernetes or other container orchestration.
