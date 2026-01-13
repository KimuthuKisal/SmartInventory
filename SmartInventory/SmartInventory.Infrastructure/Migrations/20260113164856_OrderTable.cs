using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartInventory.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<float>(type: "real", nullable: false),
                    OrderAmount = table.Column<float>(type: "real", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    StandardDiscount = table.Column<float>(type: "real", nullable: false),
                    LoyaltyDiscount = table.Column<float>(type: "real", nullable: false),
                    TotalDiscount = table.Column<float>(type: "real", nullable: false),
                    DiscountedTotalPrice = table.Column<float>(type: "real", nullable: false),
                    TotalRevenue = table.Column<float>(type: "real", nullable: false),
                    TotalProfit = table.Column<float>(type: "real", nullable: false),
                    TransportCost = table.Column<float>(type: "real", nullable: false),
                    LoadingCost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    StandardDiscount = table.Column<float>(type: "real", nullable: false),
                    LoyaltyDiscount = table.Column<float>(type: "real", nullable: false),
                    TotalDiscount = table.Column<float>(type: "real", nullable: false),
                    DiscountedTotalPrice = table.Column<float>(type: "real", nullable: false),
                    TotalRevenue = table.Column<float>(type: "real", nullable: false),
                    TotalProfit = table.Column<float>(type: "real", nullable: false),
                    NumberOfItems = table.Column<int>(type: "int", nullable: false),
                    LoyaltyPointsEarned = table.Column<float>(type: "real", nullable: false),
                    LoyaltyPointsRedeemed = table.Column<float>(type: "real", nullable: false),
                    SalespersonId = table.Column<int>(type: "int", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
