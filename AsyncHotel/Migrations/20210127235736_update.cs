using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncHotel.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bedrooms",
                table: "Bedrooms");

            migrationBuilder.RenameTable(
                name: "Bedrooms",
                newName: "Rooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Bedrooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bedrooms",
                table: "Bedrooms",
                column: "ID");
        }
    }
}
