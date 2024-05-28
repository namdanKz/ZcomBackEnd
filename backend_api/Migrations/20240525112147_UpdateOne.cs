using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSubmitted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SelectedChoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: true),
                    AnswerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedChoices_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SelectedChoices_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SelectedChoices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelectedChoices_AnswerId",
                table: "SelectedChoices",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedChoices_QuestionId",
                table: "SelectedChoices",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedChoices_UserId",
                table: "SelectedChoices",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedChoices");

            migrationBuilder.DropColumn(
                name: "IsSubmitted",
                table: "Users");
        }
    }
}
