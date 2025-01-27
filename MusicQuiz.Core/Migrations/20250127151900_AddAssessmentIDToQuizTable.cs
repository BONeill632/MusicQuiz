using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicQuiz.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddAssessmentIDToQuizTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssessmentId",
                table: "UsersPracticeQuizResults",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersPracticeQuizResults_AssessmentId",
                table: "UsersPracticeQuizResults",
                column: "AssessmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersPracticeQuizResults_Assessments_AssessmentId",
                table: "UsersPracticeQuizResults",
                column: "AssessmentId",
                principalTable: "Assessments",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersPracticeQuizResults_Assessments_AssessmentId",
                table: "UsersPracticeQuizResults");

            migrationBuilder.DropIndex(
                name: "IX_UsersPracticeQuizResults_AssessmentId",
                table: "UsersPracticeQuizResults");

            migrationBuilder.DropColumn(
                name: "AssessmentId",
                table: "UsersPracticeQuizResults");
        }
    }
}
