using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitializeTaskFeatureDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "roles",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "task_priorities",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task_priorities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "task_statuses",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_task_statuses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workspaces",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    invitation_code = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workspaces", x => x.id);
                    table.ForeignKey(
                        name: "fk_workspaces_users_owner_id",
                        column: x => x.owner_id,
                        principalSchema: "sms",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_permissions",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    permission_id = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "projects",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    code = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    emoji = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    workspace_id = table.Column<Guid>(type: "uuid", nullable: false),
                    creator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: true),
                    deleted_at = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projects", x => x.id);
                    table.ForeignKey(
                        name: "fk_projects_users_creator_id",
                        column: x => x.creator_id,
                        principalSchema: "sms",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projects_workspaces_workspace_id",
                        column: x => x.workspace_id,
                        principalSchema: "sms",
                        principalTable: "workspaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workspace_members",
                schema: "sms",
                columns: table => new
                {
                    workspace_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: true),
                    deleted_at = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workspace_members", x => new { x.workspace_id, x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_workspace_members_roles_role_id",
                        column: x => x.role_id,
                        principalSchema: "sms",
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workspace_members_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "sms",
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workspace_members_workspaces_workspace_id",
                        column: x => x.workspace_id,
                        principalSchema: "sms",
                        principalTable: "workspaces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                schema: "sms",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    code = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    project_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    priority_id = table.Column<Guid>(type: "uuid", nullable: false),
                    assigned_to = table.Column<Guid>(type: "uuid", nullable: true),
                    creator_id = table.Column<Guid>(type: "uuid", nullable: false),
                    start_date = table.Column<long>(type: "bigint", nullable: true),
                    due_date = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<long>(type: "bigint", nullable: false),
                    updated_at = table.Column<long>(type: "bigint", nullable: true),
                    deleted_at = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tasks", x => x.id);
                    table.ForeignKey(
                        name: "fk_tasks_projects_project_id",
                        column: x => x.project_id,
                        principalSchema: "sms",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tasks_task_priorities_priority_id",
                        column: x => x.priority_id,
                        principalSchema: "sms",
                        principalTable: "task_priorities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tasks_task_statuses_status_id",
                        column: x => x.status_id,
                        principalSchema: "sms",
                        principalTable: "task_statuses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_tasks_users_assigned_to",
                        column: x => x.assigned_to,
                        principalSchema: "sms",
                        principalTable: "users",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_tasks_users_creator_id",
                        column: x => x.creator_id,
                        principalSchema: "sms",
                        principalTable: "users",
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
                name: "ix_projects_creator_id",
                schema: "sms",
                table: "projects",
                column: "creator_id");

            migrationBuilder.CreateIndex(
                name: "ix_projects_workspace_id",
                schema: "sms",
                table: "projects",
                column: "workspace_id");

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

            migrationBuilder.CreateIndex(
                name: "ix_roles_name",
                schema: "sms",
                table: "roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_task_priorities_name",
                schema: "sms",
                table: "task_priorities",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_task_statuses_name",
                schema: "sms",
                table: "task_statuses",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tasks_assigned_to",
                schema: "sms",
                table: "tasks",
                column: "assigned_to");

            migrationBuilder.CreateIndex(
                name: "ix_tasks_creator_id",
                schema: "sms",
                table: "tasks",
                column: "creator_id");

            migrationBuilder.CreateIndex(
                name: "ix_tasks_priority_id",
                schema: "sms",
                table: "tasks",
                column: "priority_id");

            migrationBuilder.CreateIndex(
                name: "ix_tasks_project_id",
                schema: "sms",
                table: "tasks",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "ix_tasks_status_id",
                schema: "sms",
                table: "tasks",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_workspace_members_role_id",
                schema: "sms",
                table: "workspace_members",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_workspace_members_user_id",
                schema: "sms",
                table: "workspace_members",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_workspaces_invitation_code",
                schema: "sms",
                table: "workspaces",
                column: "invitation_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_workspaces_owner_id",
                schema: "sms",
                table: "workspaces",
                column: "owner_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "role_permissions",
                schema: "sms");

            migrationBuilder.DropTable(
                name: "tasks",
                schema: "sms");

            migrationBuilder.DropTable(
                name: "workspace_members",
                schema: "sms");

            migrationBuilder.DropTable(
                name: "permissions",
                schema: "sms");

            migrationBuilder.DropTable(
                name: "projects",
                schema: "sms");

            migrationBuilder.DropTable(
                name: "task_priorities",
                schema: "sms");

            migrationBuilder.DropTable(
                name: "task_statuses",
                schema: "sms");

            migrationBuilder.DropTable(
                name: "roles",
                schema: "sms");

            migrationBuilder.DropTable(
                name: "workspaces",
                schema: "sms");
        }
    }
}
