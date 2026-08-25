using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialAnalytics.Api.Migrations.FinancialAnalytics
{
    /// <inheritdoc />
    public partial class PersistPipelineScenario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Scenario",
                table: "PipelineRun",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Scenario",
                table: "PipelineRun");
        }
    }
}
