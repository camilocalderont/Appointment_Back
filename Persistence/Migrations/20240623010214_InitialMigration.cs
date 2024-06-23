using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLient",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VcIdentificationNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    VcPhone = table.Column<string>(type: "text", nullable: false),
                    vcNickName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    VcFirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    VcSecondName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    VcFirstLastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    VcSecondLastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    VcEmail = table.Column<string>(type: "text", nullable: false),
                    VcPassword = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    BIsActived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
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
