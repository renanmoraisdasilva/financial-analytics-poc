using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinancialAnalytics.Api.Migrations.FakeErp
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    EntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CountryCode = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CurrencyCode = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountCode", "AccountName" },
                values: new object[,]
                {
                    { 1, "4000", "Product Sales" },
                    { 2, "4010", "Service Sales" },
                    { 3, "5000", "Materials" },
                    { 4, "6000", "Salaries" }
                });

            migrationBuilder.InsertData(
                table: "Entity",
                columns: new[] { "EntityId", "CountryCode", "EntityCode", "EntityName" },
                values: new object[] { 1, "US", "US", "Northstar US" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "TransactionId", "AccountId", "Amount", "CreatedAt", "CurrencyCode", "Description", "EntityId", "TransactionDate" },
                values: new object[,]
                {
                    { "A001", 1, 10000m, new DateTime(2026, 4, 1, 12, 0, 0, 0, DateTimeKind.Utc), "USD", "Product Sales", 1, new DateOnly(2026, 1, 5) },
                    { "A002", 1, 15000m, new DateTime(2026, 4, 1, 12, 1, 0, 0, DateTimeKind.Utc), "USD", "Product Sales", 1, new DateOnly(2026, 1, 9) },
                    { "A003", 1, 12000m, new DateTime(2026, 4, 1, 12, 2, 0, 0, DateTimeKind.Utc), "USD", "Product Sales", 1, new DateOnly(2026, 1, 13) },
                    { "A004", 1, 10000m, new DateTime(2026, 4, 1, 12, 3, 0, 0, DateTimeKind.Utc), "USD", "Product Sales", 1, new DateOnly(2026, 1, 17) },
                    { "A005", 1, 10000m, new DateTime(2026, 4, 1, 12, 4, 0, 0, DateTimeKind.Utc), "USD", "Product Sales", 1, new DateOnly(2026, 1, 21) },
                    { "A006", 2, 5000m, new DateTime(2026, 4, 1, 12, 5, 0, 0, DateTimeKind.Utc), "USD", "Service Sales", 1, new DateOnly(2026, 1, 25) },
                    { "A007", 2, 4000m, new DateTime(2026, 4, 1, 12, 6, 0, 0, DateTimeKind.Utc), "USD", "Service Sales", 1, new DateOnly(2026, 1, 29) },
                    { "A008", 2, 4000m, new DateTime(2026, 4, 1, 12, 7, 0, 0, DateTimeKind.Utc), "USD", "Service Sales", 1, new DateOnly(2026, 2, 2) },
                    { "A009", 2, 4000m, new DateTime(2026, 4, 1, 12, 8, 0, 0, DateTimeKind.Utc), "USD", "Service Sales", 1, new DateOnly(2026, 2, 6) },
                    { "A010", 3, -8000m, new DateTime(2026, 4, 1, 12, 9, 0, 0, DateTimeKind.Utc), "USD", "Materials", 1, new DateOnly(2026, 2, 10) },
                    { "A011", 3, -5000m, new DateTime(2026, 4, 1, 12, 10, 0, 0, DateTimeKind.Utc), "USD", "Materials", 1, new DateOnly(2026, 2, 14) },
                    { "A012", 3, -4000m, new DateTime(2026, 4, 1, 12, 11, 0, 0, DateTimeKind.Utc), "USD", "Materials", 1, new DateOnly(2026, 2, 18) },
                    { "A013", 3, -3000m, new DateTime(2026, 4, 1, 12, 12, 0, 0, DateTimeKind.Utc), "USD", "Materials", 1, new DateOnly(2026, 2, 22) },
                    { "A014", 3, -3000m, new DateTime(2026, 4, 1, 12, 13, 0, 0, DateTimeKind.Utc), "USD", "Materials", 1, new DateOnly(2026, 2, 26) },
                    { "A015", 4, -2000m, new DateTime(2026, 4, 1, 12, 14, 0, 0, DateTimeKind.Utc), "USD", "Salaries", 1, new DateOnly(2026, 3, 2) },
                    { "A016", 4, -1000m, new DateTime(2026, 4, 1, 12, 15, 0, 0, DateTimeKind.Utc), "USD", "Salaries", 1, new DateOnly(2026, 3, 6) },
                    { "A017", 4, -1000m, new DateTime(2026, 4, 1, 12, 16, 0, 0, DateTimeKind.Utc), "USD", "Salaries", 1, new DateOnly(2026, 3, 10) },
                    { "A018", 4, -1000m, new DateTime(2026, 4, 1, 12, 17, 0, 0, DateTimeKind.Utc), "USD", "Salaries", 1, new DateOnly(2026, 3, 14) },
                    { "A019", 4, -1000m, new DateTime(2026, 4, 1, 12, 18, 0, 0, DateTimeKind.Utc), "USD", "Salaries", 1, new DateOnly(2026, 3, 18) },
                    { "A020", 4, -1000m, new DateTime(2026, 4, 1, 12, 19, 0, 0, DateTimeKind.Utc), "USD", "Salaries", 1, new DateOnly(2026, 3, 22) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountCode",
                table: "Account",
                column: "AccountCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entity_EntityCode",
                table: "Entity",
                column: "EntityCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountId",
                table: "Transaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_EntityId",
                table: "Transaction",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionDate_AccountId",
                table: "Transaction",
                columns: new[] { "TransactionDate", "AccountId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
