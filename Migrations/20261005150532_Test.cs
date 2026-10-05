using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssociationId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Associations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Associations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Champions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChampionRiotName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Split = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssociationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Split = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    DivisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Associations_AssociationId",
                        column: x => x.AssociationId,
                        principalTable: "Associations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTeams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCaptain = table.Column<bool>(type: "bit", nullable: false),
                    IsCoach = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerTeams_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DivisionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stage = table.Column<int>(type: "int", nullable: false),
                    Round = table.Column<int>(type: "int", nullable: false),
                    IsUpper = table.Column<bool>(type: "bit", nullable: false),
                    Team1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Team2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Team1Score = table.Column<int>(type: "int", nullable: false),
                    Team2Score = table.Column<int>(type: "int", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tie = table.Column<bool>(type: "bit", nullable: false),
                    ScheduledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Played = table.Column<bool>(type: "bit", nullable: false),
                    Forfeit = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Series_Teams_Team1Id",
                        column: x => x.Team1Id,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Series_Teams_Team2Id",
                        column: x => x.Team2Id,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Series_Teams_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlueTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RedTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstDragonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstBaronId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstTowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Forfeit = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_BlueTeamId",
                        column: x => x.BlueTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_FirstBaronId",
                        column: x => x.FirstBaronId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Teams_FirstDragonId",
                        column: x => x.FirstDragonId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Teams_FirstTowerId",
                        column: x => x.FirstTowerId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Matches_Teams_RedTeamId",
                        column: x => x.RedTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_WinnerId",
                        column: x => x.WinnerId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OpponentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false),
                    ChampionId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    CreepScore = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    DamageTaken = table.Column<int>(type: "int", nullable: false),
                    Gold = table.Column<int>(type: "int", nullable: false),
                    VisionScore = table.Column<int>(type: "int", nullable: false),
                    DoubleKills = table.Column<int>(type: "int", nullable: false),
                    TripleKills = table.Column<int>(type: "int", nullable: false),
                    QuadraKills = table.Column<int>(type: "int", nullable: false),
                    PentaKills = table.Column<int>(type: "int", nullable: false),
                    KillParticipation = table.Column<float>(type: "real", nullable: false),
                    DamagePercentage = table.Column<float>(type: "real", nullable: false),
                    GoldPercentage = table.Column<float>(type: "real", nullable: false),
                    FirstBloodAssist = table.Column<bool>(type: "bit", nullable: false),
                    FirstBloodKill = table.Column<bool>(type: "bit", nullable: false),
                    Win = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerMatches_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMatches_Players_OpponentId",
                        column: x => x.OpponentId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerMatches_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMatches_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_AssociationId",
                table: "Players",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_BlueTeamId",
                table: "Matches",
                column: "BlueTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_FirstBaronId",
                table: "Matches",
                column: "FirstBaronId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_FirstDragonId",
                table: "Matches",
                column: "FirstDragonId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_FirstTowerId",
                table: "Matches",
                column: "FirstTowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_RedTeamId",
                table: "Matches",
                column: "RedTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SeriesId",
                table: "Matches",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinnerId",
                table: "Matches",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatches_ChampionId",
                table: "PlayerMatches",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatches_MatchId",
                table: "PlayerMatches",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatches_OpponentId",
                table: "PlayerMatches",
                column: "OpponentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatches_PlayerId",
                table: "PlayerMatches",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatches_TeamId",
                table: "PlayerMatches",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_PlayerId",
                table: "PlayerTeams",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeams_TeamId",
                table: "PlayerTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_DivisionId",
                table: "Series",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_Team1Id",
                table: "Series",
                column: "Team1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Series_Team2Id",
                table: "Series",
                column: "Team2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Series_WinnerId",
                table: "Series",
                column: "WinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_AssociationId",
                table: "Teams",
                column: "AssociationId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_DivisionId",
                table: "Teams",
                column: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Associations_AssociationId",
                table: "Players",
                column: "AssociationId",
                principalTable: "Associations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Associations_AssociationId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "PlayerMatches");

            migrationBuilder.DropTable(
                name: "PlayerTeams");

            migrationBuilder.DropTable(
                name: "Champions");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Associations");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Players_AssociationId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AssociationId",
                table: "Players");
        }
    }
}
