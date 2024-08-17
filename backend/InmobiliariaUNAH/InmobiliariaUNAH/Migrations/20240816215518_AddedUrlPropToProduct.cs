using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InmobiliariaUNAH.Migrations
{
    /// <inheritdoc />
    public partial class AddedUrlPropToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "url_image",
                schema: "dbo",
                table: "product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProductDtoForCategoryProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryProductEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDtoForCategoryProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDtoForCategoryProduct_category_product_CategoryProductEntityId",
                        column: x => x.CategoryProductEntityId,
                        principalSchema: "dbo",
                        principalTable: "category_product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDtoForCategoryProduct_CategoryProductEntityId",
                table: "ProductDtoForCategoryProduct",
                column: "CategoryProductEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDtoForCategoryProduct");

            migrationBuilder.DropColumn(
                name: "url_image",
                schema: "dbo",
                table: "product");
        }
    }
}
