using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyWave.Migrations
{
    public partial class AnswerDetailsCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<int>(nullable: false),
                    QuestionNumber = table.Column<int>(nullable: false),
                    AnswerNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerDetails_Answer_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerDetails_AnswerId",
                table: "AnswerDetails",
                column: "AnswerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerDetails");
        }
    }
}
