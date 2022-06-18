using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geolocation.Api.Migrations
{
    public partial class GeolocationDBUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "GeolocationDetails");

            migrationBuilder.CreateTable(
                name: "Connection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Asn = table.Column<int>(type: "INTEGER", nullable: false),
                    Isp = table.Column<string>(type: "TEXT", nullable: true),
                    GeolocationDetailsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Connection_GeolocationDetails_GeolocationDetailsId",
                        column: x => x.GeolocationDetailsId,
                        principalTable: "GeolocationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Plural = table.Column<string>(type: "TEXT", nullable: true),
                    Symbol = table.Column<string>(type: "TEXT", nullable: true),
                    Symbol_native = table.Column<string>(type: "TEXT", nullable: true),
                    GeolocationDetailsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currency_GeolocationDetails_GeolocationDetailsId",
                        column: x => x.GeolocationDetailsId,
                        principalTable: "GeolocationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Geoname_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Capital = table.Column<string>(type: "TEXT", nullable: true),
                    Country_flag = table.Column<string>(type: "TEXT", nullable: true),
                    Is_eu = table.Column<bool>(type: "INTEGER", nullable: false),
                    GeolocationDetailsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_GeolocationDetails_GeolocationDetailsId",
                        column: x => x.GeolocationDetailsId,
                        principalTable: "GeolocationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Is_proxy = table.Column<bool>(type: "INTEGER", nullable: false),
                    Proxy_type = table.Column<string>(type: "TEXT", nullable: true),
                    Is_crawler = table.Column<bool>(type: "INTEGER", nullable: false),
                    Crawler_name = table.Column<string>(type: "TEXT", nullable: true),
                    Crawler_type = table.Column<string>(type: "TEXT", nullable: true),
                    Is_tor = table.Column<bool>(type: "INTEGER", nullable: false),
                    Threat_level = table.Column<string>(type: "TEXT", nullable: true),
                    Threat_types = table.Column<string>(type: "TEXT", nullable: true),
                    GeolocationDetailsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Security", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Security_GeolocationDetails_GeolocationDetailsId",
                        column: x => x.GeolocationDetailsId,
                        principalTable: "GeolocationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeZone",
                columns: table => new
                {
                    TimeZoneId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentTime = table.Column<string>(type: "TEXT", nullable: true),
                    Gmt_offset = table.Column<int>(type: "INTEGER", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Is_daylight_saving = table.Column<bool>(type: "INTEGER", nullable: false),
                    GeolocationDetailsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeZone", x => x.TimeZoneId);
                    table.ForeignKey(
                        name: "FK_TimeZone_GeolocationDetails_GeolocationDetailsId",
                        column: x => x.GeolocationDetailsId,
                        principalTable: "GeolocationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Native = table.Column<string>(type: "TEXT", nullable: true),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Connection_GeolocationDetailsId",
                table: "Connection",
                column: "GeolocationDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currency_GeolocationDetailsId",
                table: "Currency",
                column: "GeolocationDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LocationId",
                table: "Languages",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_GeolocationDetailsId",
                table: "Location",
                column: "GeolocationDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Security_GeolocationDetailsId",
                table: "Security",
                column: "GeolocationDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeZone_GeolocationDetailsId",
                table: "TimeZone",
                column: "GeolocationDetailsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Connection");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Security");

            migrationBuilder.DropTable(
                name: "TimeZone");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "GeolocationDetails",
                type: "TEXT",
                nullable: true);
        }
    }
}
