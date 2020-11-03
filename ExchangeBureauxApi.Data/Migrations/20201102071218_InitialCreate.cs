using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExchangeBureauxApi.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Identifier = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 250, nullable: false),
                    LastName = table.Column<string>(maxLength: 250, nullable: false),
                    Username = table.Column<string>(maxLength: 250, nullable: false),
                    Email = table.Column<string>(maxLength: 250, nullable: false),
                    Password = table.Column<string>(maxLength: 250, nullable: false),
                    Address = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyExchanges",
                columns: table => new
                {
                    CurrencyExchangeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    InverseConversionValue = table.Column<double>(nullable: false),
                    ConversionValue = table.Column<double>(nullable: false),
                    CurrencyFromId = table.Column<int>(nullable: false),
                    CurrencyToId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyExchanges", x => x.CurrencyExchangeId);
                    table.ForeignKey(
                        name: "FK_CurrencyExchanges_Currencies_CurrencyFromId",
                        column: x => x.CurrencyFromId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId");
                    table.ForeignKey(
                        name: "FK_CurrencyExchanges_Currencies_CurrencyToId",
                        column: x => x.CurrencyToId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId");
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyId", "CreatedBy", "CreatedDate", "Identifier", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 11, 2, 4, 12, 18, 50, DateTimeKind.Local).AddTicks(7153), "USD", "DOLAR", null, null },
                    { 2, 1, new DateTime(2020, 11, 2, 4, 12, 18, 50, DateTimeKind.Local).AddTicks(7277), "BRL", "REAL", null, null },
                    { 3, 1, new DateTime(2020, 11, 2, 4, 12, 18, 50, DateTimeKind.Local).AddTicks(7280), "ARS", "PESO ARGENTINO", null, null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "CreatedBy", "CreatedDate", "Email", "FirstName", "LastName", "Password", "UpdatedBy", "UpdatedDate", "Username" },
                values: new object[] { 1, "Rivadavia", 1, new DateTime(2020, 11, 2, 4, 12, 18, 38, DateTimeKind.Local).AddTicks(5070), "lisandrochichi@gmail.com", "Lisandro", "Chichi", "AQAAAAEAACcQAAAAEMeKl8RaiTOOjSJc1l7aQRGGHSs/w7HfS0gDEN6CWpGsDVVEQGpiO+0ldE3oGxTMYw==", null, null, "LisandroAdmin" });

            migrationBuilder.InsertData(
                table: "CurrencyExchanges",
                columns: new[] { "CurrencyExchangeId", "ConversionValue", "CreatedBy", "CreatedDate", "CurrencyFromId", "CurrencyToId", "InverseConversionValue", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 83.859999999999999, 1, new DateTime(2020, 11, 2, 4, 12, 18, 51, DateTimeKind.Local).AddTicks(7848), 3, 1, 77.469999999999999, null, null },
                    { 2, 77.469999999999999, 1, new DateTime(2020, 11, 2, 4, 12, 18, 51, DateTimeKind.Local).AddTicks(7907), 1, 3, 83.859999999999999, null, null },
                    { 3, 14.039999999999999, 1, new DateTime(2020, 11, 2, 4, 12, 18, 51, DateTimeKind.Local).AddTicks(7941), 3, 2, 12.529999999999999, null, null },
                    { 4, 12.529999999999999, 1, new DateTime(2020, 11, 2, 4, 12, 18, 51, DateTimeKind.Local).AddTicks(7942), 2, 3, 14.039999999999999, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchanges_CurrencyFromId",
                table: "CurrencyExchanges",
                column: "CurrencyFromId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchanges_CurrencyToId",
                table: "CurrencyExchanges",
                column: "CurrencyToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyExchanges");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
