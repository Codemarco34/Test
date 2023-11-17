using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AREMSUPPORTDESK.Migrations
{
    /// <inheritdoc />
    public partial class AREMTEST : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerTaxNumber = table.Column<int>(type: "int", nullable: false),
                    MainCurrentCode = table.Column<int>(type: "int", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Esolutions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServicePeriod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceTime = table.Column<int>(type: "int", nullable: false),
                    TaxNumber = table.Column<int>(type: "int", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Active", "Adress", "CustomerCode", "CustomerTaxNumber", "Esolutions", "MainCurrentCode", "MaintenanceDate", "Modul", "ProductGroup", "Title", "Version" },
                values: new object[] { 1, false, "Kozyatağı", "1", 2014, "E-fatura", 2014, new DateTime(2023, 11, 17, 12, 27, 8, 153, DateTimeKind.Local).AddTicks(4340), "FLY", "AREM", "AREM", "v16" });

            migrationBuilder.InsertData(
                table: "Maintenances",
                columns: new[] { "Id", "Customer", "DealType", "Explanation", "FinishDate", "IsActive", "ServicePeriod", "ServiceTime", "StartDate", "TaxNumber" },
                values: new object[] { 1, "Test", "Test", "AREM TEST VERİON", new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Local), false, "AREMTEST", 50, new DateTime(2023, 11, 17, 12, 27, 8, 153, DateTimeKind.Local).AddTicks(5120), 3456423 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Maintenances");
        }
    }
}
