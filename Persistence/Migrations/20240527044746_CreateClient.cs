using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VcIdentificationNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VcPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vcNickName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VcFirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VcSecondName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VcFirstLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VcSecondLastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VcEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VcPassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLient", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLient");
        }
    }
}
