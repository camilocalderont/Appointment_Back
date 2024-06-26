using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class createCompanyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VcName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VcDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    VcPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VcPrincipalAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VcPrincipalEmail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VcLegalRepresentative = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    VcLogo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
