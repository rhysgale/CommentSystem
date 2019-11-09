using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CommentSystem.Data.Migrations
{
    public partial class CommentHistoruy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedDateTime",
                table: "Comments");

            migrationBuilder.CreateTable(
                name: "CommentsHistory",
                columns: table => new
                {
                    HistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkedToComment = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    CreatedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentsHistory", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_CommentsHistory_Comments_LinkedToComment",
                        column: x => x.LinkedToComment,
                        principalTable: "Comments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentsHistory_LinkedToComment",
                table: "CommentsHistory",
                column: "LinkedToComment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentsHistory");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDateTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
