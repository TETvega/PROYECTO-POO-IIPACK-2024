using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InmobiliariaUNAH.Migrations
{
    /// <inheritdoc />
    public partial class fixEbentEntityAndUserClientType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cost_whitout_discount",
                schema: "dbo",
                table: "event",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "cost_discount",
                schema: "dbo",
                table: "event",
                newName: "subtotal");

            migrationBuilder.AddColumn<decimal>(
                name: "discount",
                schema: "dbo",
                table: "event",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_user_clientType_id",
                schema: "dbo",
                table: "user",
                column: "clientType_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_client_type_clientType_id",
                schema: "dbo",
                table: "user",
                column: "clientType_id",
                principalSchema: "dbo",
                principalTable: "client_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_client_type_clientType_id",
                schema: "dbo",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_clientType_id",
                schema: "dbo",
                table: "user");

            migrationBuilder.DropColumn(
                name: "discount",
                schema: "dbo",
                table: "event");

            migrationBuilder.RenameColumn(
                name: "total",
                schema: "dbo",
                table: "event",
                newName: "cost_whitout_discount");

            migrationBuilder.RenameColumn(
                name: "subtotal",
                schema: "dbo",
                table: "event",
                newName: "cost_discount");
        }
    }
}
