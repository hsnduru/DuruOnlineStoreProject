using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DuruOnlineStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Order_OrderDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    OrderNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubTotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShippingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2049));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2051));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2052));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2053));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2054));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2056));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2057));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2058));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2059));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2060));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2062));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2063));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2064));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2065));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2069));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2070));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2071));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2073));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2074));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2075));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2077));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2078));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2085));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2086));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2087));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2092));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2094));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2096));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2097));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "AddedDate",
                value: new DateTime(2024, 2, 14, 0, 54, 1, 101, DateTimeKind.Local).AddTicks(2099));

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6722));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6734));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6735));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6737));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6738));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6739));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6741));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6743));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6744));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6745));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6746));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6752));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6753));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6756));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6757));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6758));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6759));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6761));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6765));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6766));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6800));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6802));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6803));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6804));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6805));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6806));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6807));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6808));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6809));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6811));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6812));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6813));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6814));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45,
                column: "AddedDate",
                value: new DateTime(2024, 1, 27, 18, 56, 26, 255, DateTimeKind.Local).AddTicks(6816));
        }
    }
}
