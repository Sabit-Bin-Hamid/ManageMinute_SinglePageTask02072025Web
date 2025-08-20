using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Single_Page_Task_02072025.Migrations
{
    /// <inheritdoc />
    public partial class _20_v1_aug1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Minutes_Detail_Tbl_Meeting_Minutes_Master_Tbl_MeetingMinuteId",
                table: "Meeting_Minutes_Detail_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Minutes_Detail_Tbl_Products_Service_Tbl_ProductServiceId",
                table: "Meeting_Minutes_Detail_Tbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meeting_Minutes_Detail_Tbl",
                table: "Meeting_Minutes_Detail_Tbl");

            migrationBuilder.RenameTable(
                name: "Meeting_Minutes_Detail_Tbl",
                newName: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.RenameIndex(
                name: "IX_Meeting_Minutes_Detail_Tbl_ProductServiceId",
                table: "Meeting_Minutes_Details_Tbl",
                newName: "IX_Meeting_Minutes_Details_Tbl_ProductServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Meeting_Minutes_Detail_Tbl_MeetingMinuteId",
                table: "Meeting_Minutes_Details_Tbl",
                newName: "IX_Meeting_Minutes_Details_Tbl_MeetingMinuteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meeting_Minutes_Details_Tbl",
                table: "Meeting_Minutes_Details_Tbl",
                column: "MeetingMinuteDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Minutes_Details_Tbl_Meeting_Minutes_Master_Tbl_MeetingMinuteId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "MeetingMinuteId",
                principalTable: "Meeting_Minutes_Master_Tbl",
                principalColumn: "MeetingMinuteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Minutes_Details_Tbl_Products_Service_Tbl_ProductServiceId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "ProductServiceId",
                principalTable: "Products_Service_Tbl",
                principalColumn: "ProductServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Minutes_Details_Tbl_Meeting_Minutes_Master_Tbl_MeetingMinuteId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Minutes_Details_Tbl_Products_Service_Tbl_ProductServiceId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meeting_Minutes_Details_Tbl",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.RenameTable(
                name: "Meeting_Minutes_Details_Tbl",
                newName: "Meeting_Minutes_Detail_Tbl");

            migrationBuilder.RenameIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_ProductServiceId",
                table: "Meeting_Minutes_Detail_Tbl",
                newName: "IX_Meeting_Minutes_Detail_Tbl_ProductServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_MeetingMinuteId",
                table: "Meeting_Minutes_Detail_Tbl",
                newName: "IX_Meeting_Minutes_Detail_Tbl_MeetingMinuteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meeting_Minutes_Detail_Tbl",
                table: "Meeting_Minutes_Detail_Tbl",
                column: "MeetingMinuteDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Minutes_Detail_Tbl_Meeting_Minutes_Master_Tbl_MeetingMinuteId",
                table: "Meeting_Minutes_Detail_Tbl",
                column: "MeetingMinuteId",
                principalTable: "Meeting_Minutes_Master_Tbl",
                principalColumn: "MeetingMinuteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Minutes_Detail_Tbl_Products_Service_Tbl_ProductServiceId",
                table: "Meeting_Minutes_Detail_Tbl",
                column: "ProductServiceId",
                principalTable: "Products_Service_Tbl",
                principalColumn: "ProductServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
