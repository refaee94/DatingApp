using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class StableRoleConcurrencyStamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin-id",
                column: "ConcurrencyStamp",
                value: "705cb38f-1228-4270-804f-628ad69a052f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "member-id",
                column: "ConcurrencyStamp",
                value: "e5da536c-24dd-4f7b-afe8-5a12c7d36de5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "moderator-id",
                column: "ConcurrencyStamp",
                value: "26087936-39c1-40a9-beb9-f170032682cf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin-id",
                column: "ConcurrencyStamp",
                value: "608b1031-74ec-4b5b-9c59-fc6863a116f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "member-id",
                column: "ConcurrencyStamp",
                value: "ff638264-b3d7-4916-b4ad-189e2ce873d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "moderator-id",
                column: "ConcurrencyStamp",
                value: "29bcfa9e-4528-4a88-8e23-8b7b79540561");
        }
    }
}
