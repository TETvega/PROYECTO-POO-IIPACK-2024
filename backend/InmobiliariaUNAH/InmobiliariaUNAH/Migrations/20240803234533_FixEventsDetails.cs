using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InmobiliariaUNAH.Migrations
{
    /// <inheritdoc />
    public partial class FixEventsDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "state",
                schema: "dbo",
                table: "event");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "state",
                schema: "dbo",
                table: "event",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
