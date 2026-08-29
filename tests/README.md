# Tests

The API tests use xUnit and FluentAssertions. They cover the deterministic demo source and the explicit C# account transformation rules.

Integration tests create disposable SQL Server containers automatically and generate a strong runtime password, so no database or environment variable is required. Set `MSSQL_SA_PASSWORD` only when you need to override the generated password.
Docker Desktop or another Docker engine must be running before starting the integration tests. If the engine is unavailable, the test setup reports that prerequisite directly.

Run the backend tests with Cobertura coverage output:

```bash
./scripts/test-coverage.sh
```

The coverage file is written under `TestResults/coverage`.
