using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InteleqtCapture.Data.Migrations
{
    public partial class DateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "annuities",
                columns: table => new
                {
                    EntityId = table.Column<string>(nullable: false),
                    EntityFullName = table.Column<string>(nullable: true),
                    AnnuityAmount = table.Column<double>(nullable: false),
                    AnniversaryDate = table.Column<DateTimeOffset>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    RenewalDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_annuities", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "maintenances",
                columns: table => new
                {
                    EntityId = table.Column<string>(nullable: false),
                    EntityFullName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    RenewalDate = table.Column<DateTimeOffset>(nullable: false),
                    Product = table.Column<string>(nullable: true),
                    ProductCategory = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    Value = table.Column<int>(nullable: false),
                    YearlyMaintenance = table.Column<int>(nullable: false),
                    Item = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenances", x => x.EntityId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "annuities");

            migrationBuilder.DropTable(
                name: "maintenances");
        }
    }
}
