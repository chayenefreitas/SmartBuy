using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartBuy.Model.Migrations
{
    /// <inheritdoc />
    public partial class v07SmartBuy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdUsuario",
                table: "Vendedores",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Vendedores");
        }
    }
}
