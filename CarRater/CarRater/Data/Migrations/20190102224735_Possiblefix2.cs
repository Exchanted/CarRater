using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRater.Data.Migrations
{
    public partial class Possiblefix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_MyPostsId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "MyPostsId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_MyPostsId",
                table: "Comments",
                column: "MyPostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_MyPostsId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "MyPostsId",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_MyPostsId",
                table: "Comments",
                column: "MyPostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
