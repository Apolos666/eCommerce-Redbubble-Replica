using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexforthesecolumnsIdentityUserIdPaymentTypeIdProviderAccountNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserPaymentMethods_IdentityUserId",
                table: "UserPaymentMethods");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentMethods_IdentityUserId_PaymentTypeId_Provider_AccountNumber",
                table: "UserPaymentMethods",
                columns: new[] { "IdentityUserId", "PaymentTypeId", "Provider", "AccountNumber" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserPaymentMethods_IdentityUserId_PaymentTypeId_Provider_AccountNumber",
                table: "UserPaymentMethods");

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentMethods_IdentityUserId",
                table: "UserPaymentMethods",
                column: "IdentityUserId");
        }
    }
}
