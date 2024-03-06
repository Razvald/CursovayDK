using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rlf.Migrations
{
    /// <inheritdoc />
    public partial class change_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Category_categoryID",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "sum",
                table: "Transaction",
                newName: "Sum");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Transaction",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "categoryID",
                table: "Transaction",
                newName: "CategoryID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Transaction",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_categoryID",
                table: "Transaction",
                newName: "IX_Transaction_CategoryID");

            migrationBuilder.RenameColumn(
                name: "desc",
                table: "Category",
                newName: "Desc");

            migrationBuilder.RenameColumn(
                name: "categoryName",
                table: "Category",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Category",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_UserId",
                table: "Transaction",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Category_CategoryID",
                table: "Transaction",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Users_UserId",
                table: "Transaction",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Category_CategoryID",
                table: "Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Users_UserId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_UserId",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "Sum",
                table: "Transaction",
                newName: "sum");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Transaction",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Transaction",
                newName: "categoryID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Transaction",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_CategoryID",
                table: "Transaction",
                newName: "IX_Transaction_categoryID");

            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Category",
                newName: "desc");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Category",
                newName: "categoryName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Category",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Category_categoryID",
                table: "Transaction",
                column: "categoryID",
                principalTable: "Category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
