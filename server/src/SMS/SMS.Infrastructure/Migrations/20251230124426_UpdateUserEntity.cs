using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses",
                schema: "sms");

            migrationBuilder.DropTable(
                name: "cities",
                schema: "sms");

            migrationBuilder.DropIndex(
                name: "ix_users_nick_name",
                schema: "sms",
                table: "users");

            migrationBuilder.DropColumn(
                name: "date_of_birth",
                schema: "sms",
                table: "users");

            migrationBuilder.DropColumn(
                name: "first_name",
                schema: "sms",
                table: "users");

            migrationBuilder.DropColumn(
                name: "last_name",
                schema: "sms",
                table: "users");

            migrationBuilder.DropColumn(
                name: "middle_name",
                schema: "sms",
                table: "users");

            migrationBuilder.DropColumn(
                name: "nick_name",
                schema: "sms",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "gender_type",
                schema: "sms",
                table: "users",
                newName: "status");

            migrationBuilder.AddColumn<string>(
                name: "verification_token",
                schema: "sms",
                table: "users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "verification_token_expired_at",
                schema: "sms",
                table: "users",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "user_profiles",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    given_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: true),
                    avatar_url = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    gender_type = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    country_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_profiles", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_profiles_countries_country_id",
                        column: x => x.country_id,
                        principalSchema: "sms",
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_profiles_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "sms",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_signins",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    provider_type = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    provider_key = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    provider_email = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_signins", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_signins_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "sms",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_user_profiles_country_id",
                schema: "sms",
                table: "user_profiles",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_profiles_given_name",
                schema: "sms",
                table: "user_profiles",
                column: "given_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_profiles_user_id",
                schema: "sms",
                table: "user_profiles",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_signins_user_id",
                schema: "sms",
                table: "user_signins",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_profiles",
                schema: "sms");

            migrationBuilder.DropTable(
                name: "user_signins",
                schema: "sms");

            migrationBuilder.DropColumn(
                name: "verification_token",
                schema: "sms",
                table: "users");

            migrationBuilder.DropColumn(
                name: "verification_token_expired_at",
                schema: "sms",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "status",
                schema: "sms",
                table: "users",
                newName: "gender_type");

            migrationBuilder.AddColumn<DateOnly>(
                name: "date_of_birth",
                schema: "sms",
                table: "users",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "first_name",
                schema: "sms",
                table: "users",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                schema: "sms",
                table: "users",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "middle_name",
                schema: "sms",
                table: "users",
                type: "character varying(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nick_name",
                schema: "sms",
                table: "users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "cities",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    country_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cities", x => x.id);
                    table.ForeignKey(
                        name: "fk_cities_countries_country_id",
                        column: x => x.country_id,
                        principalSchema: "sms",
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    city_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    street = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
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
                name: "ix_users_nick_name",
                schema: "sms",
                table: "users",
                column: "nick_name",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "ix_cities_country_id",
                schema: "sms",
                table: "cities",
                column: "country_id");
        }
    }
}
