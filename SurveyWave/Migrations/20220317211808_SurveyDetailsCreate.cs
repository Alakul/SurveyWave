using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NETcoreSurveyApp.Migrations
{
    public partial class SurveyDetailsCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyId = table.Column<int>(nullable: false),
                    QuestionNumber = table.Column<int>(nullable: false),
                    AnswerNumber = table.Column<int>(nullable: false),
                    Answer = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyDetails_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyDetails_SurveyId",
                table: "SurveyDetails",
                column: "SurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyDetails");
        }
    }
}
