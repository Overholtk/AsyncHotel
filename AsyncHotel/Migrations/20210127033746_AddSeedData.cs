using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncHotel.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Heated Bath" },
                    { 2, "Oil Lamps" },
                    { 3, "Crawling Claw Control" }
                });

            migrationBuilder.InsertData(
                table: "Bedrooms",
                columns: new[] { "ID", "Layout", "Nickname" },
                values: new object[,]
                {
                    { 1, 0, "The Underdark" },
                    { 2, 1, "Dusty WereRat" },
                    { 3, 3, "Ancient Red Dragon" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "City", "Country", "Name", "PhoneNumber", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Cityton", "Accordiantica", "The Glorious Accordian", "5555555555", "New Statewise", "246513 Street st" },
                    { 2, "Cityton", "Accordiantica", "The Unarmed Crystal", "5555555555", "New Statewise", "4864513 Street st" },
                    { 3, "Cityton", "Accordiantica", "Panoramic Goats Pub", "5555555555", "New Statewise", "2465489 Street st" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bedrooms",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bedrooms",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bedrooms",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
