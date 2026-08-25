# 1. The POC architecture

```text
┌──────────────┐
│   Fake ERP   │
│              │
│ Transactions │
│ Accounts     │
│ Entities     │
└──────┬───────┘
       │
       │ Extract
       ▼
┌──────────────┐
│   C# ETL     │
│              │
│ Extract      │
│ Transform    │
│ Validate     │
│ Load         │
└──────┬───────┘
       │
       │ Load
       ▼
┌──────────────────────────┐
│       SQL Server         │
│                          │
│  FactGL                  │
│  DimAccount              │
│  DimEntity               │
│  DimDate                 │
│  DimCurrency              │
└────────────┬─────────────┘
             │
             │ SQL
             ▼
┌──────────────────────────┐
│       .NET API           │
│                          │
│ Income Statement         │
│ Revenue                  │
│ Gross Profit             │
│ Drill-down               │
└────────────┬─────────────┘
             │
             │ JSON
             ▼
┌──────────────────────────┐
│         React            │
│                          │
│ Pipeline                 │
│ Report                   │
│ Transaction Drill-down   │
└──────────────────────────┘
```


# 2. The Fake ERP

```text
FakeERP
│
├── Accounts
├── Entities
└── Transactions
```

### Accounts

```text
4000 | Product Sales
4010 | Service Sales
5000 | Materials
6000 | Salaries
```

### Entities

```text
1 | Northstar US
```

### Transactions

```text
A001 | 2026-01-05 | 4000 | 10000 | USD
A002 | 2026-01-08 | 4000 | 15000 | USD
A003 | 2026-01-15 | 4010 |  5000 | USD
...
```

```text
ONE ERP
ONE ENTITY
ONE CURRENCY
```

---

# 3. Architecture ready for ERP #2

```text
              IErpSource
                  │
          ┌───────┴───────┐
          ▼               ▼
      FakeErpSource   FutureErpSource
```

---

# 4. What exactly does the ETL do?


```text
Extract
   ↓
Transform
   ↓
Validate
   ↓
Load
```

### Extract

Read from Fake ERP:

```text
20 transactions
```

### Transform

Convert source data into our analytical model.

```text
ERP Account 4000
        ↓
Product Revenue
```

### Validate

```text
✓ Account exists
✓ Entity exists
✓ Date is valid
✓ Amount is valid
✓ No duplicate transaction ID
```

### Load

```text
FactGL
DimAccount
DimEntity
DimDate
DimCurrency
```

---

# 5. UI


```text
┌──────────────────────────────────────────────────────────────┐
│ Northstar Analytics                           Reports        │
├──────────────────────────────────────────────────────────────┤
│                                                              │
│ DATA PIPELINE                                                │
│                                                              │
│ Fake ERP                                                     │
│ ┌───────────────────────┐                                    │
│ │ ✓ Connected           │                                    │
│ │ 20 transactions       │                                    │
│ └───────────┬───────────┘                                    │
│             │                                                │
│             ▼                                                │
│ ┌───────────────────────┐                                    │
│ │ 1. Extract            │                                    │
│ │ 20 records            │                                    │
│ │ ✓ Complete            │                                    │
│ └───────────┬───────────┘                                    │
│             │                                                │
│             ▼                                                │
│ ┌───────────────────────┐                                    │
│ │ 2. Transform          │                                    │
│ │ 20 records            │                                    │
│ │ ✓ Complete            │                                    │
│ └───────────┬───────────┘                                    │
│             │                                                │
│             ▼                                                │
│ ┌───────────────────────┐                                    │
│ │ 3. Validate           │                                    │
│ │ 20 / 20 valid         │                                    │
│ │ ✓ Complete            │                                    │
│ └───────────┬───────────┘                                    │
│             │                                                │
│             ▼                                                │
│ ┌───────────────────────┐                                    │
│ │ 4. Load               │                                    │
│ │ 20 records → FactGL   │                                    │
│ │ ✓ Complete            │                                    │
│ └───────────────────────┘                                    │
│                                                              │
│                    [ Run Pipeline ]                          │
│                                                              │
└──────────────────────────────────────────────────────────────┘
```

