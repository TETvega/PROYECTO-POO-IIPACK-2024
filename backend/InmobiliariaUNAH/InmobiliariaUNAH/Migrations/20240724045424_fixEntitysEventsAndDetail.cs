using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InmobiliariaUNAH.Migrations
{
    /// <inheritdoc />
    public partial class fixEntitysEventsAndDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cost",
                schema: "dbo",
                table: "detail");

            migrationBuilder.DropColumn(
                name: "count",
                schema: "dbo",
                table: "detail");

            migrationBuilder.DropColumn(
                name: "name",
                schema: "dbo",
                table: "detail");

            migrationBuilder.DropColumn(
                name: "state",
                schema: "dbo",
                table: "detail");

            migrationBuilder.RenameColumn(
                name: "amount",
                schema: "dbo",
                table: "detail",
                newName: "unit_price");

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                schema: "dbo",
                table: "detail",
                type: "int",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "dbo",
                table: "category_product",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                schema: "dbo",
                table: "detail");

            migrationBuilder.RenameColumn(
                name: "unit_price",
                schema: "dbo",
                table: "detail",
                newName: "amount");

            migrationBuilder.AddColumn<decimal>(
                name: "cost",
                schema: "dbo",
                table: "detail",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "count",
                schema: "dbo",
                table: "detail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "name",
                schema: "dbo",
                table: "detail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "state",
                schema: "dbo",
                table: "detail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "dbo",
                table: "category_product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
