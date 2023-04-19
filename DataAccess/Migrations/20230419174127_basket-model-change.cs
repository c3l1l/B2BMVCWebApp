using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class basketmodelchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2680fe47-8b00-4229-ac75-62f62b3e2bd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52312592-430f-4011-afa2-d162d29e6aef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "01be8c58-f512-4956-b914-358db9d5f3ad", "f9ea1690-91fa-4a3a-ac4b-e66b40ff3ac5", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f6b65db6-2b50-4553-b86a-2b9c830fdb6e", "fc1219ca-2bd8-40fb-af25-10afcff000e0", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01be8c58-f512-4956-b914-358db9d5f3ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6b65db6-2b50-4553-b86a-2b9c830fdb6e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2680fe47-8b00-4229-ac75-62f62b3e2bd9", "2ee358f1-e924-403d-ad52-d89ed73fc9f6", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52312592-430f-4011-afa2-d162d29e6aef", "7975b000-8262-4260-af8f-d1e8fd69796c", "user", "USER" });
        }
    }
}
