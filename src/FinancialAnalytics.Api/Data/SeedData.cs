namespace FinancialAnalytics.Api;

public static class SeedData
{
    private static readonly DateTime SeedTimestamp = new(2026, 4, 1, 12, 0, 0, DateTimeKind.Utc);

    public static readonly ErpAccount[] ErpAccounts =
    [
        new() { AccountId = 1, AccountCode = "4000", AccountName = "Product Sales" },
        new() { AccountId = 2, AccountCode = "4010", AccountName = "Service Sales" },
        new() { AccountId = 3, AccountCode = "5000", AccountName = "Materials" },
        new() { AccountId = 4, AccountCode = "6000", AccountName = "Salaries" }
    ];

    public static readonly ErpEntity[] ErpEntities =
    [
        new() { EntityId = 1, EntityCode = "US", EntityName = "Northstar US", CountryCode = "US" },
        new() { EntityId = 2, EntityCode = "CA", EntityName = "Northstar Canada", CountryCode = "CA" }
    ];

    public static readonly ErpTransaction[] ErpTransactions = BuildTransactions();

    public static readonly DimAccount[] DimAccounts =
    [
        new() { AccountKey = 1, AccountCode = "REV-PROD", AccountName = "Product Revenue", AccountCategory = "Revenue" },
        new() { AccountKey = 2, AccountCode = "REV-SERV", AccountName = "Service Revenue", AccountCategory = "Revenue" },
        new() { AccountKey = 3, AccountCode = "COGS-MAT", AccountName = "Materials", AccountCategory = "COGS" },
        new() { AccountKey = 4, AccountCode = "OPEX-SAL", AccountName = "Salaries", AccountCategory = "Operating Expense" }
    ];

    public static readonly DimEntity[] DimEntities =
    [
        new() { EntityKey = 1, EntityCode = "US", EntityName = "Northstar US", CountryCode = "US" },
        new() { EntityKey = 2, EntityCode = "CA", EntityName = "Northstar Canada", CountryCode = "CA" }
    ];

    public static readonly DimDate[] DimDates = BuildDateDimension();

    public static readonly DimCurrency[] DimCurrencies =
    [
        new() { CurrencyKey = 1, CurrencyCode = "USD", CurrencyName = "US Dollar" },
        new() { CurrencyKey = 2, CurrencyCode = "CAD", CurrencyName = "Canadian Dollar" }
    ];

    private static DimDate[] BuildDateDimension()
    {
        var startDate = new DateOnly(2025, 1, 1);
        var endDate = new DateOnly(2026, 12, 31);

        return Enumerable.Range(0, endDate.DayNumber - startDate.DayNumber + 1)
            .Select(offset =>
            {
                var date = startDate.AddDays(offset);
                return new DimDate
                {
                    DateKey = date.Year * 10000 + date.Month * 100 + date.Day,
                    Date = date,
                    Day = (byte)date.Day,
                    Month = (byte)date.Month,
                    MonthName = date.ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture),
                    Quarter = (byte)((date.Month - 1) / 3 + 1),
                    Year = (short)date.Year
                };
            })
            .ToArray();
    }

    private static ErpTransaction[] BuildTransactions()
    {
        var values = new (int AccountId, decimal Amount, string Description)[]
        {
            (1, 10000, "Product Sales"), (1, 15000, "Product Sales"), (1, 12000, "Product Sales"), (1, 10000, "Product Sales"), (1, 10000, "Product Sales"),
            (2, 5000, "Service Sales"), (2, 4000, "Service Sales"), (2, 4000, "Service Sales"), (2, 4000, "Service Sales"),
            (3, -8000, "Materials"), (3, -5000, "Materials"), (3, -4000, "Materials"), (3, -3000, "Materials"), (3, -3000, "Materials"),
            (4, -2000, "Salaries"), (4, -1000, "Salaries"), (4, -1000, "Salaries"), (4, -1000, "Salaries"), (4, -1000, "Salaries"), (4, -1000, "Salaries")
        };

        return Enumerable.Range(0, 10_000)
            .Select(index =>
            {
                var value = values[index % values.Length];
                var isOriginalDemoRecord = index < values.Length;
                var entityId = index % 2 == 0 ? 1 : 2;
                var amount = isOriginalDemoRecord
                    ? value.Amount
                    : value.Amount * (1m + (index % 5) * 0.05m);

                return new ErpTransaction
                {
                    TransactionId = $"A{index + 1:000}",
                    TransactionDate = isOriginalDemoRecord
                        ? new DateOnly(2026, 1, 5).AddDays(index * 4)
                        : new DateOnly(2025, 1, 1).AddDays((index - values.Length) % 730),
                    AccountId = value.AccountId,
                    EntityId = entityId,
                    Amount = amount,
                    CurrencyCode = entityId == 1 ? "USD" : "CAD",
                    Description = value.Description,
                    CreatedAt = SeedTimestamp.AddMinutes(index)
                };
            })
            .ToArray();
    }
}
