using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialAnalytics.Api.Migrations.FinancialAnalytics
{
    /// <inheritdoc />
    public partial class PersistPipelineErrors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PipelineError",
                columns: table => new
                {
                    PipelineErrorId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PipelineRunId = table.Column<long>(type: "bigint", nullable: false),
                    Stage = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ErrorCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SourceTransactionId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipelineError", x => x.PipelineErrorId);
                    table.ForeignKey(
                        name: "FK_PipelineError_PipelineRun_PipelineRunId",
                        column: x => x.PipelineRunId,
                        principalTable: "PipelineRun",
                        principalColumn: "PipelineRunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PipelineError_PipelineRunId_SourceTransactionId",
                table: "PipelineError",
                columns: new[] { "PipelineRunId", "SourceTransactionId" });

            migrationBuilder.CreateIndex(
                name: "IX_PipelineError_PipelineRunId_Stage",
                table: "PipelineError",
                columns: new[] { "PipelineRunId", "Stage" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PipelineError");
        }
    }
}
