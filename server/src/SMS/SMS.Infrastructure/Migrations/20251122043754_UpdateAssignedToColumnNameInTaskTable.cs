using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAssignedToColumnNameInTaskTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tasks_users_assigned_to",
                schema: "sms",
                table: "tasks");

            migrationBuilder.RenameColumn(
                name: "assigned_to",
                schema: "sms",
                table: "tasks",
                newName: "assigned_to_id");

            migrationBuilder.RenameIndex(
                name: "ix_tasks_assigned_to",
                schema: "sms",
                table: "tasks",
                newName: "ix_tasks_assigned_to_id");

            migrationBuilder.AddForeignKey(
                name: "fk_tasks_users_assigned_to_id",
                schema: "sms",
                table: "tasks",
                column: "assigned_to_id",
                principalSchema: "sms",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tasks_users_assigned_to_id",
                schema: "sms",
                table: "tasks");

            migrationBuilder.RenameColumn(
                name: "assigned_to_id",
                schema: "sms",
                table: "tasks",
                newName: "assigned_to");

            migrationBuilder.RenameIndex(
                name: "ix_tasks_assigned_to_id",
                schema: "sms",
                table: "tasks",
                newName: "ix_tasks_assigned_to");

            migrationBuilder.AddForeignKey(
                name: "fk_tasks_users_assigned_to",
                schema: "sms",
                table: "tasks",
                column: "assigned_to",
                principalSchema: "sms",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
