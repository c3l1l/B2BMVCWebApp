using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class citypaymentmethodenums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20ca6b94-ba7f-46bf-ac40-f3549dbc2c09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6032631a-1094-430c-b8d4-35e18ccafe49");

            migrationBuilder.AddColumn<int>(
                name: "City",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7710daca-2d51-4128-8b05-1544ab1e031b", "9c4f64f4-c074-49b3-8ae3-4b999c5dd130", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad6489f5-60b4-402b-a469-2f6d0186d5cc", "68b65b6a-80fa-4248-a0ac-4b4ae715a382", "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7710daca-2d51-4128-8b05-1544ab1e031b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad6489f5-60b4-402b-a469-2f6d0186d5cc");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20ca6b94-ba7f-46bf-ac40-f3549dbc2c09", "06748c2f-eeee-4454-aefd-d5557715182a", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6032631a-1094-430c-b8d4-35e18ccafe49", "763e0b3b-8c1d-40bd-a087-cddcf11c85eb", "admin", "ADMIN" });
        }
    }
}
