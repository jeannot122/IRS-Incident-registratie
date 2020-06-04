using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace IRS.API.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Incidents",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeId",
                table: "Incidents",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    LocationName = table.Column<string>(nullable: false),
                    LocationType = table.Column<string>(nullable: true),
                    BusinessEmailAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Addition = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: false),
                    TypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Incidents",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Incidents",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Accounts",
                type: "text",
                nullable: true);
        }
    }
}
