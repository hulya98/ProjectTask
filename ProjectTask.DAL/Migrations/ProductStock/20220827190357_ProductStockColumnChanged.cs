using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTask.DAL.Migrations.ProductStock
{
    public partial class ProductStockColumnChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewAddedProductCount",
                table: "ProductStock");

            migrationBuilder.DropColumn(
                name: "NewSoldProductCount",
                table: "ProductStock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewAddedProductCount",
                table: "ProductStock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NewSoldProductCount",
                table: "ProductStock",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
