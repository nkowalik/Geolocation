using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geolocation.Api.Migrations
{
    public partial class GeolocationDbUpdateLocationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Calling_code",
                table: "Location",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country_flag_emoji",
                table: "Location",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country_flag_emoji_unicode",
                table: "Location",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calling_code",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Country_flag_emoji",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Country_flag_emoji_unicode",
                table: "Location");
        }
    }
}
