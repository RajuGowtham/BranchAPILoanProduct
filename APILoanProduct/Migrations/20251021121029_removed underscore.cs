using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APILoanProduct.Migrations
{
    /// <inheritdoc />
    public partial class removedunderscore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMasters_RoleMasters_Role_Id",
                table: "UserMasters");

            migrationBuilder.DropIndex(
                name: "IX_UserMasters_Role_Id",
                table: "UserMasters");

            migrationBuilder.DropColumn(
                name: "Role_Id",
                table: "UserMasters");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "UserMasters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMasters_RoleId",
                table: "UserMasters",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMasters_RoleMasters_RoleId",
                table: "UserMasters",
                column: "RoleId",
                principalTable: "RoleMasters",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMasters_RoleMasters_RoleId",
                table: "UserMasters");

            migrationBuilder.DropIndex(
                name: "IX_UserMasters_RoleId",
                table: "UserMasters");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "UserMasters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Role_Id",
                table: "UserMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserMasters_Role_Id",
                table: "UserMasters",
                column: "Role_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMasters_RoleMasters_Role_Id",
                table: "UserMasters",
                column: "Role_Id",
                principalTable: "RoleMasters",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
