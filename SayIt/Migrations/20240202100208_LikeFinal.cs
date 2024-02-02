using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SayIt.Migrations
{
    /// <inheritdoc />
    public partial class LikeFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Likes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Likes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Likes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Likes");
        }
    }
}
