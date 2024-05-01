using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marvin.IDP.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountActivation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("40877bff-7fd8-4974-b3f6-c824f0e4bdf4"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("422ab22e-1d85-4ee9-a6d5-8aae8073e550"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("48158c5c-e11f-4cc3-8a14-27a0a664042a"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("4f1c8c61-4527-45fa-9aa0-cdeea4ae1cb6"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("bc8df8d9-4c5c-4d7d-9a1b-74efa7099633"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("ec329b7c-ed3b-46eb-b303-a87815cff8db"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("ed120c77-1921-4316-9967-5494147e5a6c"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("fe2af8d7-2750-469d-af64-2a0a417cb9e2"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SecurityCodeExpirationDate",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("39a79f38-3de7-4c20-917e-d9087c3c122e"), "b9d24e77-05e8-4b94-b053-fd3aeaf1a525", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("39cbb109-cbd7-4179-9fdc-34ea883ac924"), "c6b2085a-4fc2-4c8d-b104-40ead5b7c9e4", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("4f7813a1-c66f-4466-8a03-bd16e23900a3"), "e7d690f0-9cd6-4464-9035-7030e2c5596a", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("676ad05e-8b3c-464a-a8aa-65875d52f640"), "338ab4f2-9eb4-43da-8a93-300df261e6b4", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("6c2f2080-6359-4fa6-a2e7-f42080846c3b"), "d2f9eddd-9011-4fa4-ac0c-372a0a8fe5bf", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("96c4cfa0-6a2d-4a2a-9148-16119488a10c"), "f235390a-781d-481c-b6b7-25b669172f25", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("e0d62c60-1fe2-477a-8e59-d6f5e10d87d0"), "d98216bb-2221-47d7-b92f-8cbb797ec291", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("fc0263ec-6197-40f4-a16c-642a6a7cdf12"), "c32a19cc-b18d-4e63-ae54-451ebf6855a1", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityCode", "SecurityCodeExpirationDate" },
                values: new object[] { "4b215234-0d76-474e-884e-31cf1a59a0d9", "david@someprovider.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityCode", "SecurityCodeExpirationDate" },
                values: new object[] { "5ca99957-417c-4be4-a9f4-d5775ecece87", "emma@someprovider.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("39a79f38-3de7-4c20-917e-d9087c3c122e"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("39cbb109-cbd7-4179-9fdc-34ea883ac924"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("4f7813a1-c66f-4466-8a03-bd16e23900a3"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("676ad05e-8b3c-464a-a8aa-65875d52f640"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("6c2f2080-6359-4fa6-a2e7-f42080846c3b"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("96c4cfa0-6a2d-4a2a-9148-16119488a10c"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e0d62c60-1fe2-477a-8e59-d6f5e10d87d0"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("fc0263ec-6197-40f4-a16c-642a6a7cdf12"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCodeExpirationDate",
                table: "Users");

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("40877bff-7fd8-4974-b3f6-c824f0e4bdf4"), "abab5a8c-f286-43d3-a4d7-8e2b73425390", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("422ab22e-1d85-4ee9-a6d5-8aae8073e550"), "68a8ca1b-c0e5-4bd4-80a9-9e229c2b9d66", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("48158c5c-e11f-4cc3-8a14-27a0a664042a"), "c4399d7f-7024-47c8-829f-7cb0f463a525", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("4f1c8c61-4527-45fa-9aa0-cdeea4ae1cb6"), "7bb6a2b6-d00c-47d5-8457-263a2970cf92", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("bc8df8d9-4c5c-4d7d-9a1b-74efa7099633"), "d2c91e2c-d8da-4472-a59f-217ede93ce21", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("ec329b7c-ed3b-46eb-b303-a87815cff8db"), "5caf11c2-5779-42e7-aa04-2d5e64ed0212", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("ed120c77-1921-4316-9967-5494147e5a6c"), "d92e075e-cc88-48da-a28d-43dc8b9056ec", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("fe2af8d7-2750-469d-af64-2a0a417cb9e2"), "d5cde4c7-30c3-4f4d-b984-643ba582be11", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "f4d2ae21-c0c2-4a30-8386-f459dc0bb7b5");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "7d51b365-ad05-489d-ae4d-97aa9664430e");
        }
    }
}
