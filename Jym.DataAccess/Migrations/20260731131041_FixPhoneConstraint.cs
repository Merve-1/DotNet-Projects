using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jym.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixPhoneConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Phone",
                table: "Users");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Phone",
                table: "Users",
                sql: "[Phone] LIKE '01[0125][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_User_Phone",
                table: "Users");

            migrationBuilder.AddCheckConstraint(
                name: "CK_User_Phone",
                table: "Users",
                sql: "LEN([Phone]) LIKE '01[0125]%'");
        }
    }
}
