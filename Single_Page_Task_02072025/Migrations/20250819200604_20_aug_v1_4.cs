using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Single_Page_Task_02072025.Migrations
{
    /// <inheritdoc />
    public partial class _20_aug_v1_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "MeetingTime",
                table: "Meeting_Minutes_Master_Tbl",
                type: "time",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MeetingTime",
                table: "Meeting_Minutes_Master_Tbl",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);
        }
    }
}
