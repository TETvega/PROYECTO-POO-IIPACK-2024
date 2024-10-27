using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InmobiliariaUNAH.Migrations
{
    /// <inheritdoc />
    public partial class UsersTableEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "security",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "security",
                table: "users",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "security",
                table: "users",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "security",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
