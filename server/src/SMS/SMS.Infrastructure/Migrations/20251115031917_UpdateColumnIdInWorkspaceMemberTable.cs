using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnIdInWorkspaceMemberTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_workspace_members",
                schema: "sms",
                table: "workspace_members");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                schema: "sms",
                table: "workspace_members",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "pk_workspace_members",
                schema: "sms",
                table: "workspace_members",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_workspace_members_workspace_id",
                schema: "sms",
                table: "workspace_members",
                column: "workspace_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_workspace_members",
                schema: "sms",
                table: "workspace_members");

            migrationBuilder.DropIndex(
                name: "ix_workspace_members_workspace_id",
                schema: "sms",
                table: "workspace_members");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "sms",
                table: "workspace_members");

            migrationBuilder.AddPrimaryKey(
                name: "pk_workspace_members",
                schema: "sms",
                table: "workspace_members",
                columns: new[] { "workspace_id", "user_id", "role_id" });
        }
    }
}
