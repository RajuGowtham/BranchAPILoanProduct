using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APILoanProduct.Migrations
{
    /// <inheritdoc />
    public partial class latest3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanProducts_InterestRates_AccountSettingsInterestId",
                table: "LoanProducts");

            migrationBuilder.DropIndex(
                name: "IX_LoanProducts_AccountSettingsInterestId",
                table: "LoanProducts");

            migrationBuilder.DropColumn(
                name: "AccountSettingsInterestId",
                table: "LoanProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountSettingsInterestId",
                table: "LoanProducts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanProducts_AccountSettingsInterestId",
                table: "LoanProducts",
                column: "AccountSettingsInterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanProducts_InterestRates_AccountSettingsInterestId",
                table: "LoanProducts",
                column: "AccountSettingsInterestId",
                principalTable: "InterestRates",
                principalColumn: "InterestId");
        }
    }
}
