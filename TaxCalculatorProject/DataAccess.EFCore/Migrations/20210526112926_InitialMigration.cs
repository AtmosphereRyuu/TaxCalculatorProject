using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.EFCore.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostalCodeTaxCalculationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxCalculationType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCodeTaxCalculationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxCalculations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnualIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalculatedTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCalculations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PostalCodeTaxCalculationTypes",
                columns: new[] { "Id", "PostalCode", "TaxCalculationType" },
                values: new object[,]
                {
                    { new Guid("6e73e3ff-93ef-406e-a2d1-e24512f690db"), "7441", 0 },
                    { new Guid("b5504049-3075-4b14-91ce-bb7a1b5411d0"), "A100", 1 },
                    { new Guid("3cf8adeb-7f6f-4b33-9f2c-cc8a98622cda"), "7000", 2 },
                    { new Guid("4263b528-2a8f-4bea-96d2-ce2d50b229de"), "1000", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostalCodeTaxCalculationTypes");

            migrationBuilder.DropTable(
                name: "TaxCalculations");
        }
    }
}
