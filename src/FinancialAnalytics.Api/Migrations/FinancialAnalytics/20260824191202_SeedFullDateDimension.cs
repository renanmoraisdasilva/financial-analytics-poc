using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinancialAnalytics.Api.Migrations.FinancialAnalytics
{
    /// <inheritdoc />
    public partial class SeedFullDateDimension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DimDate",
                columns: new[] { "DateKey", "Date", "Day", "Month", "MonthName", "Quarter", "Year" },
                values: new object[,]
                {
                    { 20250101, new DateOnly(2025, 1, 1), (byte)1, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250102, new DateOnly(2025, 1, 2), (byte)2, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250103, new DateOnly(2025, 1, 3), (byte)3, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250104, new DateOnly(2025, 1, 4), (byte)4, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250105, new DateOnly(2025, 1, 5), (byte)5, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250106, new DateOnly(2025, 1, 6), (byte)6, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250107, new DateOnly(2025, 1, 7), (byte)7, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250108, new DateOnly(2025, 1, 8), (byte)8, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250109, new DateOnly(2025, 1, 9), (byte)9, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250110, new DateOnly(2025, 1, 10), (byte)10, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250111, new DateOnly(2025, 1, 11), (byte)11, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250112, new DateOnly(2025, 1, 12), (byte)12, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250113, new DateOnly(2025, 1, 13), (byte)13, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250114, new DateOnly(2025, 1, 14), (byte)14, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250115, new DateOnly(2025, 1, 15), (byte)15, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250116, new DateOnly(2025, 1, 16), (byte)16, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250117, new DateOnly(2025, 1, 17), (byte)17, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250118, new DateOnly(2025, 1, 18), (byte)18, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250119, new DateOnly(2025, 1, 19), (byte)19, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250120, new DateOnly(2025, 1, 20), (byte)20, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250121, new DateOnly(2025, 1, 21), (byte)21, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250122, new DateOnly(2025, 1, 22), (byte)22, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250123, new DateOnly(2025, 1, 23), (byte)23, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250124, new DateOnly(2025, 1, 24), (byte)24, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250125, new DateOnly(2025, 1, 25), (byte)25, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250126, new DateOnly(2025, 1, 26), (byte)26, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250127, new DateOnly(2025, 1, 27), (byte)27, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250128, new DateOnly(2025, 1, 28), (byte)28, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250129, new DateOnly(2025, 1, 29), (byte)29, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250130, new DateOnly(2025, 1, 30), (byte)30, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250131, new DateOnly(2025, 1, 31), (byte)31, (byte)1, "January", (byte)1, (short)2025 },
                    { 20250201, new DateOnly(2025, 2, 1), (byte)1, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250202, new DateOnly(2025, 2, 2), (byte)2, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250203, new DateOnly(2025, 2, 3), (byte)3, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250204, new DateOnly(2025, 2, 4), (byte)4, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250205, new DateOnly(2025, 2, 5), (byte)5, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250206, new DateOnly(2025, 2, 6), (byte)6, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250207, new DateOnly(2025, 2, 7), (byte)7, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250208, new DateOnly(2025, 2, 8), (byte)8, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250209, new DateOnly(2025, 2, 9), (byte)9, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250210, new DateOnly(2025, 2, 10), (byte)10, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250211, new DateOnly(2025, 2, 11), (byte)11, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250212, new DateOnly(2025, 2, 12), (byte)12, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250213, new DateOnly(2025, 2, 13), (byte)13, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250214, new DateOnly(2025, 2, 14), (byte)14, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250215, new DateOnly(2025, 2, 15), (byte)15, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250216, new DateOnly(2025, 2, 16), (byte)16, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250217, new DateOnly(2025, 2, 17), (byte)17, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250218, new DateOnly(2025, 2, 18), (byte)18, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250219, new DateOnly(2025, 2, 19), (byte)19, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250220, new DateOnly(2025, 2, 20), (byte)20, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250221, new DateOnly(2025, 2, 21), (byte)21, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250222, new DateOnly(2025, 2, 22), (byte)22, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250223, new DateOnly(2025, 2, 23), (byte)23, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250224, new DateOnly(2025, 2, 24), (byte)24, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250225, new DateOnly(2025, 2, 25), (byte)25, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250226, new DateOnly(2025, 2, 26), (byte)26, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250227, new DateOnly(2025, 2, 27), (byte)27, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250228, new DateOnly(2025, 2, 28), (byte)28, (byte)2, "February", (byte)1, (short)2025 },
                    { 20250301, new DateOnly(2025, 3, 1), (byte)1, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250302, new DateOnly(2025, 3, 2), (byte)2, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250303, new DateOnly(2025, 3, 3), (byte)3, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250304, new DateOnly(2025, 3, 4), (byte)4, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250305, new DateOnly(2025, 3, 5), (byte)5, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250306, new DateOnly(2025, 3, 6), (byte)6, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250307, new DateOnly(2025, 3, 7), (byte)7, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250308, new DateOnly(2025, 3, 8), (byte)8, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250309, new DateOnly(2025, 3, 9), (byte)9, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250310, new DateOnly(2025, 3, 10), (byte)10, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250311, new DateOnly(2025, 3, 11), (byte)11, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250312, new DateOnly(2025, 3, 12), (byte)12, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250313, new DateOnly(2025, 3, 13), (byte)13, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250314, new DateOnly(2025, 3, 14), (byte)14, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250315, new DateOnly(2025, 3, 15), (byte)15, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250316, new DateOnly(2025, 3, 16), (byte)16, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250317, new DateOnly(2025, 3, 17), (byte)17, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250318, new DateOnly(2025, 3, 18), (byte)18, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250319, new DateOnly(2025, 3, 19), (byte)19, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250320, new DateOnly(2025, 3, 20), (byte)20, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250321, new DateOnly(2025, 3, 21), (byte)21, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250322, new DateOnly(2025, 3, 22), (byte)22, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250323, new DateOnly(2025, 3, 23), (byte)23, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250324, new DateOnly(2025, 3, 24), (byte)24, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250325, new DateOnly(2025, 3, 25), (byte)25, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250326, new DateOnly(2025, 3, 26), (byte)26, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250327, new DateOnly(2025, 3, 27), (byte)27, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250328, new DateOnly(2025, 3, 28), (byte)28, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250329, new DateOnly(2025, 3, 29), (byte)29, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250330, new DateOnly(2025, 3, 30), (byte)30, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250331, new DateOnly(2025, 3, 31), (byte)31, (byte)3, "March", (byte)1, (short)2025 },
                    { 20250401, new DateOnly(2025, 4, 1), (byte)1, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250402, new DateOnly(2025, 4, 2), (byte)2, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250403, new DateOnly(2025, 4, 3), (byte)3, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250404, new DateOnly(2025, 4, 4), (byte)4, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250405, new DateOnly(2025, 4, 5), (byte)5, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250406, new DateOnly(2025, 4, 6), (byte)6, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250407, new DateOnly(2025, 4, 7), (byte)7, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250408, new DateOnly(2025, 4, 8), (byte)8, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250409, new DateOnly(2025, 4, 9), (byte)9, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250410, new DateOnly(2025, 4, 10), (byte)10, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250411, new DateOnly(2025, 4, 11), (byte)11, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250412, new DateOnly(2025, 4, 12), (byte)12, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250413, new DateOnly(2025, 4, 13), (byte)13, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250414, new DateOnly(2025, 4, 14), (byte)14, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250415, new DateOnly(2025, 4, 15), (byte)15, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250416, new DateOnly(2025, 4, 16), (byte)16, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250417, new DateOnly(2025, 4, 17), (byte)17, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250418, new DateOnly(2025, 4, 18), (byte)18, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250419, new DateOnly(2025, 4, 19), (byte)19, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250420, new DateOnly(2025, 4, 20), (byte)20, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250421, new DateOnly(2025, 4, 21), (byte)21, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250422, new DateOnly(2025, 4, 22), (byte)22, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250423, new DateOnly(2025, 4, 23), (byte)23, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250424, new DateOnly(2025, 4, 24), (byte)24, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250425, new DateOnly(2025, 4, 25), (byte)25, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250426, new DateOnly(2025, 4, 26), (byte)26, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250427, new DateOnly(2025, 4, 27), (byte)27, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250428, new DateOnly(2025, 4, 28), (byte)28, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250429, new DateOnly(2025, 4, 29), (byte)29, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250430, new DateOnly(2025, 4, 30), (byte)30, (byte)4, "April", (byte)2, (short)2025 },
                    { 20250501, new DateOnly(2025, 5, 1), (byte)1, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250502, new DateOnly(2025, 5, 2), (byte)2, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250503, new DateOnly(2025, 5, 3), (byte)3, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250504, new DateOnly(2025, 5, 4), (byte)4, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250505, new DateOnly(2025, 5, 5), (byte)5, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250506, new DateOnly(2025, 5, 6), (byte)6, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250507, new DateOnly(2025, 5, 7), (byte)7, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250508, new DateOnly(2025, 5, 8), (byte)8, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250509, new DateOnly(2025, 5, 9), (byte)9, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250510, new DateOnly(2025, 5, 10), (byte)10, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250511, new DateOnly(2025, 5, 11), (byte)11, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250512, new DateOnly(2025, 5, 12), (byte)12, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250513, new DateOnly(2025, 5, 13), (byte)13, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250514, new DateOnly(2025, 5, 14), (byte)14, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250515, new DateOnly(2025, 5, 15), (byte)15, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250516, new DateOnly(2025, 5, 16), (byte)16, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250517, new DateOnly(2025, 5, 17), (byte)17, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250518, new DateOnly(2025, 5, 18), (byte)18, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250519, new DateOnly(2025, 5, 19), (byte)19, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250520, new DateOnly(2025, 5, 20), (byte)20, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250521, new DateOnly(2025, 5, 21), (byte)21, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250522, new DateOnly(2025, 5, 22), (byte)22, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250523, new DateOnly(2025, 5, 23), (byte)23, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250524, new DateOnly(2025, 5, 24), (byte)24, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250525, new DateOnly(2025, 5, 25), (byte)25, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250526, new DateOnly(2025, 5, 26), (byte)26, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250527, new DateOnly(2025, 5, 27), (byte)27, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250528, new DateOnly(2025, 5, 28), (byte)28, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250529, new DateOnly(2025, 5, 29), (byte)29, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250530, new DateOnly(2025, 5, 30), (byte)30, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250531, new DateOnly(2025, 5, 31), (byte)31, (byte)5, "May", (byte)2, (short)2025 },
                    { 20250601, new DateOnly(2025, 6, 1), (byte)1, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250602, new DateOnly(2025, 6, 2), (byte)2, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250603, new DateOnly(2025, 6, 3), (byte)3, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250604, new DateOnly(2025, 6, 4), (byte)4, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250605, new DateOnly(2025, 6, 5), (byte)5, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250606, new DateOnly(2025, 6, 6), (byte)6, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250607, new DateOnly(2025, 6, 7), (byte)7, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250608, new DateOnly(2025, 6, 8), (byte)8, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250609, new DateOnly(2025, 6, 9), (byte)9, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250610, new DateOnly(2025, 6, 10), (byte)10, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250611, new DateOnly(2025, 6, 11), (byte)11, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250612, new DateOnly(2025, 6, 12), (byte)12, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250613, new DateOnly(2025, 6, 13), (byte)13, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250614, new DateOnly(2025, 6, 14), (byte)14, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250615, new DateOnly(2025, 6, 15), (byte)15, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250616, new DateOnly(2025, 6, 16), (byte)16, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250617, new DateOnly(2025, 6, 17), (byte)17, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250618, new DateOnly(2025, 6, 18), (byte)18, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250619, new DateOnly(2025, 6, 19), (byte)19, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250620, new DateOnly(2025, 6, 20), (byte)20, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250621, new DateOnly(2025, 6, 21), (byte)21, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250622, new DateOnly(2025, 6, 22), (byte)22, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250623, new DateOnly(2025, 6, 23), (byte)23, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250624, new DateOnly(2025, 6, 24), (byte)24, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250625, new DateOnly(2025, 6, 25), (byte)25, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250626, new DateOnly(2025, 6, 26), (byte)26, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250627, new DateOnly(2025, 6, 27), (byte)27, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250628, new DateOnly(2025, 6, 28), (byte)28, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250629, new DateOnly(2025, 6, 29), (byte)29, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250630, new DateOnly(2025, 6, 30), (byte)30, (byte)6, "June", (byte)2, (short)2025 },
                    { 20250701, new DateOnly(2025, 7, 1), (byte)1, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250702, new DateOnly(2025, 7, 2), (byte)2, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250703, new DateOnly(2025, 7, 3), (byte)3, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250704, new DateOnly(2025, 7, 4), (byte)4, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250705, new DateOnly(2025, 7, 5), (byte)5, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250706, new DateOnly(2025, 7, 6), (byte)6, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250707, new DateOnly(2025, 7, 7), (byte)7, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250708, new DateOnly(2025, 7, 8), (byte)8, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250709, new DateOnly(2025, 7, 9), (byte)9, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250710, new DateOnly(2025, 7, 10), (byte)10, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250711, new DateOnly(2025, 7, 11), (byte)11, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250712, new DateOnly(2025, 7, 12), (byte)12, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250713, new DateOnly(2025, 7, 13), (byte)13, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250714, new DateOnly(2025, 7, 14), (byte)14, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250715, new DateOnly(2025, 7, 15), (byte)15, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250716, new DateOnly(2025, 7, 16), (byte)16, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250717, new DateOnly(2025, 7, 17), (byte)17, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250718, new DateOnly(2025, 7, 18), (byte)18, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250719, new DateOnly(2025, 7, 19), (byte)19, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250720, new DateOnly(2025, 7, 20), (byte)20, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250721, new DateOnly(2025, 7, 21), (byte)21, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250722, new DateOnly(2025, 7, 22), (byte)22, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250723, new DateOnly(2025, 7, 23), (byte)23, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250724, new DateOnly(2025, 7, 24), (byte)24, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250725, new DateOnly(2025, 7, 25), (byte)25, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250726, new DateOnly(2025, 7, 26), (byte)26, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250727, new DateOnly(2025, 7, 27), (byte)27, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250728, new DateOnly(2025, 7, 28), (byte)28, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250729, new DateOnly(2025, 7, 29), (byte)29, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250730, new DateOnly(2025, 7, 30), (byte)30, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250731, new DateOnly(2025, 7, 31), (byte)31, (byte)7, "July", (byte)3, (short)2025 },
                    { 20250801, new DateOnly(2025, 8, 1), (byte)1, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250802, new DateOnly(2025, 8, 2), (byte)2, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250803, new DateOnly(2025, 8, 3), (byte)3, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250804, new DateOnly(2025, 8, 4), (byte)4, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250805, new DateOnly(2025, 8, 5), (byte)5, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250806, new DateOnly(2025, 8, 6), (byte)6, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250807, new DateOnly(2025, 8, 7), (byte)7, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250808, new DateOnly(2025, 8, 8), (byte)8, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250809, new DateOnly(2025, 8, 9), (byte)9, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250810, new DateOnly(2025, 8, 10), (byte)10, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250811, new DateOnly(2025, 8, 11), (byte)11, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250812, new DateOnly(2025, 8, 12), (byte)12, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250813, new DateOnly(2025, 8, 13), (byte)13, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250814, new DateOnly(2025, 8, 14), (byte)14, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250815, new DateOnly(2025, 8, 15), (byte)15, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250816, new DateOnly(2025, 8, 16), (byte)16, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250817, new DateOnly(2025, 8, 17), (byte)17, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250818, new DateOnly(2025, 8, 18), (byte)18, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250819, new DateOnly(2025, 8, 19), (byte)19, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250820, new DateOnly(2025, 8, 20), (byte)20, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250821, new DateOnly(2025, 8, 21), (byte)21, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250822, new DateOnly(2025, 8, 22), (byte)22, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250823, new DateOnly(2025, 8, 23), (byte)23, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250824, new DateOnly(2025, 8, 24), (byte)24, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250825, new DateOnly(2025, 8, 25), (byte)25, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250826, new DateOnly(2025, 8, 26), (byte)26, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250827, new DateOnly(2025, 8, 27), (byte)27, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250828, new DateOnly(2025, 8, 28), (byte)28, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250829, new DateOnly(2025, 8, 29), (byte)29, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250830, new DateOnly(2025, 8, 30), (byte)30, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250831, new DateOnly(2025, 8, 31), (byte)31, (byte)8, "August", (byte)3, (short)2025 },
                    { 20250901, new DateOnly(2025, 9, 1), (byte)1, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250902, new DateOnly(2025, 9, 2), (byte)2, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250903, new DateOnly(2025, 9, 3), (byte)3, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250904, new DateOnly(2025, 9, 4), (byte)4, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250905, new DateOnly(2025, 9, 5), (byte)5, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250906, new DateOnly(2025, 9, 6), (byte)6, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250907, new DateOnly(2025, 9, 7), (byte)7, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250908, new DateOnly(2025, 9, 8), (byte)8, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250909, new DateOnly(2025, 9, 9), (byte)9, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250910, new DateOnly(2025, 9, 10), (byte)10, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250911, new DateOnly(2025, 9, 11), (byte)11, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250912, new DateOnly(2025, 9, 12), (byte)12, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250913, new DateOnly(2025, 9, 13), (byte)13, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250914, new DateOnly(2025, 9, 14), (byte)14, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250915, new DateOnly(2025, 9, 15), (byte)15, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250916, new DateOnly(2025, 9, 16), (byte)16, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250917, new DateOnly(2025, 9, 17), (byte)17, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250918, new DateOnly(2025, 9, 18), (byte)18, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250919, new DateOnly(2025, 9, 19), (byte)19, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250920, new DateOnly(2025, 9, 20), (byte)20, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250921, new DateOnly(2025, 9, 21), (byte)21, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250922, new DateOnly(2025, 9, 22), (byte)22, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250923, new DateOnly(2025, 9, 23), (byte)23, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250924, new DateOnly(2025, 9, 24), (byte)24, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250925, new DateOnly(2025, 9, 25), (byte)25, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250926, new DateOnly(2025, 9, 26), (byte)26, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250927, new DateOnly(2025, 9, 27), (byte)27, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250928, new DateOnly(2025, 9, 28), (byte)28, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250929, new DateOnly(2025, 9, 29), (byte)29, (byte)9, "September", (byte)3, (short)2025 },
                    { 20250930, new DateOnly(2025, 9, 30), (byte)30, (byte)9, "September", (byte)3, (short)2025 },
                    { 20251001, new DateOnly(2025, 10, 1), (byte)1, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251002, new DateOnly(2025, 10, 2), (byte)2, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251003, new DateOnly(2025, 10, 3), (byte)3, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251004, new DateOnly(2025, 10, 4), (byte)4, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251005, new DateOnly(2025, 10, 5), (byte)5, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251006, new DateOnly(2025, 10, 6), (byte)6, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251007, new DateOnly(2025, 10, 7), (byte)7, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251008, new DateOnly(2025, 10, 8), (byte)8, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251009, new DateOnly(2025, 10, 9), (byte)9, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251010, new DateOnly(2025, 10, 10), (byte)10, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251011, new DateOnly(2025, 10, 11), (byte)11, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251012, new DateOnly(2025, 10, 12), (byte)12, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251013, new DateOnly(2025, 10, 13), (byte)13, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251014, new DateOnly(2025, 10, 14), (byte)14, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251015, new DateOnly(2025, 10, 15), (byte)15, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251016, new DateOnly(2025, 10, 16), (byte)16, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251017, new DateOnly(2025, 10, 17), (byte)17, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251018, new DateOnly(2025, 10, 18), (byte)18, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251019, new DateOnly(2025, 10, 19), (byte)19, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251020, new DateOnly(2025, 10, 20), (byte)20, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251021, new DateOnly(2025, 10, 21), (byte)21, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251022, new DateOnly(2025, 10, 22), (byte)22, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251023, new DateOnly(2025, 10, 23), (byte)23, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251024, new DateOnly(2025, 10, 24), (byte)24, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251025, new DateOnly(2025, 10, 25), (byte)25, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251026, new DateOnly(2025, 10, 26), (byte)26, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251027, new DateOnly(2025, 10, 27), (byte)27, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251028, new DateOnly(2025, 10, 28), (byte)28, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251029, new DateOnly(2025, 10, 29), (byte)29, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251030, new DateOnly(2025, 10, 30), (byte)30, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251031, new DateOnly(2025, 10, 31), (byte)31, (byte)10, "October", (byte)4, (short)2025 },
                    { 20251101, new DateOnly(2025, 11, 1), (byte)1, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251102, new DateOnly(2025, 11, 2), (byte)2, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251103, new DateOnly(2025, 11, 3), (byte)3, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251104, new DateOnly(2025, 11, 4), (byte)4, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251105, new DateOnly(2025, 11, 5), (byte)5, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251106, new DateOnly(2025, 11, 6), (byte)6, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251107, new DateOnly(2025, 11, 7), (byte)7, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251108, new DateOnly(2025, 11, 8), (byte)8, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251109, new DateOnly(2025, 11, 9), (byte)9, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251110, new DateOnly(2025, 11, 10), (byte)10, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251111, new DateOnly(2025, 11, 11), (byte)11, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251112, new DateOnly(2025, 11, 12), (byte)12, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251113, new DateOnly(2025, 11, 13), (byte)13, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251114, new DateOnly(2025, 11, 14), (byte)14, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251115, new DateOnly(2025, 11, 15), (byte)15, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251116, new DateOnly(2025, 11, 16), (byte)16, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251117, new DateOnly(2025, 11, 17), (byte)17, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251118, new DateOnly(2025, 11, 18), (byte)18, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251119, new DateOnly(2025, 11, 19), (byte)19, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251120, new DateOnly(2025, 11, 20), (byte)20, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251121, new DateOnly(2025, 11, 21), (byte)21, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251122, new DateOnly(2025, 11, 22), (byte)22, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251123, new DateOnly(2025, 11, 23), (byte)23, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251124, new DateOnly(2025, 11, 24), (byte)24, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251125, new DateOnly(2025, 11, 25), (byte)25, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251126, new DateOnly(2025, 11, 26), (byte)26, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251127, new DateOnly(2025, 11, 27), (byte)27, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251128, new DateOnly(2025, 11, 28), (byte)28, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251129, new DateOnly(2025, 11, 29), (byte)29, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251130, new DateOnly(2025, 11, 30), (byte)30, (byte)11, "November", (byte)4, (short)2025 },
                    { 20251201, new DateOnly(2025, 12, 1), (byte)1, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251202, new DateOnly(2025, 12, 2), (byte)2, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251203, new DateOnly(2025, 12, 3), (byte)3, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251204, new DateOnly(2025, 12, 4), (byte)4, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251205, new DateOnly(2025, 12, 5), (byte)5, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251206, new DateOnly(2025, 12, 6), (byte)6, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251207, new DateOnly(2025, 12, 7), (byte)7, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251208, new DateOnly(2025, 12, 8), (byte)8, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251209, new DateOnly(2025, 12, 9), (byte)9, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251210, new DateOnly(2025, 12, 10), (byte)10, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251211, new DateOnly(2025, 12, 11), (byte)11, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251212, new DateOnly(2025, 12, 12), (byte)12, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251213, new DateOnly(2025, 12, 13), (byte)13, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251214, new DateOnly(2025, 12, 14), (byte)14, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251215, new DateOnly(2025, 12, 15), (byte)15, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251216, new DateOnly(2025, 12, 16), (byte)16, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251217, new DateOnly(2025, 12, 17), (byte)17, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251218, new DateOnly(2025, 12, 18), (byte)18, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251219, new DateOnly(2025, 12, 19), (byte)19, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251220, new DateOnly(2025, 12, 20), (byte)20, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251221, new DateOnly(2025, 12, 21), (byte)21, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251222, new DateOnly(2025, 12, 22), (byte)22, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251223, new DateOnly(2025, 12, 23), (byte)23, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251224, new DateOnly(2025, 12, 24), (byte)24, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251225, new DateOnly(2025, 12, 25), (byte)25, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251226, new DateOnly(2025, 12, 26), (byte)26, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251227, new DateOnly(2025, 12, 27), (byte)27, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251228, new DateOnly(2025, 12, 28), (byte)28, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251229, new DateOnly(2025, 12, 29), (byte)29, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251230, new DateOnly(2025, 12, 30), (byte)30, (byte)12, "December", (byte)4, (short)2025 },
                    { 20251231, new DateOnly(2025, 12, 31), (byte)31, (byte)12, "December", (byte)4, (short)2025 },
                    { 20260101, new DateOnly(2026, 1, 1), (byte)1, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260102, new DateOnly(2026, 1, 2), (byte)2, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260103, new DateOnly(2026, 1, 3), (byte)3, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260104, new DateOnly(2026, 1, 4), (byte)4, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260106, new DateOnly(2026, 1, 6), (byte)6, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260107, new DateOnly(2026, 1, 7), (byte)7, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260108, new DateOnly(2026, 1, 8), (byte)8, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260110, new DateOnly(2026, 1, 10), (byte)10, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260111, new DateOnly(2026, 1, 11), (byte)11, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260112, new DateOnly(2026, 1, 12), (byte)12, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260114, new DateOnly(2026, 1, 14), (byte)14, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260115, new DateOnly(2026, 1, 15), (byte)15, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260116, new DateOnly(2026, 1, 16), (byte)16, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260118, new DateOnly(2026, 1, 18), (byte)18, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260119, new DateOnly(2026, 1, 19), (byte)19, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260120, new DateOnly(2026, 1, 20), (byte)20, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260122, new DateOnly(2026, 1, 22), (byte)22, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260123, new DateOnly(2026, 1, 23), (byte)23, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260124, new DateOnly(2026, 1, 24), (byte)24, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260126, new DateOnly(2026, 1, 26), (byte)26, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260127, new DateOnly(2026, 1, 27), (byte)27, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260128, new DateOnly(2026, 1, 28), (byte)28, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260130, new DateOnly(2026, 1, 30), (byte)30, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260131, new DateOnly(2026, 1, 31), (byte)31, (byte)1, "January", (byte)1, (short)2026 },
                    { 20260201, new DateOnly(2026, 2, 1), (byte)1, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260203, new DateOnly(2026, 2, 3), (byte)3, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260204, new DateOnly(2026, 2, 4), (byte)4, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260205, new DateOnly(2026, 2, 5), (byte)5, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260207, new DateOnly(2026, 2, 7), (byte)7, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260208, new DateOnly(2026, 2, 8), (byte)8, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260209, new DateOnly(2026, 2, 9), (byte)9, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260211, new DateOnly(2026, 2, 11), (byte)11, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260212, new DateOnly(2026, 2, 12), (byte)12, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260213, new DateOnly(2026, 2, 13), (byte)13, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260215, new DateOnly(2026, 2, 15), (byte)15, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260216, new DateOnly(2026, 2, 16), (byte)16, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260217, new DateOnly(2026, 2, 17), (byte)17, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260219, new DateOnly(2026, 2, 19), (byte)19, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260220, new DateOnly(2026, 2, 20), (byte)20, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260221, new DateOnly(2026, 2, 21), (byte)21, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260223, new DateOnly(2026, 2, 23), (byte)23, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260224, new DateOnly(2026, 2, 24), (byte)24, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260225, new DateOnly(2026, 2, 25), (byte)25, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260227, new DateOnly(2026, 2, 27), (byte)27, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260228, new DateOnly(2026, 2, 28), (byte)28, (byte)2, "February", (byte)1, (short)2026 },
                    { 20260301, new DateOnly(2026, 3, 1), (byte)1, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260303, new DateOnly(2026, 3, 3), (byte)3, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260304, new DateOnly(2026, 3, 4), (byte)4, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260305, new DateOnly(2026, 3, 5), (byte)5, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260307, new DateOnly(2026, 3, 7), (byte)7, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260308, new DateOnly(2026, 3, 8), (byte)8, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260309, new DateOnly(2026, 3, 9), (byte)9, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260311, new DateOnly(2026, 3, 11), (byte)11, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260312, new DateOnly(2026, 3, 12), (byte)12, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260313, new DateOnly(2026, 3, 13), (byte)13, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260315, new DateOnly(2026, 3, 15), (byte)15, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260316, new DateOnly(2026, 3, 16), (byte)16, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260317, new DateOnly(2026, 3, 17), (byte)17, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260319, new DateOnly(2026, 3, 19), (byte)19, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260320, new DateOnly(2026, 3, 20), (byte)20, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260321, new DateOnly(2026, 3, 21), (byte)21, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260323, new DateOnly(2026, 3, 23), (byte)23, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260324, new DateOnly(2026, 3, 24), (byte)24, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260325, new DateOnly(2026, 3, 25), (byte)25, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260326, new DateOnly(2026, 3, 26), (byte)26, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260327, new DateOnly(2026, 3, 27), (byte)27, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260328, new DateOnly(2026, 3, 28), (byte)28, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260329, new DateOnly(2026, 3, 29), (byte)29, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260330, new DateOnly(2026, 3, 30), (byte)30, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260331, new DateOnly(2026, 3, 31), (byte)31, (byte)3, "March", (byte)1, (short)2026 },
                    { 20260401, new DateOnly(2026, 4, 1), (byte)1, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260402, new DateOnly(2026, 4, 2), (byte)2, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260403, new DateOnly(2026, 4, 3), (byte)3, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260404, new DateOnly(2026, 4, 4), (byte)4, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260405, new DateOnly(2026, 4, 5), (byte)5, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260406, new DateOnly(2026, 4, 6), (byte)6, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260407, new DateOnly(2026, 4, 7), (byte)7, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260408, new DateOnly(2026, 4, 8), (byte)8, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260409, new DateOnly(2026, 4, 9), (byte)9, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260410, new DateOnly(2026, 4, 10), (byte)10, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260411, new DateOnly(2026, 4, 11), (byte)11, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260412, new DateOnly(2026, 4, 12), (byte)12, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260413, new DateOnly(2026, 4, 13), (byte)13, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260414, new DateOnly(2026, 4, 14), (byte)14, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260415, new DateOnly(2026, 4, 15), (byte)15, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260416, new DateOnly(2026, 4, 16), (byte)16, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260417, new DateOnly(2026, 4, 17), (byte)17, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260418, new DateOnly(2026, 4, 18), (byte)18, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260419, new DateOnly(2026, 4, 19), (byte)19, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260420, new DateOnly(2026, 4, 20), (byte)20, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260421, new DateOnly(2026, 4, 21), (byte)21, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260422, new DateOnly(2026, 4, 22), (byte)22, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260423, new DateOnly(2026, 4, 23), (byte)23, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260424, new DateOnly(2026, 4, 24), (byte)24, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260425, new DateOnly(2026, 4, 25), (byte)25, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260426, new DateOnly(2026, 4, 26), (byte)26, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260427, new DateOnly(2026, 4, 27), (byte)27, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260428, new DateOnly(2026, 4, 28), (byte)28, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260429, new DateOnly(2026, 4, 29), (byte)29, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260430, new DateOnly(2026, 4, 30), (byte)30, (byte)4, "April", (byte)2, (short)2026 },
                    { 20260501, new DateOnly(2026, 5, 1), (byte)1, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260502, new DateOnly(2026, 5, 2), (byte)2, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260503, new DateOnly(2026, 5, 3), (byte)3, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260504, new DateOnly(2026, 5, 4), (byte)4, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260505, new DateOnly(2026, 5, 5), (byte)5, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260506, new DateOnly(2026, 5, 6), (byte)6, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260507, new DateOnly(2026, 5, 7), (byte)7, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260508, new DateOnly(2026, 5, 8), (byte)8, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260509, new DateOnly(2026, 5, 9), (byte)9, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260510, new DateOnly(2026, 5, 10), (byte)10, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260511, new DateOnly(2026, 5, 11), (byte)11, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260512, new DateOnly(2026, 5, 12), (byte)12, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260513, new DateOnly(2026, 5, 13), (byte)13, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260514, new DateOnly(2026, 5, 14), (byte)14, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260515, new DateOnly(2026, 5, 15), (byte)15, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260516, new DateOnly(2026, 5, 16), (byte)16, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260517, new DateOnly(2026, 5, 17), (byte)17, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260518, new DateOnly(2026, 5, 18), (byte)18, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260519, new DateOnly(2026, 5, 19), (byte)19, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260520, new DateOnly(2026, 5, 20), (byte)20, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260521, new DateOnly(2026, 5, 21), (byte)21, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260522, new DateOnly(2026, 5, 22), (byte)22, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260523, new DateOnly(2026, 5, 23), (byte)23, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260524, new DateOnly(2026, 5, 24), (byte)24, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260525, new DateOnly(2026, 5, 25), (byte)25, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260526, new DateOnly(2026, 5, 26), (byte)26, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260527, new DateOnly(2026, 5, 27), (byte)27, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260528, new DateOnly(2026, 5, 28), (byte)28, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260529, new DateOnly(2026, 5, 29), (byte)29, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260530, new DateOnly(2026, 5, 30), (byte)30, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260531, new DateOnly(2026, 5, 31), (byte)31, (byte)5, "May", (byte)2, (short)2026 },
                    { 20260601, new DateOnly(2026, 6, 1), (byte)1, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260602, new DateOnly(2026, 6, 2), (byte)2, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260603, new DateOnly(2026, 6, 3), (byte)3, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260604, new DateOnly(2026, 6, 4), (byte)4, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260605, new DateOnly(2026, 6, 5), (byte)5, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260606, new DateOnly(2026, 6, 6), (byte)6, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260607, new DateOnly(2026, 6, 7), (byte)7, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260608, new DateOnly(2026, 6, 8), (byte)8, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260609, new DateOnly(2026, 6, 9), (byte)9, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260610, new DateOnly(2026, 6, 10), (byte)10, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260611, new DateOnly(2026, 6, 11), (byte)11, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260612, new DateOnly(2026, 6, 12), (byte)12, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260613, new DateOnly(2026, 6, 13), (byte)13, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260614, new DateOnly(2026, 6, 14), (byte)14, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260615, new DateOnly(2026, 6, 15), (byte)15, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260616, new DateOnly(2026, 6, 16), (byte)16, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260617, new DateOnly(2026, 6, 17), (byte)17, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260618, new DateOnly(2026, 6, 18), (byte)18, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260619, new DateOnly(2026, 6, 19), (byte)19, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260620, new DateOnly(2026, 6, 20), (byte)20, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260621, new DateOnly(2026, 6, 21), (byte)21, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260622, new DateOnly(2026, 6, 22), (byte)22, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260623, new DateOnly(2026, 6, 23), (byte)23, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260624, new DateOnly(2026, 6, 24), (byte)24, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260625, new DateOnly(2026, 6, 25), (byte)25, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260626, new DateOnly(2026, 6, 26), (byte)26, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260627, new DateOnly(2026, 6, 27), (byte)27, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260628, new DateOnly(2026, 6, 28), (byte)28, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260629, new DateOnly(2026, 6, 29), (byte)29, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260630, new DateOnly(2026, 6, 30), (byte)30, (byte)6, "June", (byte)2, (short)2026 },
                    { 20260701, new DateOnly(2026, 7, 1), (byte)1, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260702, new DateOnly(2026, 7, 2), (byte)2, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260703, new DateOnly(2026, 7, 3), (byte)3, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260704, new DateOnly(2026, 7, 4), (byte)4, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260705, new DateOnly(2026, 7, 5), (byte)5, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260706, new DateOnly(2026, 7, 6), (byte)6, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260707, new DateOnly(2026, 7, 7), (byte)7, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260708, new DateOnly(2026, 7, 8), (byte)8, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260709, new DateOnly(2026, 7, 9), (byte)9, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260710, new DateOnly(2026, 7, 10), (byte)10, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260711, new DateOnly(2026, 7, 11), (byte)11, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260712, new DateOnly(2026, 7, 12), (byte)12, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260713, new DateOnly(2026, 7, 13), (byte)13, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260714, new DateOnly(2026, 7, 14), (byte)14, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260715, new DateOnly(2026, 7, 15), (byte)15, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260716, new DateOnly(2026, 7, 16), (byte)16, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260717, new DateOnly(2026, 7, 17), (byte)17, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260718, new DateOnly(2026, 7, 18), (byte)18, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260719, new DateOnly(2026, 7, 19), (byte)19, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260720, new DateOnly(2026, 7, 20), (byte)20, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260721, new DateOnly(2026, 7, 21), (byte)21, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260722, new DateOnly(2026, 7, 22), (byte)22, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260723, new DateOnly(2026, 7, 23), (byte)23, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260724, new DateOnly(2026, 7, 24), (byte)24, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260725, new DateOnly(2026, 7, 25), (byte)25, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260726, new DateOnly(2026, 7, 26), (byte)26, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260727, new DateOnly(2026, 7, 27), (byte)27, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260728, new DateOnly(2026, 7, 28), (byte)28, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260729, new DateOnly(2026, 7, 29), (byte)29, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260730, new DateOnly(2026, 7, 30), (byte)30, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260731, new DateOnly(2026, 7, 31), (byte)31, (byte)7, "July", (byte)3, (short)2026 },
                    { 20260801, new DateOnly(2026, 8, 1), (byte)1, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260802, new DateOnly(2026, 8, 2), (byte)2, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260803, new DateOnly(2026, 8, 3), (byte)3, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260804, new DateOnly(2026, 8, 4), (byte)4, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260805, new DateOnly(2026, 8, 5), (byte)5, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260806, new DateOnly(2026, 8, 6), (byte)6, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260807, new DateOnly(2026, 8, 7), (byte)7, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260808, new DateOnly(2026, 8, 8), (byte)8, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260809, new DateOnly(2026, 8, 9), (byte)9, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260810, new DateOnly(2026, 8, 10), (byte)10, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260811, new DateOnly(2026, 8, 11), (byte)11, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260812, new DateOnly(2026, 8, 12), (byte)12, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260813, new DateOnly(2026, 8, 13), (byte)13, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260814, new DateOnly(2026, 8, 14), (byte)14, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260815, new DateOnly(2026, 8, 15), (byte)15, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260816, new DateOnly(2026, 8, 16), (byte)16, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260817, new DateOnly(2026, 8, 17), (byte)17, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260818, new DateOnly(2026, 8, 18), (byte)18, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260819, new DateOnly(2026, 8, 19), (byte)19, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260820, new DateOnly(2026, 8, 20), (byte)20, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260821, new DateOnly(2026, 8, 21), (byte)21, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260822, new DateOnly(2026, 8, 22), (byte)22, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260823, new DateOnly(2026, 8, 23), (byte)23, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260824, new DateOnly(2026, 8, 24), (byte)24, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260825, new DateOnly(2026, 8, 25), (byte)25, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260826, new DateOnly(2026, 8, 26), (byte)26, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260827, new DateOnly(2026, 8, 27), (byte)27, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260828, new DateOnly(2026, 8, 28), (byte)28, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260829, new DateOnly(2026, 8, 29), (byte)29, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260830, new DateOnly(2026, 8, 30), (byte)30, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260831, new DateOnly(2026, 8, 31), (byte)31, (byte)8, "August", (byte)3, (short)2026 },
                    { 20260901, new DateOnly(2026, 9, 1), (byte)1, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260902, new DateOnly(2026, 9, 2), (byte)2, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260903, new DateOnly(2026, 9, 3), (byte)3, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260904, new DateOnly(2026, 9, 4), (byte)4, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260905, new DateOnly(2026, 9, 5), (byte)5, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260906, new DateOnly(2026, 9, 6), (byte)6, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260907, new DateOnly(2026, 9, 7), (byte)7, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260908, new DateOnly(2026, 9, 8), (byte)8, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260909, new DateOnly(2026, 9, 9), (byte)9, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260910, new DateOnly(2026, 9, 10), (byte)10, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260911, new DateOnly(2026, 9, 11), (byte)11, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260912, new DateOnly(2026, 9, 12), (byte)12, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260913, new DateOnly(2026, 9, 13), (byte)13, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260914, new DateOnly(2026, 9, 14), (byte)14, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260915, new DateOnly(2026, 9, 15), (byte)15, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260916, new DateOnly(2026, 9, 16), (byte)16, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260917, new DateOnly(2026, 9, 17), (byte)17, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260918, new DateOnly(2026, 9, 18), (byte)18, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260919, new DateOnly(2026, 9, 19), (byte)19, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260920, new DateOnly(2026, 9, 20), (byte)20, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260921, new DateOnly(2026, 9, 21), (byte)21, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260922, new DateOnly(2026, 9, 22), (byte)22, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260923, new DateOnly(2026, 9, 23), (byte)23, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260924, new DateOnly(2026, 9, 24), (byte)24, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260925, new DateOnly(2026, 9, 25), (byte)25, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260926, new DateOnly(2026, 9, 26), (byte)26, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260927, new DateOnly(2026, 9, 27), (byte)27, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260928, new DateOnly(2026, 9, 28), (byte)28, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260929, new DateOnly(2026, 9, 29), (byte)29, (byte)9, "September", (byte)3, (short)2026 },
                    { 20260930, new DateOnly(2026, 9, 30), (byte)30, (byte)9, "September", (byte)3, (short)2026 },
                    { 20261001, new DateOnly(2026, 10, 1), (byte)1, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261002, new DateOnly(2026, 10, 2), (byte)2, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261003, new DateOnly(2026, 10, 3), (byte)3, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261004, new DateOnly(2026, 10, 4), (byte)4, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261005, new DateOnly(2026, 10, 5), (byte)5, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261006, new DateOnly(2026, 10, 6), (byte)6, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261007, new DateOnly(2026, 10, 7), (byte)7, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261008, new DateOnly(2026, 10, 8), (byte)8, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261009, new DateOnly(2026, 10, 9), (byte)9, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261010, new DateOnly(2026, 10, 10), (byte)10, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261011, new DateOnly(2026, 10, 11), (byte)11, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261012, new DateOnly(2026, 10, 12), (byte)12, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261013, new DateOnly(2026, 10, 13), (byte)13, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261014, new DateOnly(2026, 10, 14), (byte)14, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261015, new DateOnly(2026, 10, 15), (byte)15, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261016, new DateOnly(2026, 10, 16), (byte)16, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261017, new DateOnly(2026, 10, 17), (byte)17, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261018, new DateOnly(2026, 10, 18), (byte)18, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261019, new DateOnly(2026, 10, 19), (byte)19, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261020, new DateOnly(2026, 10, 20), (byte)20, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261021, new DateOnly(2026, 10, 21), (byte)21, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261022, new DateOnly(2026, 10, 22), (byte)22, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261023, new DateOnly(2026, 10, 23), (byte)23, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261024, new DateOnly(2026, 10, 24), (byte)24, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261025, new DateOnly(2026, 10, 25), (byte)25, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261026, new DateOnly(2026, 10, 26), (byte)26, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261027, new DateOnly(2026, 10, 27), (byte)27, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261028, new DateOnly(2026, 10, 28), (byte)28, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261029, new DateOnly(2026, 10, 29), (byte)29, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261030, new DateOnly(2026, 10, 30), (byte)30, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261031, new DateOnly(2026, 10, 31), (byte)31, (byte)10, "October", (byte)4, (short)2026 },
                    { 20261101, new DateOnly(2026, 11, 1), (byte)1, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261102, new DateOnly(2026, 11, 2), (byte)2, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261103, new DateOnly(2026, 11, 3), (byte)3, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261104, new DateOnly(2026, 11, 4), (byte)4, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261105, new DateOnly(2026, 11, 5), (byte)5, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261106, new DateOnly(2026, 11, 6), (byte)6, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261107, new DateOnly(2026, 11, 7), (byte)7, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261108, new DateOnly(2026, 11, 8), (byte)8, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261109, new DateOnly(2026, 11, 9), (byte)9, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261110, new DateOnly(2026, 11, 10), (byte)10, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261111, new DateOnly(2026, 11, 11), (byte)11, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261112, new DateOnly(2026, 11, 12), (byte)12, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261113, new DateOnly(2026, 11, 13), (byte)13, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261114, new DateOnly(2026, 11, 14), (byte)14, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261115, new DateOnly(2026, 11, 15), (byte)15, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261116, new DateOnly(2026, 11, 16), (byte)16, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261117, new DateOnly(2026, 11, 17), (byte)17, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261118, new DateOnly(2026, 11, 18), (byte)18, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261119, new DateOnly(2026, 11, 19), (byte)19, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261120, new DateOnly(2026, 11, 20), (byte)20, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261121, new DateOnly(2026, 11, 21), (byte)21, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261122, new DateOnly(2026, 11, 22), (byte)22, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261123, new DateOnly(2026, 11, 23), (byte)23, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261124, new DateOnly(2026, 11, 24), (byte)24, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261125, new DateOnly(2026, 11, 25), (byte)25, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261126, new DateOnly(2026, 11, 26), (byte)26, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261127, new DateOnly(2026, 11, 27), (byte)27, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261128, new DateOnly(2026, 11, 28), (byte)28, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261129, new DateOnly(2026, 11, 29), (byte)29, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261130, new DateOnly(2026, 11, 30), (byte)30, (byte)11, "November", (byte)4, (short)2026 },
                    { 20261201, new DateOnly(2026, 12, 1), (byte)1, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261202, new DateOnly(2026, 12, 2), (byte)2, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261203, new DateOnly(2026, 12, 3), (byte)3, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261204, new DateOnly(2026, 12, 4), (byte)4, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261205, new DateOnly(2026, 12, 5), (byte)5, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261206, new DateOnly(2026, 12, 6), (byte)6, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261207, new DateOnly(2026, 12, 7), (byte)7, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261208, new DateOnly(2026, 12, 8), (byte)8, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261209, new DateOnly(2026, 12, 9), (byte)9, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261210, new DateOnly(2026, 12, 10), (byte)10, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261211, new DateOnly(2026, 12, 11), (byte)11, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261212, new DateOnly(2026, 12, 12), (byte)12, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261213, new DateOnly(2026, 12, 13), (byte)13, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261214, new DateOnly(2026, 12, 14), (byte)14, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261215, new DateOnly(2026, 12, 15), (byte)15, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261216, new DateOnly(2026, 12, 16), (byte)16, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261217, new DateOnly(2026, 12, 17), (byte)17, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261218, new DateOnly(2026, 12, 18), (byte)18, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261219, new DateOnly(2026, 12, 19), (byte)19, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261220, new DateOnly(2026, 12, 20), (byte)20, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261221, new DateOnly(2026, 12, 21), (byte)21, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261222, new DateOnly(2026, 12, 22), (byte)22, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261223, new DateOnly(2026, 12, 23), (byte)23, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261224, new DateOnly(2026, 12, 24), (byte)24, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261225, new DateOnly(2026, 12, 25), (byte)25, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261226, new DateOnly(2026, 12, 26), (byte)26, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261227, new DateOnly(2026, 12, 27), (byte)27, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261228, new DateOnly(2026, 12, 28), (byte)28, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261229, new DateOnly(2026, 12, 29), (byte)29, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261230, new DateOnly(2026, 12, 30), (byte)30, (byte)12, "December", (byte)4, (short)2026 },
                    { 20261231, new DateOnly(2026, 12, 31), (byte)31, (byte)12, "December", (byte)4, (short)2026 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250101);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250102);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250103);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250104);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250105);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250106);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250107);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250108);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250109);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250110);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250111);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250112);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250113);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250114);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250115);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250116);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250117);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250118);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250119);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250120);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250121);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250122);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250123);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250124);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250125);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250126);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250127);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250128);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250129);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250130);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250131);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250201);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250202);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250203);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250204);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250205);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250206);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250207);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250208);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250209);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250210);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250211);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250212);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250213);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250214);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250215);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250216);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250217);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250218);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250219);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250220);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250221);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250222);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250223);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250224);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250225);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250226);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250227);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250228);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250301);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250302);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250303);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250304);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250305);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250306);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250307);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250308);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250309);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250310);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250311);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250312);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250313);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250314);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250315);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250316);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250317);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250318);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250319);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250320);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250321);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250322);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250323);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250324);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250325);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250326);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250327);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250328);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250329);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250330);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250331);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250401);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250402);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250403);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250404);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250405);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250406);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250407);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250408);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250409);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250410);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250411);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250412);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250413);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250414);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250415);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250416);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250417);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250418);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250419);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250420);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250421);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250422);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250423);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250424);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250425);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250426);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250427);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250428);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250429);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250430);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250501);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250502);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250503);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250504);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250505);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250506);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250507);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250508);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250509);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250510);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250511);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250512);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250513);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250514);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250515);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250516);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250517);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250518);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250519);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250520);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250521);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250522);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250523);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250524);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250525);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250526);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250527);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250528);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250529);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250530);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250531);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250601);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250602);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250603);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250604);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250605);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250606);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250607);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250608);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250609);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250610);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250611);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250612);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250613);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250614);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250615);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250616);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250617);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250618);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250619);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250620);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250621);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250622);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250623);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250624);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250625);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250626);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250627);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250628);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250629);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250630);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250701);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250702);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250703);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250704);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250705);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250706);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250707);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250708);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250709);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250710);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250711);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250712);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250713);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250714);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250715);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250716);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250717);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250718);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250719);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250720);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250721);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250722);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250723);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250724);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250725);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250726);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250727);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250728);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250729);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250730);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250731);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250801);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250802);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250803);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250804);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250805);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250806);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250807);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250808);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250809);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250810);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250811);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250812);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250813);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250814);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250815);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250816);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250817);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250818);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250819);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250820);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250821);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250822);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250823);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250824);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250825);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250826);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250827);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250828);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250829);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250830);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250831);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250901);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250902);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250903);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250904);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250905);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250906);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250907);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250908);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250909);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250910);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250911);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250912);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250913);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250914);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250915);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250916);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250917);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250918);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250919);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250920);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250921);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250922);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250923);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250924);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250925);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250926);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250927);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250928);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250929);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20250930);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251001);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251002);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251003);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251004);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251005);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251006);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251007);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251008);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251009);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251010);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251011);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251012);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251013);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251014);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251015);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251016);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251017);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251018);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251019);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251020);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251021);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251022);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251023);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251024);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251025);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251026);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251027);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251028);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251029);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251030);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251031);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251101);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251102);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251103);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251104);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251105);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251106);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251107);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251108);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251109);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251110);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251111);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251112);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251113);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251114);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251115);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251116);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251117);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251118);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251119);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251120);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251121);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251122);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251123);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251124);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251125);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251126);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251127);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251128);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251129);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251130);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251201);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251202);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251203);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251204);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251205);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251206);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251207);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251208);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251209);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251210);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251211);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251212);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251213);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251214);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251215);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251216);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251217);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251218);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251219);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251220);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251221);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251222);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251223);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251224);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251225);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251226);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251227);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251228);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251229);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251230);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20251231);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260101);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260102);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260103);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260104);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260106);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260107);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260108);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260110);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260111);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260112);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260114);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260115);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260116);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260118);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260119);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260120);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260122);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260123);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260124);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260126);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260127);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260128);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260130);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260131);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260201);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260203);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260204);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260205);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260207);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260208);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260209);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260211);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260212);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260213);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260215);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260216);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260217);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260219);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260220);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260221);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260223);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260224);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260225);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260227);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260228);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260301);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260303);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260304);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260305);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260307);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260308);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260309);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260311);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260312);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260313);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260315);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260316);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260317);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260319);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260320);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260321);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260323);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260324);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260325);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260326);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260327);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260328);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260329);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260330);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260331);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260401);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260402);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260403);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260404);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260405);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260406);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260407);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260408);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260409);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260410);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260411);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260412);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260413);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260414);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260415);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260416);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260417);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260418);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260419);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260420);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260421);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260422);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260423);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260424);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260425);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260426);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260427);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260428);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260429);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260430);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260501);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260502);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260503);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260504);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260505);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260506);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260507);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260508);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260509);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260510);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260511);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260512);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260513);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260514);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260515);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260516);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260517);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260518);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260519);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260520);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260521);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260522);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260523);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260524);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260525);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260526);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260527);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260528);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260529);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260530);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260531);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260601);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260602);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260603);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260604);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260605);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260606);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260607);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260608);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260609);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260610);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260611);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260612);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260613);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260614);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260615);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260616);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260617);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260618);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260619);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260620);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260621);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260622);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260623);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260624);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260625);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260626);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260627);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260628);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260629);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260630);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260701);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260702);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260703);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260704);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260705);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260706);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260707);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260708);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260709);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260710);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260711);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260712);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260713);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260714);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260715);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260716);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260717);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260718);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260719);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260720);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260721);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260722);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260723);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260724);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260725);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260726);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260727);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260728);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260729);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260730);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260731);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260801);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260802);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260803);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260804);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260805);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260806);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260807);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260808);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260809);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260810);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260811);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260812);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260813);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260814);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260815);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260816);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260817);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260818);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260819);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260820);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260821);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260822);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260823);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260824);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260825);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260826);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260827);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260828);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260829);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260830);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260831);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260901);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260902);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260903);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260904);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260905);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260906);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260907);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260908);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260909);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260910);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260911);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260912);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260913);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260914);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260915);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260916);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260917);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260918);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260919);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260920);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260921);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260922);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260923);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260924);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260925);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260926);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260927);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260928);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260929);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20260930);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261001);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261002);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261003);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261004);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261005);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261006);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261007);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261008);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261009);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261010);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261011);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261012);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261013);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261014);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261015);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261016);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261017);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261018);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261019);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261020);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261021);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261022);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261023);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261024);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261025);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261026);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261027);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261028);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261029);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261030);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261031);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261101);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261102);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261103);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261104);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261105);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261106);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261107);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261108);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261109);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261110);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261111);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261112);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261113);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261114);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261115);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261116);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261117);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261118);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261119);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261120);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261121);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261122);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261123);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261124);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261125);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261126);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261127);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261128);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261129);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261130);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261201);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261202);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261203);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261204);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261205);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261206);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261207);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261208);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261209);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261210);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261211);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261212);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261213);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261214);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261215);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261216);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261217);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261218);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261219);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261220);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261221);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261222);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261223);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261224);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261225);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261226);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261227);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261228);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261229);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261230);

            migrationBuilder.DeleteData(
                table: "DimDate",
                keyColumn: "DateKey",
                keyValue: 20261231);
        }
    }
}
