using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HalcyonApparelsInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessoryDetails",
                columns: table => new
                {
                    AccessoryId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessoryName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    AccessoryType = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    AccessoryBrand = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    AccessoryPrice = table.Column<int>(type: "INT", nullable: false),
                    AccessoryDiscount = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryDetails", x => x.AccessoryId);
                });

            migrationBuilder.CreateTable(
                name: "AdminLogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminLogin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginCredentials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginCredentials", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessoryDetails");

            migrationBuilder.DropTable(
                name: "AdminLogin");

            migrationBuilder.DropTable(
                name: "LoginCredentials");
        }
    }
}
