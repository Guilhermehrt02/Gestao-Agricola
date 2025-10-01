using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class imagesimilaritydiseaseupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("afdf2407-762b-4d9d-b23e-ae0c19b04529"), new Guid("0d93ae49-429b-4382-b885-630a4e0d14aa") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("db7b4ff8-53bc-4e12-a6b1-95ff1f159541"), new Guid("15571fca-06af-454e-843f-00647fa75b98") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("91331bb9-e283-4ade-a980-d83a2e02cbf3"), new Guid("73ff28ef-54d7-4259-b793-187dd920cbc2") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7cf2034e-1ce9-4058-841b-48ae4ef8efe8"), new Guid("db7ad260-28a0-47e9-a5c4-ce7169b6c004") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3449bbc0-7699-466c-8940-1459b3cb10dc"), new Guid("e842c6a5-52e2-4ebb-8c23-24a3bacd467f") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3449bbc0-7699-466c-8940-1459b3cb10dc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cf2034e-1ce9-4058-841b-48ae4ef8efe8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("91331bb9-e283-4ade-a980-d83a2e02cbf3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("afdf2407-762b-4d9d-b23e-ae0c19b04529"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("db7b4ff8-53bc-4e12-a6b1-95ff1f159541"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0d93ae49-429b-4382-b885-630a4e0d14aa"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("15571fca-06af-454e-843f-00647fa75b98"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("73ff28ef-54d7-4259-b793-187dd920cbc2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("db7ad260-28a0-47e9-a5c4-ce7169b6c004"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e842c6a5-52e2-4ebb-8c23-24a3bacd467f"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageBook",
                table: "ImageSimilarity",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ImageBook",
                table: "ImageSimilarity",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3449bbc0-7699-466c-8940-1459b3cb10dc"), "ede2ff12-9d1e-4af7-be0e-157bc841b848", "Consultant", "CONSULTANT" },
                    { new Guid("7cf2034e-1ce9-4058-841b-48ae4ef8efe8"), "85944edc-dac8-4363-adeb-ebd476ff98d5", "Owner", "OWNER" },
                    { new Guid("91331bb9-e283-4ade-a980-d83a2e02cbf3"), "eea910c4-9c0a-4c49-a1ad-adfe1048063a", "Collaborator", "COLLABORATOR" },
                    { new Guid("afdf2407-762b-4d9d-b23e-ae0c19b04529"), "ae0ca24c-93b5-4f44-8889-f1316d4c9018", "Admin", "ADMIN" },
                    { new Guid("db7b4ff8-53bc-4e12-a6b1-95ff1f159541"), "084c3910-a0d8-4232-9353-527344a95f85", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("0d93ae49-429b-4382-b885-630a4e0d14aa"), 0, "fe7197bd-a899-4a45-b763-d1da2b6a6973", new DateTime(2025, 9, 16, 19, 16, 37, 575, DateTimeKind.Local).AddTicks(6621), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$fkw1NTAxeD/DwF5a2jXsvuEroBiQ3ubymUdVZ0mODAXECfTuNlLgq", "(99) 99999-9991", false, "90e7d1e4-da94-42f7-8431-15126a812e02", 0, false, new DateTime(2025, 9, 16, 19, 16, 37, 575, DateTimeKind.Local).AddTicks(2018), "john" },
                    { new Guid("15571fca-06af-454e-843f-00647fa75b98"), 0, "a7f7a450-ffe4-42c3-9243-c3408ff5c3b9", new DateTime(2025, 9, 16, 19, 16, 37, 575, DateTimeKind.Local).AddTicks(7175), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$VHaTlbUVLMYxqfTZ3aHS.OZjDELDltapve7s1FU0v7eEz6.iee3hO", "(99) 99999-9994", false, "67056b17-21b4-40ef-9b85-ef8c09a4d478", 0, false, new DateTime(2025, 9, 16, 19, 16, 37, 575, DateTimeKind.Local).AddTicks(7160), "bob" },
                    { new Guid("73ff28ef-54d7-4259-b793-187dd920cbc2"), 0, "792b6b0b-ed2c-4163-a570-2f4de5ca3228", new DateTime(2025, 9, 16, 19, 16, 37, 575, DateTimeKind.Local).AddTicks(7179), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$tyXx7hVeaHGX1VwDs5z4Tu/iDxFjYvdrepx/8zL7f/fn7Jws6oTSa", "(99) 99999-9995", false, "989f421f-b5c8-42c6-84c2-6477469c50d5", 0, false, new DateTime(2025, 9, 16, 19, 16, 37, 575, DateTimeKind.Local).AddTicks(7176), "charlie" },
                    { new Guid("db7ad260-28a0-47e9-a5c4-ce7169b6c004"), 0, "b5321344-d98d-4efe-adb6-202c00348e73", new DateTime(2025, 9, 16, 19, 16, 37, 575, DateTimeKind.Local).AddTicks(7153), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$F/i3kk2hVSulgxm7/zGYluA7ejJp8ky/ZoP3ADUBI8g6l129wnL82", "(99) 99999-9992", false, "6ee4d8e2-cf75-4d8f-aca0-84d7591f9622", 0, false, new DateTime(2025, 9, 16, 19, 16, 37, 575, DateTimeKind.Local).AddTicks(7108), "jane" },
                    { new Guid("e842c6a5-52e2-4ebb-8c23-24a3bacd467f"), 0, "794fa598-9efb-479a-9f41-9e56e25e497c", new DateTime(2025, 9, 16, 19, 16, 37, 575, DateTimeKind.Local).AddTicks(7159), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$ZfOdeBhykNDXkYluJjLEA.rfFagaphMXfKHWTJ2vnZdj734Vw3ib2", "(99) 99999-9993", false, "777d5280-638c-4600-b443-e5a16902413d", 0, false, new DateTime(2025, 9, 16, 19, 16, 37, 575, DateTimeKind.Local).AddTicks(7155), "alice" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("afdf2407-762b-4d9d-b23e-ae0c19b04529"), new Guid("0d93ae49-429b-4382-b885-630a4e0d14aa") },
                    { new Guid("db7b4ff8-53bc-4e12-a6b1-95ff1f159541"), new Guid("15571fca-06af-454e-843f-00647fa75b98") },
                    { new Guid("91331bb9-e283-4ade-a980-d83a2e02cbf3"), new Guid("73ff28ef-54d7-4259-b793-187dd920cbc2") },
                    { new Guid("7cf2034e-1ce9-4058-841b-48ae4ef8efe8"), new Guid("db7ad260-28a0-47e9-a5c4-ce7169b6c004") },
                    { new Guid("3449bbc0-7699-466c-8940-1459b3cb10dc"), new Guid("e842c6a5-52e2-4ebb-8c23-24a3bacd467f") }
                });
        }
    }
}
