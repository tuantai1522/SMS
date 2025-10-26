using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitializeChannelFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "channels",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    display_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: true),
                    team_id = table.Column<Guid>(type: "uuid", nullable: false),
                    deleted_at = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_channels", x => x.id);
                    table.ForeignKey(
                        name: "fk_channels_teams_team_id",
                        column: x => x.team_id,
                        principalSchema: "sms",
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "channel_members",
                schema: "sms",
                columns: table => new
                {
                    channel_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: true),
                    deleted_at = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_channel_members", x => new { x.channel_id, x.user_id });
                    table.ForeignKey(
                        name: "fk_channel_members_channels_channel_id",
                        column: x => x.channel_id,
                        principalSchema: "sms",
                        principalTable: "channels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_channel_members_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "sms",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_channel_members_user_id",
                schema: "sms",
                table: "channel_members",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_channels_team_id",
                schema: "sms",
                table: "channels",
                column: "team_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "channel_members",
                schema: "sms");

            migrationBuilder.DropTable(
                name: "channels",
                schema: "sms");
        }
    }
}
