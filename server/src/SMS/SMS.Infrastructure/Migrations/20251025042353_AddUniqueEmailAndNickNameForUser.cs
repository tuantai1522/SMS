using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueEmailAndNickNameForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                schema: "sms",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_nick_name",
                schema: "sms",
                table: "users",
                column: "nick_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_users_email",
                schema: "sms",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_users_nick_name",
                schema: "sms",
                table: "users");
        }
    }
}
