using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class diseaseattributesupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("19ed6134-f404-47b0-acd5-b28ca3a452cb"), new Guid("0eae02f2-8f6a-4393-a159-c7c68b87914c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f220a02f-d86d-46f5-8274-a11e7601b748"), new Guid("17090e6d-dc1d-41e3-b386-6946f7bf830f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("428009e0-0ac7-4b42-b01a-094c6d1972df"), new Guid("6f893589-24b0-4dde-9dbc-fed6fdf947da") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4f11a39b-27a1-42ed-862a-5f84fd60881f"), new Guid("72df9bc3-29f0-4eae-a56f-985ab2e30754") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("906cd0ef-b21d-4ad6-9cc2-283d9962a71c"), new Guid("a703cbc1-2ab5-4113-b9a7-9f394b417ac8") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("19ed6134-f404-47b0-acd5-b28ca3a452cb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("428009e0-0ac7-4b42-b01a-094c6d1972df"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4f11a39b-27a1-42ed-862a-5f84fd60881f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("906cd0ef-b21d-4ad6-9cc2-283d9962a71c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f220a02f-d86d-46f5-8274-a11e7601b748"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0eae02f2-8f6a-4393-a159-c7c68b87914c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("17090e6d-dc1d-41e3-b386-6946f7bf830f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6f893589-24b0-4dde-9dbc-fed6fdf947da"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("72df9bc3-29f0-4eae-a56f-985ab2e30754"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a703cbc1-2ab5-4113-b9a7-9f394b417ac8"));

            migrationBuilder.AddColumn<string>(
                name: "Prevention",
                table: "Diseases",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Recommendation",
                table: "Diseases",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Symptoms",
                table: "Diseases",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("14368e8c-2a24-4fe9-999a-024086dd73e1"), "82442b94-4efe-452f-8581-b665f50efdcf", "Admin", "ADMIN" },
                    { new Guid("4f80ff37-cf53-4f49-af3e-9f611d7e7330"), "6002afb8-3ba7-4736-a1d1-ac56a02854b7", "Owner", "OWNER" },
                    { new Guid("59cdc955-f5c6-489a-8348-bff27410613d"), "651ee883-df2b-4904-8f3d-785991f946a2", "Manager", "MANAGER" },
                    { new Guid("65ac8382-6e61-4734-9d95-5738966560a2"), "f6d8d3cb-d9b7-4330-b577-6dffc26c3e54", "Collaborator", "COLLABORATOR" },
                    { new Guid("9026237a-1dfc-48e8-897e-c84c78feb1f5"), "52438a19-ca21-4a3a-b55d-3d9161fe9f91", "Consultant", "CONSULTANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("5b9b8f70-99cc-4f28-9eca-f47ec83f057e"), 0, "44f44886-36cc-4809-87c8-f2ea7958cf69", new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1835), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$KovIEQee1DlTs/eLvQd5E.xQ1ppA9A3Dl7Xwf8hHKWaAR2jHZzfpe", "(99) 99999-9992", false, "8c3017e5-f3d2-4522-8b6b-a2e4c295305c", 0, false, new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1815), "jane" },
                    { new Guid("6532d97e-6e87-4033-bd36-4fa873b471db"), 0, "7c51c246-640a-41f8-a195-d818915130cf", new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1848), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$yWf7N/ZC5dsV0QI9U1wKDuc6fPBwY3Ps6uEWVtV02tEjpIcx2toFW", "(99) 99999-9994", false, "e07871e9-0956-4882-acdf-6af22cc70962", 0, false, new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1845), "bob" },
                    { new Guid("c2e7440e-d11d-4622-a90f-a90b66a66e3b"), 0, "861cc077-8119-4592-8a2a-516e2fa1b3d0", new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1419), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$IDAadJTAUJ8DQAjuvteW.eehSnf1P7Vch88CnoVPpGRpuIq.ErAjS", "(99) 99999-9991", false, "614ea983-ec30-4c97-824a-5a4769620351", 0, false, new DateTime(2025, 9, 23, 17, 55, 25, 465, DateTimeKind.Local).AddTicks(9369), "john" },
                    { new Guid("dcc30bfd-feb8-421b-a928-7db9bcf45696"), 0, "6b4fc12a-404f-4df8-b54a-97f98eeffebb", new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1860), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$JQsX7J/y9DvlCmjAshQAlOV/ackGkJq6/ayNQb2gFQJz73VodogIq", "(99) 99999-9995", false, "7c072e77-2cef-4e87-be70-80e9b868d7e8", 0, false, new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1849), "charlie" },
                    { new Guid("e8bd43cf-53c8-41f0-b88a-636bc17c8c4d"), 0, "fcd3e3c8-db4d-4988-9063-a2b39c356f6c", new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1844), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$ZPMmuS9nSrgtdFL6TDP/xOltc4MC6IyrdR8ujqnTdinGAT6n7SzAa", "(99) 99999-9993", false, "013c6755-6236-4769-8a15-5a09dc7d107c", 0, false, new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1836), "alice" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4f80ff37-cf53-4f49-af3e-9f611d7e7330"), new Guid("5b9b8f70-99cc-4f28-9eca-f47ec83f057e") },
                    { new Guid("59cdc955-f5c6-489a-8348-bff27410613d"), new Guid("6532d97e-6e87-4033-bd36-4fa873b471db") },
                    { new Guid("14368e8c-2a24-4fe9-999a-024086dd73e1"), new Guid("c2e7440e-d11d-4622-a90f-a90b66a66e3b") },
                    { new Guid("65ac8382-6e61-4734-9d95-5738966560a2"), new Guid("dcc30bfd-feb8-421b-a928-7db9bcf45696") },
                    { new Guid("9026237a-1dfc-48e8-897e-c84c78feb1f5"), new Guid("e8bd43cf-53c8-41f0-b88a-636bc17c8c4d") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4f80ff37-cf53-4f49-af3e-9f611d7e7330"), new Guid("5b9b8f70-99cc-4f28-9eca-f47ec83f057e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("59cdc955-f5c6-489a-8348-bff27410613d"), new Guid("6532d97e-6e87-4033-bd36-4fa873b471db") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("14368e8c-2a24-4fe9-999a-024086dd73e1"), new Guid("c2e7440e-d11d-4622-a90f-a90b66a66e3b") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("65ac8382-6e61-4734-9d95-5738966560a2"), new Guid("dcc30bfd-feb8-421b-a928-7db9bcf45696") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9026237a-1dfc-48e8-897e-c84c78feb1f5"), new Guid("e8bd43cf-53c8-41f0-b88a-636bc17c8c4d") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("14368e8c-2a24-4fe9-999a-024086dd73e1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4f80ff37-cf53-4f49-af3e-9f611d7e7330"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("59cdc955-f5c6-489a-8348-bff27410613d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65ac8382-6e61-4734-9d95-5738966560a2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9026237a-1dfc-48e8-897e-c84c78feb1f5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5b9b8f70-99cc-4f28-9eca-f47ec83f057e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6532d97e-6e87-4033-bd36-4fa873b471db"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c2e7440e-d11d-4622-a90f-a90b66a66e3b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dcc30bfd-feb8-421b-a928-7db9bcf45696"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e8bd43cf-53c8-41f0-b88a-636bc17c8c4d"));

            migrationBuilder.DropColumn(
                name: "Prevention",
                table: "Diseases");

            migrationBuilder.DropColumn(
                name: "Recommendation",
                table: "Diseases");

            migrationBuilder.DropColumn(
                name: "Symptoms",
                table: "Diseases");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("19ed6134-f404-47b0-acd5-b28ca3a452cb"), "fbc1685b-9fd1-4b1c-8ec4-09d5e5976ba2", "Admin", "ADMIN" },
                    { new Guid("428009e0-0ac7-4b42-b01a-094c6d1972df"), "b8042736-ffa6-40eb-bd16-8874ffec756f", "Consultant", "CONSULTANT" },
                    { new Guid("4f11a39b-27a1-42ed-862a-5f84fd60881f"), "878cfd91-7d07-4b22-85c5-55555be9fc6b", "Collaborator", "COLLABORATOR" },
                    { new Guid("906cd0ef-b21d-4ad6-9cc2-283d9962a71c"), "3914d239-03ef-414b-b74a-c59281342f6c", "Owner", "OWNER" },
                    { new Guid("f220a02f-d86d-46f5-8274-a11e7601b748"), "0efd5ae5-560e-44f3-8cc8-addc741580ff", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("0eae02f2-8f6a-4393-a159-c7c68b87914c"), 0, "0c1a101c-0c0f-442b-a6c8-2a71254aacc8", new DateTime(2025, 9, 17, 23, 12, 3, 206, DateTimeKind.Local).AddTicks(296), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$pg6fTREf1Kk0x3k2Yk.7pekfRKMz44gnVDcofdY2bRwV12/i4hENS", "(99) 99999-9991", false, "0e5e7a83-4ad6-4bb8-9545-b75c6aa4806c", 0, false, new DateTime(2025, 9, 17, 23, 12, 3, 205, DateTimeKind.Local).AddTicks(5857), "john" },
                    { new Guid("17090e6d-dc1d-41e3-b386-6946f7bf830f"), 0, "963a67eb-347b-48c6-93c8-bc7263f18733", new DateTime(2025, 9, 17, 23, 12, 3, 206, DateTimeKind.Local).AddTicks(977), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$HIZ0KiLmOt1T590wXAvEculknNwXscoakvgyA12F4JPVBhUfYxVPW", "(99) 99999-9994", false, "ef9e91ed-ef61-4b5a-9afc-503eb50eab52", 0, false, new DateTime(2025, 9, 17, 23, 12, 3, 206, DateTimeKind.Local).AddTicks(971), "bob" },
                    { new Guid("6f893589-24b0-4dde-9dbc-fed6fdf947da"), 0, "9344a206-00d3-4e7c-b27a-7d7fc98566e1", new DateTime(2025, 9, 17, 23, 12, 3, 206, DateTimeKind.Local).AddTicks(970), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$9gRW8.2Axo2U.yrWD0dbvud2bJd5cEgnFu1VfIVZN3cwHOI4VKFle", "(99) 99999-9993", false, "009d1ee9-5745-42ed-bf17-9269251f042b", 0, false, new DateTime(2025, 9, 17, 23, 12, 3, 206, DateTimeKind.Local).AddTicks(946), "alice" },
                    { new Guid("72df9bc3-29f0-4eae-a56f-985ab2e30754"), 0, "ade15cea-3d7e-43a3-a5d7-bec4b8130009", new DateTime(2025, 9, 17, 23, 12, 3, 206, DateTimeKind.Local).AddTicks(984), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$6rNZHh8tCFbxKNOeavBDNe2XwzxJUgzSlyppfotdqVKAMaMmgHkZy", "(99) 99999-9995", false, "a4bdcb00-345c-4d9f-a5a1-fa9eedcfe8de", 0, false, new DateTime(2025, 9, 17, 23, 12, 3, 206, DateTimeKind.Local).AddTicks(978), "charlie" },
                    { new Guid("a703cbc1-2ab5-4113-b9a7-9f394b417ac8"), 0, "f82bb12d-ea27-4497-8802-aa358d8cfaf3", new DateTime(2025, 9, 17, 23, 12, 3, 206, DateTimeKind.Local).AddTicks(945), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$1sf/uh0nAQpeo9P5DzRoDeVThhmPjTqqFgVf3inQSVbv/7mhdqwJe", "(99) 99999-9992", false, "c822c762-4baa-4da9-aebf-8ec66c4d2f10", 0, false, new DateTime(2025, 9, 17, 23, 12, 3, 206, DateTimeKind.Local).AddTicks(897), "jane" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("19ed6134-f404-47b0-acd5-b28ca3a452cb"), new Guid("0eae02f2-8f6a-4393-a159-c7c68b87914c") },
                    { new Guid("f220a02f-d86d-46f5-8274-a11e7601b748"), new Guid("17090e6d-dc1d-41e3-b386-6946f7bf830f") },
                    { new Guid("428009e0-0ac7-4b42-b01a-094c6d1972df"), new Guid("6f893589-24b0-4dde-9dbc-fed6fdf947da") },
                    { new Guid("4f11a39b-27a1-42ed-862a-5f84fd60881f"), new Guid("72df9bc3-29f0-4eae-a56f-985ab2e30754") },
                    { new Guid("906cd0ef-b21d-4ad6-9cc2-283d9962a71c"), new Guid("a703cbc1-2ab5-4113-b9a7-9f394b417ac8") }
                });
        }
    }
}
