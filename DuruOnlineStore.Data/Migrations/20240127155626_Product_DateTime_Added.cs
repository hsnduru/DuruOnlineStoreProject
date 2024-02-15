using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DuruOnlineStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Product_DateTime_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Products");
        }
    }
}
