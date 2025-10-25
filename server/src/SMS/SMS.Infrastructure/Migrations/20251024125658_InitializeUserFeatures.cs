using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitializeUserFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    middle_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    last_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    nick_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    password = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: true),
                    gender_type = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    street = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    city_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_addresses", x => x.id);
                    table.ForeignKey(
                        name: "fk_addresses_cities_city_id",
                        column: x => x.city_id,
                        principalSchema: "sms",
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_addresses_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "sms",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_addresses_city_id",
                schema: "sms",
                table: "addresses",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_addresses_user_id",
                schema: "sms",
                table: "addresses",
                column: "user_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses",
                schema: "sms");

            migrationBuilder.DropTable(
                name: "users",
                schema: "sms");
        }
    }
}
