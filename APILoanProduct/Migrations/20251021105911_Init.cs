using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APILoanProduct.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleMasters",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMasters", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "UserMasters",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserPasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmailId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Role_Id = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMasters", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserMasters_RoleMasters_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "RoleMasters",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BranchIFSCcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BranchLocation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ManagerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_Branches_UserMasters_ManagerUserId",
                        column: x => x.ManagerUserId,
                        principalTable: "UserMasters",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplications",
                columns: table => new
                {
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    RequestedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TenureYears = table.Column<int>(type: "int", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_LoanApplications_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanApplications_UserMasters_UserId",
                        column: x => x.UserId,
                        principalTable: "UserMasters",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicantDetails",
                columns: table => new
                {
                    ApplicantDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    EmploymentStatus = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    AnnualIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplicantDetails", x => x.ApplicantDetailsId);
                    table.ForeignKey(
                        name: "FK_LoanApplicantDetails_LoanApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationDocuments",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplicationDocuments", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_LoanApplicationDocuments_LoanApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplicationReviews",
                columns: table => new
                {
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplicationReviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_LoanApplicationReviews_LoanApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplicationReviews_UserMasters_ManagerUserId",
                        column: x => x.ManagerUserId,
                        principalTable: "UserMasters",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanDisbursements",
                columns: table => new
                {
                    DisbursementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisbursementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DisbursementAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDisbursements", x => x.DisbursementId);
                    table.ForeignKey(
                        name: "FK_LoanDisbursements_LoanApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchLoanProducts",
                columns: table => new
                {
                    BranchLoanProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchLoanProducts", x => x.BranchLoanProductId);
                    table.ForeignKey(
                        name: "FK_BranchLoanProducts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestRates",
                columns: table => new
                {
                    InterestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterestType = table.Column<int>(type: "int", nullable: true),
                    InterestRates = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DisbursementInterestrate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ProcessingFee = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    PenaltyRate = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestRates", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "LoanProducts",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AccountSettingsInterestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanProducts", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_LoanProducts_InterestRates_AccountSettingsInterestId",
                        column: x => x.AccountSettingsInterestId,
                        principalTable: "InterestRates",
                        principalColumn: "InterestId");
                });

            migrationBuilder.CreateTable(
                name: "LoanAmountDetails",
                columns: table => new
                {
                    LoanAmountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DefaultAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tranches = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanAmountDetails", x => x.LoanAmountId);
                    table.ForeignKey(
                        name: "FK_LoanAmountDetails_LoanProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "LoanProducts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanDocuments",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressProof = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IncomeProof = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IdentityProof = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AdditionalDocuments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDocuments", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_LoanDocuments_LoanProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "LoanProducts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAvailabilities",
                columns: table => new
                {
                    AvailabilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ProductAvailabilityto = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAvailabilities", x => x.AvailabilityId);
                    table.ForeignKey(
                        name: "FK_ProductAvailabilities_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductAvailabilities_LoanProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "LoanProducts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepaymentDetails",
                columns: table => new
                {
                    RepaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinimumTenure = table.Column<int>(type: "int", nullable: false),
                    MaximumTenure = table.Column<int>(type: "int", nullable: false),
                    GracePerioddays = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepaymentDetails", x => x.RepaymentId);
                    table.ForeignKey(
                        name: "FK_RepaymentDetails_LoanProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "LoanProducts",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_ManagerUserId",
                table: "Branches",
                column: "ManagerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLoanProducts_BranchId",
                table: "BranchLoanProducts",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLoanProducts_ProductId",
                table: "BranchLoanProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestRates_ProductId",
                table: "InterestRates",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanAmountDetails_ProductId",
                table: "LoanAmountDetails",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicantDetails_ApplicationId",
                table: "LoanApplicantDetails",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationDocuments_ApplicationId",
                table: "LoanApplicationDocuments",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationReviews_ApplicationId",
                table: "LoanApplicationReviews",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplicationReviews_ManagerUserId",
                table: "LoanApplicationReviews",
                column: "ManagerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_BranchId",
                table: "LoanApplications",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_UserId",
                table: "LoanApplications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanDisbursements_ApplicationId",
                table: "LoanDisbursements",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanDocuments_ProductId",
                table: "LoanDocuments",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanProducts_AccountSettingsInterestId",
                table: "LoanProducts",
                column: "AccountSettingsInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAvailabilities_BranchId",
                table: "ProductAvailabilities",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAvailabilities_ProductId",
                table: "ProductAvailabilities",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentDetails_ProductId",
                table: "RepaymentDetails",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMasters_Role_Id",
                table: "UserMasters",
                column: "Role_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchLoanProducts_LoanProducts_ProductId",
                table: "BranchLoanProducts",
                column: "ProductId",
                principalTable: "LoanProducts",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestRates_LoanProducts_ProductId",
                table: "InterestRates",
                column: "ProductId",
                principalTable: "LoanProducts",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestRates_LoanProducts_ProductId",
                table: "InterestRates");

            migrationBuilder.DropTable(
                name: "BranchLoanProducts");

            migrationBuilder.DropTable(
                name: "LoanAmountDetails");

            migrationBuilder.DropTable(
                name: "LoanApplicantDetails");

            migrationBuilder.DropTable(
                name: "LoanApplicationDocuments");

            migrationBuilder.DropTable(
                name: "LoanApplicationReviews");

            migrationBuilder.DropTable(
                name: "LoanDisbursements");

            migrationBuilder.DropTable(
                name: "LoanDocuments");

            migrationBuilder.DropTable(
                name: "ProductAvailabilities");

            migrationBuilder.DropTable(
                name: "RepaymentDetails");

            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "UserMasters");

            migrationBuilder.DropTable(
                name: "RoleMasters");

            migrationBuilder.DropTable(
                name: "LoanProducts");

            migrationBuilder.DropTable(
                name: "InterestRates");
        }
    }
}
