using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyWave.Migrations
{
    public partial class ResponseInfoCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Response");

            migrationBuilder.AddColumn<int>(
                name: "ResponseInfoId",
                table: "Response",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ResponseInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Response_ResponseInfoId",
                table: "Response",
                column: "ResponseInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Response_ResponseInfo_ResponseInfoId",
                table: "Response",
                column: "ResponseInfoId",
                principalTable: "ResponseInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_ResponseInfo_ResponseInfoId",
                table: "Response");

            migrationBuilder.DropTable(
                name: "ResponseInfo");

            migrationBuilder.DropIndex(
                name: "IX_Response_ResponseInfoId",
                table: "Response");

            migrationBuilder.DropColumn(
                name: "ResponseInfoId",
                table: "Response");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Response",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Response",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
