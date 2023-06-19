using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moyo_ismailstarke_backend.Migrations
{
    public partial class OrderItemsLinkToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderItem");

            migrationBuilder.AddColumn<int>(
                name: "OrderItemId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderItemId",
                table: "Order",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderItem_OrderItemId",
                table: "Order",
                column: "OrderItemId",
                principalTable: "OrderItem",
                principalColumn: "OrderItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderItem_OrderItemId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderItemId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
