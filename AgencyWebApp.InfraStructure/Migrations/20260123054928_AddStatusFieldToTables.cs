using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgencyWebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusFieldToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 10,
                column: "Status",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$RFSOOYEA.tpejpq8VE0miuEEBYGnfOLcmESifkA4.d6cXY7zUbHmq");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Hotels");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$EryMWrrLbkMLbJCdTKQS2uId4H9n4N16xf/4pVH8tPlBmDy6vl.zm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$EryMWrrLbkMLbJCdTKQS2uId4H9n4N16xf/4pVH8tPlBmDy6vl.zm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$EryMWrrLbkMLbJCdTKQS2uId4H9n4N16xf/4pVH8tPlBmDy6vl.zm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$EryMWrrLbkMLbJCdTKQS2uId4H9n4N16xf/4pVH8tPlBmDy6vl.zm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$EryMWrrLbkMLbJCdTKQS2uId4H9n4N16xf/4pVH8tPlBmDy6vl.zm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$EryMWrrLbkMLbJCdTKQS2uId4H9n4N16xf/4pVH8tPlBmDy6vl.zm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$EryMWrrLbkMLbJCdTKQS2uId4H9n4N16xf/4pVH8tPlBmDy6vl.zm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$EryMWrrLbkMLbJCdTKQS2uId4H9n4N16xf/4pVH8tPlBmDy6vl.zm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$EryMWrrLbkMLbJCdTKQS2uId4H9n4N16xf/4pVH8tPlBmDy6vl.zm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$EryMWrrLbkMLbJCdTKQS2uId4H9n4N16xf/4pVH8tPlBmDy6vl.zm");
        }
    }
}
