using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace rlf.Migrations
{
    /// <inheritdoc />
    public partial class fill_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CategoryName", "Desc" },
                values: new object[,]
                {
                    { 1, "Доходы", "Получил" },
                    { 2, "Расходы", "Потратил" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Login", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, "admin@admin", "admin", "10713417811525552252225157107128782559063877117316423416247297319230822211831359175", 1 },
                    { 2, "user@user", "user", "10713417811525552252225157107128782559063877117316423416247297319230822211831359175", 2 }
                });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "Id", "CategoryID", "Desc", "Name", "Sum", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "что-то", "Траты в ###", 3000, 1 },
                    { 2, 2, "что-то", "Траты в ###", 11100, 2 },
                    { 3, 1, "что-то", "Траты в ###", 15300, 1 },
                    { 4, 2, "что-то", "Траты в ###", 12300, 2 },
                    { 5, 1, "что-то", "Траты в ###", 1500, 2 },
                    { 6, 2, "что-то", "Траты в ###", 10200, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Name", "NickName", "Phone", "PlaceOfResidence", "TimeZone", "UserId" },
                values: new object[,]
                {
                    { 1, "Admin Name", "AdminNick", "123456789", "Admin's Residence", "MSK+4", 1 },
                    { 2, "User Name", "UserNick", "987654321", "User's Residence", "MSK+5", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Transaction",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserProfiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
