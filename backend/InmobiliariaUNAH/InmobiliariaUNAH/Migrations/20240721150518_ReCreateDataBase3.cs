using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InmobiliariaUNAH.Migrations
{
    /// <inheritdoc />
    public partial class ReCreateDataBase3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "dbo",
                table: "product",
                type: "nvarchar(501)",
                maxLength: 501,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "dbo",
                table: "notes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "dbo",
                table: "product",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(501)",
                oldMaxLength: 501);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "dbo",
                table: "notes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
