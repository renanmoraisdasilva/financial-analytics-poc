#!/usr/bin/env bash
set -euo pipefail

script_dir="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
repo_root="$(cd "$script_dir/.." && pwd)"

cd "$repo_root"
dotnet test tests/FinancialAnalytics.Api.Tests/FinancialAnalytics.Api.Tests.csproj \
  --collect:"XPlat Code Coverage" \
  --results-directory TestResults/coverage \
  -- \
  DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=cobertura