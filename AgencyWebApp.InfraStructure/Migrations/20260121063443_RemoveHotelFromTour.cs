using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgencyWebApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveHotelFromTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Hotels_HotelId",
                table: "Tours");

            migrationBuilder.DropIndex(
                name: "IX_Tours_HotelId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Tours");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$DYv/aIw4.MZ1Nxm.LjFoie0cC4P5oWAFbUeHlmb5HTNuVuER.pGDu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$DYv/aIw4.MZ1Nxm.LjFoie0cC4P5oWAFbUeHlmb5HTNuVuER.pGDu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$DYv/aIw4.MZ1Nxm.LjFoie0cC4P5oWAFbUeHlmb5HTNuVuER.pGDu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$DYv/aIw4.MZ1Nxm.LjFoie0cC4P5oWAFbUeHlmb5HTNuVuER.pGDu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$DYv/aIw4.MZ1Nxm.LjFoie0cC4P5oWAFbUeHlmb5HTNuVuER.pGDu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$DYv/aIw4.MZ1Nxm.LjFoie0cC4P5oWAFbUeHlmb5HTNuVuER.pGDu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$DYv/aIw4.MZ1Nxm.LjFoie0cC4P5oWAFbUeHlmb5HTNuVuER.pGDu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$DYv/aIw4.MZ1Nxm.LjFoie0cC4P5oWAFbUeHlmb5HTNuVuER.pGDu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$DYv/aIw4.MZ1Nxm.LjFoie0cC4P5oWAFbUeHlmb5HTNuVuER.pGDu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$DYv/aIw4.MZ1Nxm.LjFoie0cC4P5oWAFbUeHlmb5HTNuVuER.pGDu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 1,
                column: "HotelId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 2,
                column: "HotelId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 3,
                column: "HotelId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 4,
                column: "HotelId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 5,
                column: "HotelId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 6,
                column: "HotelId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 7,
                column: "HotelId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 8,
                column: "HotelId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 9,
                column: "HotelId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Tours",
                keyColumn: "Id",
                keyValue: 10,
                column: "HotelId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$TQlTnjoNu3KkexaVhmS3J.4UV7uPknqXR2e2XaMDdKNaNbNU14Tje");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_HotelId",
                table: "Tours",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Hotels_HotelId",
                table: "Tours",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
