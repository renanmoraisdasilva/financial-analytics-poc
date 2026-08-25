using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialAnalytics.Api.Migrations.FinancialAnalytics
{
    /// <inheritdoc />
    public partial class PersistValidationResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ValidationResultJson",
                table: "PipelineRun",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidationResultJson",
                table: "PipelineRun");
        }
    }
}
