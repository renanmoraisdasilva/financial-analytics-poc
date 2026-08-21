The goal of this project is to explore how raw operational data can be transformed,
validated, modeled, and exposed as meaningful financial metrics and reports.

## Architecture

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
