using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceAPI.Migrations
{
    /// <inheritdoc />
    public partial class MinorDbReinforcements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Sales",
                newName: "SaleDate");

            migrationBuilder.AddColumn<int>(
                name: "TotalCost",
                table: "ProductSales",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "ProductSales");

            migrationBuilder.RenameColumn(
                name: "SaleDate",
                table: "Sales",
                newName: "OrderDate");
        }
    }
}
