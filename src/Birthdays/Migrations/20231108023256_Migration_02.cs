using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthdays.Migrations
{
    /// <inheritdoc />
    public partial class Migration_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Birthdays",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Birthdays",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Birthdays",
                table: "Birthdays",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Birthdays",
                table: "Birthdays");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Birthdays");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Birthdays",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
