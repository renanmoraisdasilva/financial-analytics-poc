# Tests

The API tests use xUnit and FluentAssertions. They cover the deterministic demo source and the explicit C# account transformation rules.

Run the backend tests with Cobertura coverage output:

```bash
./scripts/test-coverage.sh
```

The coverage file is written under `TestResults/coverage`.
