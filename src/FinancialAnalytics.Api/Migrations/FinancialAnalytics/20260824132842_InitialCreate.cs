using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinancialAnalytics.Api.Migrations.FinancialAnalytics
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DimAccount",
                columns: table => new
                {
                    AccountKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AccountCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentAccountKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimAccount", x => x.AccountKey);
                    table.ForeignKey(
                        name: "FK_DimAccount_DimAccount_ParentAccountKey",
                        column: x => x.ParentAccountKey,
                        principalTable: "DimAccount",
                        principalColumn: "AccountKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DimCurrency",
                columns: table => new
                {
                    CurrencyKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyCode = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false),
                    CurrencyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimCurrency", x => x.CurrencyKey);
                });

            migrationBuilder.CreateTable(
                name: "DimDate",
                columns: table => new
                {
                    DateKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Day = table.Column<byte>(type: "tinyint", nullable: false),
                    Month = table.Column<byte>(type: "tinyint", nullable: false),
                    MonthName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Quarter = table.Column<byte>(type: "tinyint", nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimDate", x => x.DateKey);
                });

            migrationBuilder.CreateTable(
                name: "DimEntity",
                columns: table => new
                {
                    EntityKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CountryCode = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DimEntity", x => x.EntityKey);
                });

            migrationBuilder.CreateTable(
                name: "PipelineRun",
                columns: table => new
                {
                    PipelineRunId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RecordsExtracted = table.Column<int>(type: "int", nullable: false),
                    RecordsTransformed = table.Column<int>(type: "int", nullable: false),
                    RecordsValidated = table.Column<int>(type: "int", nullable: false),
                    RecordsLoaded = table.Column<int>(type: "int", nullable: false),
                    RecordsInserted = table.Column<int>(type: "int", nullable: false),
                    RecordsAlreadyExisting = table.Column<int>(type: "int", nullable: false),
                    RecordsFailed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineRun", x => x.PipelineRunId);
                });

            migrationBuilder.CreateTable(
                name: "FactGL",
                columns: table => new
                {
                    FactGLKey = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceSystem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SourceTransactionId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateKey = table.Column<int>(type: "int", nullable: false),
                    AccountKey = table.Column<int>(type: "int", nullable: false),
                    EntityKey = table.Column<int>(type: "int", nullable: false),
                    CurrencyKey = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactGL", x => x.FactGLKey);
                    table.ForeignKey(
                        name: "FK_FactGL_DimAccount_AccountKey",
                        column: x => x.AccountKey,
                        principalTable: "DimAccount",
                        principalColumn: "AccountKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactGL_DimCurrency_CurrencyKey",
                        column: x => x.CurrencyKey,
                        principalTable: "DimCurrency",
                        principalColumn: "CurrencyKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactGL_DimDate_DateKey",
                        column: x => x.DateKey,
                        principalTable: "DimDate",
                        principalColumn: "DateKey",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactGL_DimEntity_EntityKey",
                        column: x => x.EntityKey,
                        principalTable: "DimEntity",
                        principalColumn: "EntityKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StgTransaction",
                columns: table => new
                {
                    StgTransactionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PipelineRunId = table.Column<long>(type: "bigint", nullable: false),
                    SourceTransactionId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SourceAccountCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SourceAccountName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SourceEntityCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CurrencyCode = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StgTransaction", x => x.StgTransactionId);
                    table.ForeignKey(
                        name: "FK_StgTransaction_PipelineRun_PipelineRunId",
                        column: x => x.PipelineRunId,
                        principalTable: "PipelineRun",
                        principalColumn: "PipelineRunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DimAccount",
                columns: new[] { "AccountKey", "AccountCategory", "AccountCode", "AccountName", "ParentAccountKey" },
                values: new object[,]
                {
                    { 1, "Revenue", "REV-PROD", "Product Revenue", null },
                    { 2, "Revenue", "REV-SERV", "Service Revenue", null },
                    { 3, "COGS", "COGS-MAT", "Materials", null },
                    { 4, "Operating Expense", "OPEX-SAL", "Salaries", null }
                });

            migrationBuilder.InsertData(
                table: "DimCurrency",
                columns: new[] { "CurrencyKey", "CurrencyCode", "CurrencyName" },
                values: new object[] { 1, "USD", "US Dollar" });

            migrationBuilder.InsertData(
                table: "DimDate",
                columns: new[] { "DateKey", "Date", "Day", "Month", "MonthName", "Quarter", "Year" },
                values: new object[,]
                {
                    { 20260105, new DateOnly(2026, 1, 5), (byte)5, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260109, new DateOnly(2026, 1, 9), (byte)9, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260113, new DateOnly(2026, 1, 13), (byte)13, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260117, new DateOnly(2026, 1, 17), (byte)17, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260121, new DateOnly(2026, 1, 21), (byte)21, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260125, new DateOnly(2026, 1, 25), (byte)25, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260129, new DateOnly(2026, 1, 29), (byte)29, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260202, new DateOnly(2026, 2, 2), (byte)2, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260206, new DateOnly(2026, 2, 6), (byte)6, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260210, new DateOnly(2026, 2, 10), (byte)10, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260214, new DateOnly(2026, 2, 14), (byte)14, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260218, new DateOnly(2026, 2, 18), (byte)18, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260222, new DateOnly(2026, 2, 22), (byte)22, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260226, new DateOnly(2026, 2, 26), (byte)26, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260302, new DateOnly(2026, 3, 2), (byte)2, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260306, new DateOnly(2026, 3, 6), (byte)6, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260310, new DateOnly(2026, 3, 10), (byte)10, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260314, new DateOnly(2026, 3, 14), (byte)14, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260318, new DateOnly(2026, 3, 18), (byte)18, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260322, new DateOnly(2026, 3, 22), (byte)22, (byte)3, "March", (byte)1, (short)2026 }
                });

            migrationBuilder.InsertData(
                table: "DimEntity",
                columns: new[] { "EntityKey", "CountryCode", "EntityCode", "EntityName" },
                values: new object[] { 1, "US", "US", "Northstar US" });

            migrationBuilder.CreateIndex(
                name: "IX_DimAccount_AccountCode",
                table: "DimAccount",
                column: "AccountCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DimAccount_ParentAccountKey",
                table: "DimAccount",
                column: "ParentAccountKey");

            migrationBuilder.CreateIndex(
                name: "IX_DimCurrency_CurrencyCode",
                table: "DimCurrency",
                column: "CurrencyCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DimDate_Date",
                table: "DimDate",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DimEntity_EntityCode",
                table: "DimEntity",
                column: "EntityCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FactGL_AccountKey",
                table: "FactGL",
                column: "AccountKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactGL_CurrencyKey",
                table: "FactGL",
                column: "CurrencyKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactGL_DateKey_AccountKey_EntityKey_CurrencyKey",
                table: "FactGL",
                columns: new[] { "DateKey", "AccountKey", "EntityKey", "CurrencyKey" });

            migrationBuilder.CreateIndex(
                name: "IX_FactGL_EntityKey",
                table: "FactGL",
                column: "EntityKey");

            migrationBuilder.CreateIndex(
                name: "IX_FactGL_SourceTransactionId",
                table: "FactGL",
                column: "SourceTransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PipelineRun_StartedAt",
                table: "PipelineRun",
                column: "StartedAt");

            migrationBuilder.CreateIndex(
                name: "IX_StgTransaction_PipelineRunId_SourceTransactionId",
                table: "StgTransaction",
                columns: new[] { "PipelineRunId", "SourceTransactionId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactGL");

            migrationBuilder.DropTable(
                name: "StgTransaction");

            migrationBuilder.DropTable(
                name: "DimAccount");

            migrationBuilder.DropTable(
                name: "DimCurrency");

            migrationBuilder.DropTable(
                name: "DimDate");

            migrationBuilder.DropTable(
                name: "DimEntity");

            migrationBuilder.DropTable(
                name: "PipelineRun");
        }
    }
}
