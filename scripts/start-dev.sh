#!/usr/bin/env bash
set -euo pipefail

REPOSITORY_ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
cd "$REPOSITORY_ROOT"

command -v docker >/dev/null || { echo "Docker is required." >&2; exit 1; }
docker compose up --build
