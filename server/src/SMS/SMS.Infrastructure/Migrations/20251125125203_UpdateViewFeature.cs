using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateViewFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "role_permissions",
                schema: "sms");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "sms");

            migrationBuilder.CreateTable(
                name: "views",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    code = table.Column<int>(type: "integer", nullable: false),
                    vid = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    is_menu = table.Column<bool>(type: "boolean", nullable: false),
                    AllowRead = table.Column<int>(type: "integer", nullable: false),
                    AllowUpdate = table.Column<int>(type: "integer", nullable: false),
                    AllowDelete = table.Column<int>(type: "integer", nullable: false),
                    AllowCreate = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_views", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "view_roles",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    view_id = table.Column<Guid>(type: "uuid", nullable: false),
                    AllowRead = table.Column<int>(type: "integer", nullable: false),
                    AllowUpdate = table.Column<int>(type: "integer", nullable: false),
                    AllowDelete = table.Column<int>(type: "integer", nullable: false),
                    AllowCreate = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_view_roles", x => x.id);
                    table.ForeignKey(
                        name: "fk_view_roles_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "sms",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_view_roles_views_view_id",
                        column: x => x.view_id,
                        principalSchema: "sms",
                        principalTable: "views",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_view_roles_role_id",
                schema: "sms",
                table: "view_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_view_roles_view_id",
                schema: "sms",
                table: "view_roles",
                column: "view_id");

            migrationBuilder.CreateIndex(
                name: "ix_views_name",
                schema: "sms",
                table: "views",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_views_vid",
                schema: "sms",
                table: "views",
                column: "vid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "view_roles",
                schema: "sms");

            migrationBuilder.DropTable(
                name: "views",
                schema: "sms");

            migrationBuilder.CreateTable(
                name: "permissions",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    permission_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_permissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_permissions_permissions_permission_id",
                        column: x => x.permission_id,
                        principalSchema: "sms",
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_role_permissions_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "sms",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_permissions_name",
                schema: "sms",
                table: "permissions",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_role_permissions_permission_id",
                schema: "sms",
                table: "role_permissions",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_permissions_role_id",
                schema: "sms",
                table: "role_permissions",
                column: "role_id");
        }
    }
}
