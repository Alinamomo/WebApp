using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class mimi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Accesouries_Id_acc",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "Id_acc",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Accesouries_Id_acc",
                table: "Product",
                column: "Id_acc",
                principalTable: "Accesouries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Accesouries_Id_acc",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "Id_acc",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Accesouries_Id_acc",
                table: "Product",
                column: "Id_acc",
                principalTable: "Accesouries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
