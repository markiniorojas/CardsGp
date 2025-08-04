using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cylinderCapacity = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    hP = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    finalSpeed = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    nOclylinder = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    weight = table.Column<string>(type: "nvarchar(max)", precision: 10, scale: 2, nullable: false),
                    torque = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    winner = table.Column<int>(type: "int", nullable: false),
                    startTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    endTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    points = table.Column<int>(type: "int", nullable: false),
                    playersId = table.Column<int>(type: "int", nullable: false),
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayers", x => x.id);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Players_playersId",
                        column: x => x.playersId,
                        principalTable: "Players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerCards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isUsed = table.Column<bool>(type: "bit", nullable: false),
                    gamePlayerId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCards", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlayerCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerCards_GamePlayers_gamePlayerId",
                        column: x => x.gamePlayerId,
                        principalTable: "GamePlayers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "id", "cardName", "cylinderCapacity", "finalSpeed", "hP", "nOclylinder", "torque", "weight" },
                values: new object[,]
                {
                    { 1, "Kawasaki Z900", 948m, 246m, 123.6m, 4m, 98.6m, "190 kg" },
                    { 2, "Aprillia RSV4", 1099m, 285m, 137.2m, 4m, 100.1m, "202 kg" },
                    { 3, "Yamaha MT-09", 847m, 279m, 121.2m, 4m, 93.2m, "182 kg" },
                    { 4, "Kawasaki ZH2", 997m, 290m, 127.2m, 4m, 108.2m, "192 kg" },
                    { 5, "Yamaha MT-10 SP", 996m, 285.1m, 123.7m, 4m, 102.4m, "183 kg" },
                    { 6, "CF Motos SR R 675", 675m, 238m, 94.0m, 4m, 70m, "184 kg" },
                    { 7, "Honda CBR 600", 599m, 256m, 120.5m, 4m, 63.4m, "186 kg" },
                    { 8, "Honda CBR 600 RR", 610m, 268.2m, 121.3m, 4m, 74.1m, "185 kg" },
                    { 9, "KTM Duke 1390", 1390m, 290.3m, 125.2m, 4m, 116.3m, "209 kg" },
                    { 10, "Ducati Panigale V4", 1103m, 299.2m, 123.5m, 4m, 124.3m, "198 kg" },
                    { 11, "Kawasaki Z1000", 1043m, 250m, 126.7m, 4m, 112m, "208 kg" },
                    { 12, "Ducati Diavel", 1158m, 275m, 124.6m, 4m, 111.4m, "214 kg" },
                    { 13, "Yamaha R6", 601m, 269m, 117m, 4m, 71m, "184 kg" },
                    { 14, "CF Motos SR 450", 450m, 193m, 47m, 4m, 59m, "168 kg" },
                    { 15, "BMW S1000R", 1004m, 259m, 127.9m, 4m, 103.1m, "201 kg" },
                    { 16, "Honda CB 1000", 992m, 234m, 123.8m, 4m, 104.5m, "202 kg" },
                    { 17, "Kawasaki ZX 6R", 636m, 265m, 120.1m, 4m, 78m, "198 kg" },
                    { 18, "Kawasaki ZX 10 RR", 1000m, 300m, 123.9m, 4m, 114.3m, "197 kg" },
                    { 19, "Aprillia RS 660", 659m, 230m, 110m, 4m, 77.4m, "179 kg" },
                    { 20, "BMW GS1200", 1170m, 260.4m, 124.3m, 4m, 109.5m, "214 kg" },
                    { 21, "Yamaha Tracer 900", 890m, 238.1m, 119m, 4m, 103m, "219 kg" },
                    { 22, "Honda CBR 1000 RR", 998m, 298.9m, 125.7m, 4m, 113.9m, "206 kg" },
                    { 23, "Suzuki GSX-R750", 749m, 284.3m, 118m, 4m, 126.3m, "173 kg" },
                    { 24, "Yamaha R1M", 995m, 298.5m, 127.6m, 4m, 115.7m, "207 kg" },
                    { 25, "Suzuki GSX-R1000R", 1001m, 297.9m, 127.7m, 4m, 112.4m, "197 kg" },
                    { 26, "Ducati Streetfighter V4", 1103m, 296.6m, 129.4m, 4m, 113.6m, "196.4 kg" },
                    { 27, "Suzuki GSX S 1000", 1002m, 287.8m, 122.6m, 4m, 106.1m, "203.5 kg" },
                    { 28, "Suzuki Hayabusa", 1340m, 301m, 125.4m, 4m, 104.4m, "219.4 kg" },
                    { 29, "KTM RC 8C", 889m, 277.3m, 125.3m, 4m, 102m, "197.6 kg" },
                    { 30, "KTM Duke 390", 399m, 223m, 46m, 4m, 37m, "169 kg" },
                    { 31, "BMW S1000 RR", 1004m, 299.9m, 129.3m, 4m, 114.8m, "199.3 kg" },
                    { 32, "Kawasaki H2R", 1007m, 300.1m, 139m, 4m, 130m, "198.8 kg" },
                    { 33, "Yamaha R7", 689m, 179.8m, 118.7m, 4m, 118.9m, "187.5 kg" },
                    { 34, "Suzuki Katana 1000", 1008m, 284.4m, 126.4m, 4m, 116.4m, "193.1 kg" },
                    { 35, "Ducati Super Sport 950S", 937m, 296.7m, 124.0m, 4m, 117.2m, "187.1 kg" },
                    { 36, "Ducati Monster 937", 937m, 282.2m, 127.3m, 4m, 116.5m, "195.1 kg" },
                    { 37, "Ducati 848 EVO", 848m, 276.6m, 123.3m, 4m, 119.6m, "202.1 kg" },
                    { 38, "Triumph Daytona Moto2 765", 765m, 288.2m, 122.2m, 4m, 120.1m, "203.5 kg" },
                    { 39, "Triumph Speed Triple 1200 RR", 1190m, 280.2m, 126.5m, 4m, 126.4m, "210.4 kg" },
                    { 40, "MV Agusta F3 800", 799m, 267.8m, 122.1m, 4m, 122.3m, "197.1 kg" },
                    { 41, "MV Agusta Brutale 1000 RR", 1010m, 294.8m, 128.6m, 4m, 126.1m, "203.5 kg" },
                    { 42, "BMW R nineT Race", 1000m, 291.7m, 128.4m, 4m, 121.1m, "192.9 kg" },
                    { 43, "CF Moto 800NK Sport", 789m, 277.2m, 124.1m, 4m, 112.1m, "187.4 kg" },
                    { 44, "MV Agusta Superveloce 800", 792m, 280.3m, 121.7m, 4m, 102.9m, "188.2 kg" },
                    { 45, "MV Agusta Turismo Veloce 800 Lusso SCS", 788m, 284.5m, 125.5m, 4m, 101.2m, "192.1 kg" },
                    { 46, "Bimota Tesi H2", 1014m, 292.1m, 129.6m, 4m, 112.2m, "188.8 kg" },
                    { 47, "Bimota KB4", 1017m, 287.9m, 126.9m, 4m, 112.9m, "190.2 kg" },
                    { 48, "Kawasaki Ninja ZX-12R", 1197m, 288.6m, 127.1m, 4m, 119.3m, "204.5 kg" },
                    { 49, "Kawasaki Ninja ZX-14R", 1390m, 298.8m, 130.2m, 4m, 128.2m, "209.4 kg" },
                    { 50, "Yamaha FJR 1300", 1270m, 287.2m, 127.4m, 4m, 122.4m, "201.9 kg" },
                    { 51, "Honda VFR800 Interceptor", 869m, 282.8m, 118.1m, 4m, 122.2m, "173.5 kg" },
                    { 52, "Honda VFR 1200F", 1193m, 293.2m, 125.9m, 4m, 131.3m, "202.8 kg" },
                    { 53, "Honda CBR1100XX Blackbird", 1100m, 297.2m, 124.8m, 4m, 114.4m, "191.7 kg" },
                    { 54, "Suzuki TL1000R", 1009m, 273.8m, 132.8m, 4m, 111.7m, "213.2 kg" },
                    { 55, "Triumph Daytona955i", 954m, 301.6m, 135.8m, 4m, 114.5m, "219.4 kg" },
                    { 56, "Beneli TNT 1130R", 1130m, 290.7m, 135.3m, 4m, 110.9m, "198.3 kg" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "id", "date", "endTime", "startTime", "winner" },
                values: new object[] { 1, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "5:15 Pm", "5:00 Pm", 1 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "id", "userName" },
                values: new object[,]
                {
                    { 1, "camilosada12" },
                    { 2, "marcos12" },
                    { 3, "palomar12" },
                    { 4, "palmar12" },
                    { 5, "marcami31" }
                });

            migrationBuilder.InsertData(
                table: "GamePlayers",
                columns: new[] { "id", "GamesId", "playersId", "points" },
                values: new object[,]
                {
                    { 1, 1, 1, 3 },
                    { 2, 1, 2, 2 },
                    { 3, 1, 3, 5 },
                    { 4, 1, 4, 6 },
                    { 5, 1, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "PlayerCards",
                columns: new[] { "id", "CardId", "gamePlayerId", "isUsed" },
                values: new object[] { 1, 1, 1, true });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_GamesId",
                table: "GamePlayers",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_playersId",
                table: "GamePlayers",
                column: "playersId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCards_CardId",
                table: "PlayerCards",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCards_gamePlayerId",
                table: "PlayerCards",
                column: "gamePlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerCards");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "GamePlayers");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
