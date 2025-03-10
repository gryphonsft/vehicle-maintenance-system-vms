using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspProject1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Araclar",
                columns: table => new
                {
                    AracID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plaka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yil = table.Column<int>(type: "int", nullable: false),
                    BakimNotu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusteriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araclar", x => x.AracID);
                });

            migrationBuilder.CreateTable(
                name: "BakimFiyatlari",
                columns: table => new
                {
                    BakimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BakimAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ucret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakimFiyatlari", x => x.BakimID);
                });

            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Islemler",
                columns: table => new
                {
                    IslemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AracID = table.Column<int>(type: "int", nullable: false),
                    BakimID = table.Column<int>(type: "int", nullable: false),
                    IslemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IslemNotu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AraclarAracID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Islemler", x => x.IslemID);
                    table.ForeignKey(
                        name: "FK_Islemler_Araclar_AracID",
                        column: x => x.AracID,
                        principalTable: "Araclar",
                        principalColumn: "AracID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Islemler_Araclar_AraclarAracID",
                        column: x => x.AraclarAracID,
                        principalTable: "Araclar",
                        principalColumn: "AracID");
                    table.ForeignKey(
                        name: "FK_Islemler_BakimFiyatlari_BakimID",
                        column: x => x.BakimID,
                        principalTable: "BakimFiyatlari",
                        principalColumn: "BakimID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BakimFiyatlari",
                columns: new[] { "BakimID", "Aciklama", "BakimAdi", "Ucret" },
                values: new object[,]
                {
                    { 1, null, "Yağ Değişimi", 500m },
                    { 2, null, "Buji Değişimi", 300m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Islemler_AracID",
                table: "Islemler",
                column: "AracID");

            migrationBuilder.CreateIndex(
                name: "IX_Islemler_AraclarAracID",
                table: "Islemler",
                column: "AraclarAracID");

            migrationBuilder.CreateIndex(
                name: "IX_Islemler_BakimID",
                table: "Islemler",
                column: "BakimID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Islemler");

            migrationBuilder.DropTable(
                name: "Kisiler");

            migrationBuilder.DropTable(
                name: "Araclar");

            migrationBuilder.DropTable(
                name: "BakimFiyatlari");
        }
    }
}
