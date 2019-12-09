using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Business360.sso.Data.Migrations
{
    public partial class intializeDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SsoApis",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Enabled = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ApiSecrets = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SsoApis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SsoScopes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Required = table.Column<bool>(nullable: false),
                    Emphasize = table.Column<bool>(nullable: false),
                    ShowInDiscoveryDocument = table.Column<string>(nullable: true),
                    SsoApiId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SsoScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SsoScopes_SsoApis_SsoApiId",
                        column: x => x.SsoApiId,
                        principalTable: "SsoApis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SsoClaims",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OwnerId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SsoClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SsoClaims_SsoApis_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "SsoApis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SsoClaims_SsoScopes_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "SsoScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SsoClaims_OwnerId",
                table: "SsoClaims",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SsoScopes_SsoApiId",
                table: "SsoScopes",
                column: "SsoApiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SsoClaims");

            migrationBuilder.DropTable(
                name: "SsoScopes");

            migrationBuilder.DropTable(
                name: "SsoApis");
        }
    }
}
