using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Loans.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "loan_details_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "loan_transactions_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "loan_types_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "LoanTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LoanTypeId = table.Column<int>(nullable: false),
                    LoanHolder = table.Column<string>(maxLength: 50, nullable: false),
                    LoanBranch = table.Column<string>(maxLength: 50, nullable: false),
                    LoanAmount = table.Column<decimal>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanDetails_LoanTypes_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "LoanTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LoanId = table.Column<int>(nullable: false),
                    TransactionAmount = table.Column<decimal>(nullable: false),
                    TransactionType = table.Column<string>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanTransactions_LoanDetails_LoanId",
                        column: x => x.LoanId,
                        principalTable: "LoanDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanDetails_LoanTypeId",
                table: "LoanDetails",
                column: "LoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanTransactions_LoanId",
                table: "LoanTransactions",
                column: "LoanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanTransactions");

            migrationBuilder.DropTable(
                name: "LoanDetails");

            migrationBuilder.DropTable(
                name: "LoanTypes");

            migrationBuilder.DropSequence(
                name: "loan_details_hilo");

            migrationBuilder.DropSequence(
                name: "loan_transactions_hilo");

            migrationBuilder.DropSequence(
                name: "loan_types_hilo");
        }
    }
}
