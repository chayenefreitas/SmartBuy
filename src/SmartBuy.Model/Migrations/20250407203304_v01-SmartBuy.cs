using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartBuy.Model.Migrations
{
    /// <inheritdoc />
    public partial class v01SmartBuy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemMimeType",
                table: "Produtos",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemMimeType",
                table: "Produtos");
        }
    }
}
