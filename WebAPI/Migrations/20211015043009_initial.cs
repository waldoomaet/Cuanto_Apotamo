using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    TotalBets = table.Column<float>(type: "REAL", nullable: false),
                    TotalPlayers = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2021, 10, 15, 0, 30, 8, 930, DateTimeKind.Local).AddTicks(3499))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    IdentificationDocument = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    CreditCardNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CVV = table.Column<int>(type: "INTEGER", nullable: false),
                    CreditCardExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Balance = table.Column<float>(type: "REAL", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2021, 10, 15, 0, 30, 8, 938, DateTimeKind.Local).AddTicks(2610))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BetOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BetId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    TotalBets = table.Column<float>(type: "REAL", nullable: false),
                    TotalPlayers = table.Column<int>(type: "INTEGER", nullable: false),
                    Stake = table.Column<float>(type: "REAL", nullable: false),
                    DidWin = table.Column<bool>(type: "INTEGER", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2021, 10, 15, 0, 30, 8, 934, DateTimeKind.Local).AddTicks(7608))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BetOptions_Bets_BetId",
                        column: x => x.BetId,
                        principalTable: "Bets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BalanceTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    Balance = table.Column<float>(type: "REAL", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2021, 10, 15, 0, 30, 8, 915, DateTimeKind.Local).AddTicks(1539))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BalanceTransactions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BetOptionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<float>(type: "REAL", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2021, 10, 15, 0, 30, 8, 932, DateTimeKind.Local).AddTicks(6536))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBets_BetOptions_BetOptionId",
                        column: x => x.BetOptionId,
                        principalTable: "BetOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BalanceTransactions_UserID",
                table: "BalanceTransactions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_BetOptions_BetId",
                table: "BetOptions",
                column: "BetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBets_BetOptionId",
                table: "UserBets",
                column: "BetOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBets_UserId",
                table: "UserBets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalanceTransactions");

            migrationBuilder.DropTable(
                name: "UserBets");

            migrationBuilder.DropTable(
                name: "BetOptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Bets");
        }
    }
}
