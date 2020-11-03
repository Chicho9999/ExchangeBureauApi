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
                name: "Logs",
                columns: table => new
                {
                    LogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Aplication = table.Column<string>(maxLength: 50, nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Message = table.Column<string>(maxLength: 250, nullable: false),
                    Exception = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogId);
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

            migrationBuilder.CreateTable(
                name: "LimitPucharses",
                columns: table => new
                {
                    LimitPucharseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    MaxAmountToBuy = table.Column<double>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LimitPucharses", x => x.LimitPucharseId);
                    table.ForeignKey(
                        name: "FK_LimitPucharses_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LimitPucharses_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    AmountToConvert = table.Column<double>(nullable: false),
                    AmountConverted = table.Column<double>(nullable: false),
                    CurrencyFromId = table.Column<int>(nullable: false),
                    CurrencyToId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Currencies_CurrencyFromId",
                        column: x => x.CurrencyFromId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId");
                    table.ForeignKey(
                        name: "FK_Transactions_Currencies_CurrencyToId",
                        column: x => x.CurrencyToId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId");
                    table.ForeignKey(
                        name: "FK_Transactions_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "CurrencyId", "CreatedBy", "CreatedDate", "Identifier", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 11, 3, 1, 58, 22, 380, DateTimeKind.Local).AddTicks(4278), "USD", "DOLAR", null, null },
                    { 2, 1, new DateTime(2020, 11, 3, 1, 58, 22, 380, DateTimeKind.Local).AddTicks(4356), "BRL", "REAL", null, null },
                    { 3, 1, new DateTime(2020, 11, 3, 1, 58, 22, 380, DateTimeKind.Local).AddTicks(4359), "ARS", "PESO ARGENTINO", null, null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Address", "CreatedBy", "CreatedDate", "Email", "FirstName", "LastName", "Password", "UpdatedBy", "UpdatedDate", "Username" },
                values: new object[] { 1, "Rivadavia", 1, new DateTime(2020, 11, 3, 1, 58, 22, 365, DateTimeKind.Local).AddTicks(4749), "lisandrochichi@gmail.com", "Lisandro", "Chichi", "AQAAAAEAACcQAAAAENifjnZD+fdhUcYfdbVZLDO4naFlki2bfYG7dGZvNwSmZPCWvoaEEb4tVMhAeCxgog==", null, null, "LisandroAdmin" });

            migrationBuilder.InsertData(
                table: "CurrencyExchanges",
                columns: new[] { "CurrencyExchangeId", "ConversionValue", "CreatedBy", "CreatedDate", "CurrencyFromId", "CurrencyToId", "InverseConversionValue", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 83.859999999999999, 1, new DateTime(2020, 11, 3, 1, 58, 22, 380, DateTimeKind.Local).AddTicks(8233), 3, 1, 77.469999999999999, null, null },
                    { 2, 77.469999999999999, 1, new DateTime(2020, 11, 3, 1, 58, 22, 380, DateTimeKind.Local).AddTicks(8285), 1, 3, 83.859999999999999, null, null },
                    { 3, 14.039999999999999, 1, new DateTime(2020, 11, 3, 1, 58, 22, 380, DateTimeKind.Local).AddTicks(8287), 3, 2, 12.529999999999999, null, null },
                    { 4, 12.529999999999999, 1, new DateTime(2020, 11, 3, 1, 58, 22, 380, DateTimeKind.Local).AddTicks(8289), 2, 3, 14.039999999999999, null, null }
                });

            migrationBuilder.InsertData(
                table: "LimitPucharses",
                columns: new[] { "LimitPucharseId", "CreatedBy", "CreatedDate", "CurrencyId", "MaxAmountToBuy", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 11, 3, 1, 58, 22, 380, DateTimeKind.Local).AddTicks(6212), 1, 200.0, null, null, 1 },
                    { 2, 1, new DateTime(2020, 11, 3, 1, 58, 22, 380, DateTimeKind.Local).AddTicks(6267), 2, 300.0, null, null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchanges_CurrencyFromId",
                table: "CurrencyExchanges",
                column: "CurrencyFromId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyExchanges_CurrencyToId",
                table: "CurrencyExchanges",
                column: "CurrencyToId");

            migrationBuilder.CreateIndex(
                name: "IX_LimitPucharses_CurrencyId",
                table: "LimitPucharses",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_LimitPucharses_UserId",
                table: "LimitPucharses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CurrencyFromId",
                table: "Transactions",
                column: "CurrencyFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CurrencyToId",
                table: "Transactions",
                column: "CurrencyToId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyExchanges");

            migrationBuilder.DropTable(
                name: "LimitPucharses");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
