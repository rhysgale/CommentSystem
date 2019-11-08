using Microsoft.EntityFrameworkCore.Migrations;

namespace CommentSystem.Data.Migrations
{
    public partial class AddFilmsAndCommentsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmTitle = table.Column<string>(nullable: true),
                    FilmDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.FilmId);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(nullable: false),
                    CommentText = table.Column<string>(nullable: true),
                    CommenterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_CommenterId",
                        column: x => x.CommenterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommenterId",
                table: "Comments",
                column: "CommenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FilmId",
                table: "Comments",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
