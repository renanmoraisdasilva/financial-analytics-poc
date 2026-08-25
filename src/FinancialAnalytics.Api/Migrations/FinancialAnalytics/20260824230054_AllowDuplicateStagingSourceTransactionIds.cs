using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialAnalytics.Api.Migrations.FinancialAnalytics
{
    /// <inheritdoc />
    public partial class AllowDuplicateStagingSourceTransactionIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StgTransaction_PipelineRunId_SourceTransactionId",
                table: "StgTransaction");

            migrationBuilder.CreateIndex(
                name: "IX_StgTransaction_PipelineRunId_SourceTransactionId",
                table: "StgTransaction",
                columns: new[] { "PipelineRunId", "SourceTransactionId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StgTransaction_PipelineRunId_SourceTransactionId",
                table: "StgTransaction");

            migrationBuilder.CreateIndex(
                name: "IX_StgTransaction_PipelineRunId_SourceTransactionId",
                table: "StgTransaction",
                columns: new[] { "PipelineRunId", "SourceTransactionId" },
                unique: true);
        }
    }
}
