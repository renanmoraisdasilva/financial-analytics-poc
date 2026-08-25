using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialAnalytics.Api.Migrations.FinancialAnalytics
{
    /// <inheritdoc />
    public partial class ExpandAnalyticalDimensions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DimCurrency",
                columns: new[] { "CurrencyKey", "CurrencyCode", "CurrencyName" },
                values: new object[] { 2, "CAD", "Canadian Dollar" });

            migrationBuilder.InsertData(
                table: "DimEntity",
                columns: new[] { "EntityKey", "CountryCode", "EntityCode", "EntityName" },
                values: new object[] { 2, "CA", "CA", "Northstar Canada" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DimCurrency",
                keyColumn: "CurrencyKey",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DimEntity",
                keyColumn: "EntityKey",
                keyValue: 2);
        }
    }
}