---

# 6. Clicking Transform

Click:

**Transform**

And show:

```text
TRANSFORMATION
──────────────────────────────────────────────────────────────

Source ERP Record

┌─────────────────────────────────────────────────────────────┐
│ ID          A001                                            │
│ Account     4000                                            │
│ Description Product Sales                                   │
│ Amount      $10,000                                         │
│ Date        Jan 5, 2026                                     │
└─────────────────────────────────────────────────────────────┘

                         ↓

Canonical Record

┌─────────────────────────────────────────────────────────────┐
│ Transaction     A001                                        │
│ Account         Product Revenue                             │
│ Entity          Northstar US                               │
│ Amount          $10,000 USD                                 │
│ Date            Jan 5, 2026                                 │
└─────────────────────────────────────────────────────────────┘
```

Then underneath:

```text
Transformation rules

4000 → Product Revenue
4010 → Service Revenue
5000 → Materials
6000 → Salaries
```

---

# 7. Clicking Validate

Show:

```text
VALIDATION
──────────────────────────────

Transactions
✓ 20 read
✓ 20 valid
✓ 0 duplicates

Accounts
✓ 4 mapped
✓ 0 unmapped

Entities
✓ 1 valid
✓ 0 unknown

Amounts
✓ 20 valid
✓ 0 invalid

Source total
$85,000

Warehouse total
$85,000

✓ RECONCILIATION PASSED
```

---

# 8. Clicking Load

```text
ANALYTICAL MODEL
──────────────────────────────────────────────────────────────

FactGL

Transaction   Date       Account            Amount
─────────────────────────────────────────────────────────────
A001          Jan 05     Product Revenue    $10,000
A002          Jan 08     Product Revenue    $15,000
A003          Jan 15     Service Revenue     $5,000
...
```

```text
Rows loaded
───────────
FactGL             20
DimAccount          4
DimEntity           1
DimDate            20
DimCurrency         1
```

---

# 9. Report page

Navigation:

```text
Pipeline | Report
```

Click Report.

```text
INCOME STATEMENT
Q1 2026
Northstar US
USD

Revenue                         $74,000
  Product Revenue               $57,000
  Service Revenue               $17,000

COGS                           ($23,000)
  Materials                    ($23,000)

────────────────────────────────────────

Gross Profit                    $51,000
Gross Margin                       68.9%

Operating Expenses              ($7,000)

────────────────────────────────────────

Net Income                      $44,000
```

---

# 10. Drill-down

Click:

**Revenue $74,000**

Side panel:

```text
REVENUE
$74,000

Definition
──────────
Sum of transactions mapped to
Revenue accounts.

By Account
──────────
Product Revenue       $57,000
Service Revenue       $17,000

[ View Transactions ]
```

Click Product Revenue:

```text
PRODUCT REVENUE
$57,000

A001    Jan 05    $10,000
A002    Jan 08    $15,000
A006    Feb 03    $12,000
A009    Mar 04    $20,000

Total              $57,000
```


```text
Report
  ↓
Metric
  ↓
Analytical model
  ↓
FactGL
  ↓
Source transaction
```

---
---

# 12. What we're deliberately NOT building yet

For **POC v1**, no:

* second ERP
* currency conversion
* multi-company consolidation
* Excel
* generic report builder
* authentication
* cloud
* queues
* background workers
* AI
* fancy charts


# 13. Technology stack

**Backend**

```text
.NET 8
ASP.NET Core
Dapper
```

**Database**

```text
SQL Server
```

**Frontend**

```text
React
TypeScript
Vite
```

**Testing**

```text
xUnit
```

```text
Docker
```

to make SQL Server setup painless.

---

## One important architectural decision before coding

I would make **the Fake ERP a separate conceptual component**, even if initially it's just seeded SQL data.

Something like:

```text
src/
├── Api/
├── Application/
├── Domain/
├── Infrastructure/
│   ├── FakeErp/
│   ├── Etl/
│   └── Sql/
└── Web/
```

So later:

```text
Infrastructure/
├── FakeErp/
├── AnotherErp/
├── Etl/
└── Sql/
```
