using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateClientDeleteFieldAndAddedFullname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CLient",
                table: "CLient");

            migrationBuilder.DropColumn(
                name: "VcFirstLastName",
                table: "CLient");

            migrationBuilder.DropColumn(
                name: "VcFirstName",
                table: "CLient");

            migrationBuilder.DropColumn(
                name: "VcPassword",
                table: "CLient");

            migrationBuilder.DropColumn(
                name: "VcSecondLastName",
                table: "CLient");

            migrationBuilder.DropColumn(
                name: "VcSecondName",
                table: "CLient");

            migrationBuilder.DropColumn(
                name: "vcNickName",
                table: "CLient");

            migrationBuilder.RenameTable(
                name: "CLient",
                newName: "Client");

            migrationBuilder.AddColumn<string>(
                name: "VcFullName",
                table: "Client",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "VcFullName",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "CLient");

            migrationBuilder.AddColumn<string>(
                name: "VcFirstLastName",
                table: "CLient",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VcFirstName",
                table: "CLient",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VcPassword",
                table: "CLient",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VcSecondLastName",
                table: "CLient",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VcSecondName",
                table: "CLient",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "vcNickName",
                table: "CLient",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CLient",
                table: "CLient",
                column: "Id");
        }
    }
}
