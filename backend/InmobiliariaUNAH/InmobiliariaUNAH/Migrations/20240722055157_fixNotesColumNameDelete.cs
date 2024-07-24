using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InmobiliariaUNAH.Migrations
{
    /// <inheritdoc />
    public partial class fixNotesColumNameDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                schema: "dbo",
                table: "notes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                schema: "dbo",
                table: "notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
