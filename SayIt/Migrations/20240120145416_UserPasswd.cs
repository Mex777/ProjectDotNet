using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SayIt.Migrations
{
    /// <inheritdoc />
    public partial class UserPasswd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorUsername",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_Username",
                table: "Users",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorUsername",
                table: "Posts",
                column: "AuthorUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AuthorUsername",
                table: "Posts",
                column: "AuthorUsername",
                principalTable: "Users",
                principalColumn: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AuthorUsername",
                table: "Posts");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_Username",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Posts_AuthorUsername",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AuthorUsername",
                table: "Posts");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
