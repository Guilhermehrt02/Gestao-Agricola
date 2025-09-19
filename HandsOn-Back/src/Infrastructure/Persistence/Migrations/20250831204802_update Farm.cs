using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateFarm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8ae0ce67-1425-4592-b138-3687b55df861"), new Guid("1b96a873-80e9-4966-9108-7eb12cd41b86") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6d0bcab4-6725-44c3-8a82-aab9741b676e"), new Guid("6fe28065-af1f-439e-acfe-e6ba29f61e00") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0aeba5e0-ec35-488d-b974-4e03ac5faff4"), new Guid("714a8d4d-bc3c-42cb-bc6a-d40a7479228e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f7a9ad02-e81d-4b7a-8a2b-c522dc48fe10"), new Guid("89951b52-acc7-4a6d-9a7b-9d1dc35c5b8d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b1449d44-0c8b-43ca-9d6e-0e43f32fb256"), new Guid("eb377288-d030-4221-ba2d-be505c57f9da") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0aeba5e0-ec35-488d-b974-4e03ac5faff4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6d0bcab4-6725-44c3-8a82-aab9741b676e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8ae0ce67-1425-4592-b138-3687b55df861"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b1449d44-0c8b-43ca-9d6e-0e43f32fb256"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f7a9ad02-e81d-4b7a-8a2b-c522dc48fe10"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1b96a873-80e9-4966-9108-7eb12cd41b86"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6fe28065-af1f-439e-acfe-e6ba29f61e00"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("714a8d4d-bc3c-42cb-bc6a-d40a7479228e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("89951b52-acc7-4a6d-9a7b-9d1dc35c5b8d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eb377288-d030-4221-ba2d-be505c57f9da"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("260f8dd8-9aa3-400e-b416-1d22d06d5bb6"), "a2c8bca0-9981-4f4c-8f58-a3a035d8672e", "Admin", "ADMIN" },
                    { new Guid("374dba69-8d49-4df5-ba3b-9ae1995cf7f3"), "ddd15121-1384-4257-9d90-f064b8b787af", "Consultant", "CONSULTANT" },
                    { new Guid("7b0fca88-fa02-4d7c-9418-bdd875cbbe7d"), "5dfeae49-02f3-44cd-a0b8-aca6e28270c6", "Manager", "MANAGER" },
                    { new Guid("ad6625e7-02dc-4621-94ce-882496989877"), "4f774082-ff08-4921-af86-0dbde79e6ce1", "Collaborator", "COLLABORATOR" },
                    { new Guid("b08379af-acde-4de0-b62e-f47d64f683f5"), "128a55a8-8b9e-4f21-aa1f-60b2c71d3cd8", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("5df828eb-12d9-4ef8-aecd-2d4840569327"), 0, "a2a16825-fb6a-4eb0-8367-fdc938a86fac", new DateTime(2025, 8, 31, 17, 47, 58, 932, DateTimeKind.Local).AddTicks(8349), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$gaH8ynZT4V/hCOwaLsWxtOOyi7qpaqQ7YHDZ/lqvilJvX4qBmZC8G", "(99) 99999-9993", false, "cfdae8ca-ab69-42ea-9fda-37c4bf6bbb0b", 0, false, new DateTime(2025, 8, 31, 17, 47, 58, 932, DateTimeKind.Local).AddTicks(8339), "alice" },
                    { new Guid("99257921-797f-4081-85ce-53d69ce1d8b5"), 0, "a6ab5a71-f3f5-423b-adf2-2b376e9213f9", new DateTime(2025, 8, 31, 17, 47, 58, 932, DateTimeKind.Local).AddTicks(8359), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$R3ev1gP.9bjxb05HxQkYG.v6c.lmLiv2oJpVGo17/GDo4zlelmg4a", "(99) 99999-9994", false, "0641daf0-8468-42e3-ad37-365e359c5d95", 0, false, new DateTime(2025, 8, 31, 17, 47, 58, 932, DateTimeKind.Local).AddTicks(8351), "bob" },
                    { new Guid("d6165ea0-ae6e-4aec-8f15-18cd2ebe3ab6"), 0, "000b2fb3-517f-4cea-9cb8-84be096af6e7", new DateTime(2025, 8, 31, 17, 47, 58, 932, DateTimeKind.Local).AddTicks(8398), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$EgI/nHetpPCq3Vd6r36BaOKC7UBdRFTJi7t9oLbxtvJt47eegBQve", "(99) 99999-9995", false, "06b2254c-b4ac-4d48-83e9-97994fb219cc", 0, false, new DateTime(2025, 8, 31, 17, 47, 58, 932, DateTimeKind.Local).AddTicks(8361), "charlie" },
                    { new Guid("dda8f9d0-8761-4833-a06f-b14f2139ef30"), 0, "9fc267d5-5228-42b7-9f19-b463cb8528df", new DateTime(2025, 8, 31, 17, 47, 58, 932, DateTimeKind.Local).AddTicks(7542), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$LV.MOwY4tPQPLDvjMijCv.yT8CV5lv6sJsDxwfVj.G19bYuYWYQPy", "(99) 99999-9991", false, "c92ceb56-ab21-40cf-a713-5c612554d469", 0, false, new DateTime(2025, 8, 31, 17, 47, 58, 932, DateTimeKind.Local).AddTicks(2407), "john" },
                    { new Guid("e7a61cbc-29e8-4e9f-9356-11e3dcc3a59a"), 0, "d309ab23-930e-4eeb-ae77-0fd2532aa657", new DateTime(2025, 8, 31, 17, 47, 58, 932, DateTimeKind.Local).AddTicks(8336), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$wyAdde0s66Epoz7p4CR4XOOH7g3oSeM.oUnluOQeIXQgJzKD6NzMy", "(99) 99999-9992", false, "c2617605-6bf8-4926-af20-ac26402ea00e", 0, false, new DateTime(2025, 8, 31, 17, 47, 58, 932, DateTimeKind.Local).AddTicks(8258), "jane" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("374dba69-8d49-4df5-ba3b-9ae1995cf7f3"), new Guid("5df828eb-12d9-4ef8-aecd-2d4840569327") },
                    { new Guid("7b0fca88-fa02-4d7c-9418-bdd875cbbe7d"), new Guid("99257921-797f-4081-85ce-53d69ce1d8b5") },
                    { new Guid("ad6625e7-02dc-4621-94ce-882496989877"), new Guid("d6165ea0-ae6e-4aec-8f15-18cd2ebe3ab6") },
                    { new Guid("260f8dd8-9aa3-400e-b416-1d22d06d5bb6"), new Guid("dda8f9d0-8761-4833-a06f-b14f2139ef30") },
                    { new Guid("b08379af-acde-4de0-b62e-f47d64f683f5"), new Guid("e7a61cbc-29e8-4e9f-9356-11e3dcc3a59a") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("374dba69-8d49-4df5-ba3b-9ae1995cf7f3"), new Guid("5df828eb-12d9-4ef8-aecd-2d4840569327") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7b0fca88-fa02-4d7c-9418-bdd875cbbe7d"), new Guid("99257921-797f-4081-85ce-53d69ce1d8b5") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ad6625e7-02dc-4621-94ce-882496989877"), new Guid("d6165ea0-ae6e-4aec-8f15-18cd2ebe3ab6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("260f8dd8-9aa3-400e-b416-1d22d06d5bb6"), new Guid("dda8f9d0-8761-4833-a06f-b14f2139ef30") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b08379af-acde-4de0-b62e-f47d64f683f5"), new Guid("e7a61cbc-29e8-4e9f-9356-11e3dcc3a59a") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("260f8dd8-9aa3-400e-b416-1d22d06d5bb6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("374dba69-8d49-4df5-ba3b-9ae1995cf7f3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7b0fca88-fa02-4d7c-9418-bdd875cbbe7d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ad6625e7-02dc-4621-94ce-882496989877"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b08379af-acde-4de0-b62e-f47d64f683f5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5df828eb-12d9-4ef8-aecd-2d4840569327"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("99257921-797f-4081-85ce-53d69ce1d8b5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d6165ea0-ae6e-4aec-8f15-18cd2ebe3ab6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dda8f9d0-8761-4833-a06f-b14f2139ef30"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7a61cbc-29e8-4e9f-9356-11e3dcc3a59a"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0aeba5e0-ec35-488d-b974-4e03ac5faff4"), "466a16c3-17b2-47a2-bd06-052e07a56204", "Consultant", "CONSULTANT" },
                    { new Guid("6d0bcab4-6725-44c3-8a82-aab9741b676e"), "065c0d30-9ebd-491e-b7ce-00bcc98832dc", "Manager", "MANAGER" },
                    { new Guid("8ae0ce67-1425-4592-b138-3687b55df861"), "231fd1d6-d98a-4e52-b3f9-f921498adca0", "Owner", "OWNER" },
                    { new Guid("b1449d44-0c8b-43ca-9d6e-0e43f32fb256"), "c484ea2f-90d7-40b6-8636-4e09a36e7755", "Admin", "ADMIN" },
                    { new Guid("f7a9ad02-e81d-4b7a-8a2b-c522dc48fe10"), "9440ddce-a272-4583-80ce-dbef21a90a88", "Collaborator", "COLLABORATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("1b96a873-80e9-4966-9108-7eb12cd41b86"), 0, "2db96200-bf21-4ac8-a4b1-0eaf08fd7198", new DateTime(2025, 8, 30, 12, 36, 36, 649, DateTimeKind.Local).AddTicks(9179), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$hY5xWjNMgq11oFALvBQI0OeflxMUIVEaU7jj5fMVXQ.sNlagaJT4i", "(99) 99999-9992", false, "93e6d021-d2cc-41df-aecf-82b645660734", 0, false, new DateTime(2025, 8, 30, 12, 36, 36, 649, DateTimeKind.Local).AddTicks(9126), "jane" },
                    { new Guid("6fe28065-af1f-439e-acfe-e6ba29f61e00"), 0, "2db9342a-78c8-49de-ae63-cf17bbc5efa3", new DateTime(2025, 8, 30, 12, 36, 36, 649, DateTimeKind.Local).AddTicks(9218), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$/2el3oGXf5.LhuRsTrTe.u/fofH/Z0Z/tafbCKy4CY3CykKEm9s8.", "(99) 99999-9994", false, "190b7df4-8cf7-4c42-ad92-0ca99082082d", 0, false, new DateTime(2025, 8, 30, 12, 36, 36, 649, DateTimeKind.Local).AddTicks(9210), "bob" },
                    { new Guid("714a8d4d-bc3c-42cb-bc6a-d40a7479228e"), 0, "e98e1a24-8cc9-43f5-a7c4-de5b92f39d45", new DateTime(2025, 8, 30, 12, 36, 36, 649, DateTimeKind.Local).AddTicks(9209), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$tvb6nI7peHwS.LJ5NDm.M.m1HUMNNJHZtaj/Kq9a527AP1pT4XbdW", "(99) 99999-9993", false, "9ae1b5f5-0979-4db6-8802-5e789462f804", 0, false, new DateTime(2025, 8, 30, 12, 36, 36, 649, DateTimeKind.Local).AddTicks(9182), "alice" },
                    { new Guid("89951b52-acc7-4a6d-9a7b-9d1dc35c5b8d"), 0, "31a2b4a5-014f-45c8-9ff1-1e9cf6404cbc", new DateTime(2025, 8, 30, 12, 36, 36, 649, DateTimeKind.Local).AddTicks(9244), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$cjONaOKePaKaslwEFi8avuOsT51jT.ZaqzZrHKI0YpibWfh7Uom8K", "(99) 99999-9995", false, "85d8bbc0-8d8e-440b-a2cf-4d87db6fd7d0", 0, false, new DateTime(2025, 8, 30, 12, 36, 36, 649, DateTimeKind.Local).AddTicks(9220), "charlie" },
                    { new Guid("eb377288-d030-4221-ba2d-be505c57f9da"), 0, "dd7863b3-e097-4296-aeee-b9760061a509", new DateTime(2025, 8, 30, 12, 36, 36, 649, DateTimeKind.Local).AddTicks(8547), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$oLlRDLafc15vLGM16BqJiehCdFcN7zV4klF9pQjR7KgaYjel1QXbu", "(99) 99999-9991", false, "02814d04-0a7a-4fa6-a281-1db5f5299a32", 0, false, new DateTime(2025, 8, 30, 12, 36, 36, 649, DateTimeKind.Local).AddTicks(4170), "john" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8ae0ce67-1425-4592-b138-3687b55df861"), new Guid("1b96a873-80e9-4966-9108-7eb12cd41b86") },
                    { new Guid("6d0bcab4-6725-44c3-8a82-aab9741b676e"), new Guid("6fe28065-af1f-439e-acfe-e6ba29f61e00") },
                    { new Guid("0aeba5e0-ec35-488d-b974-4e03ac5faff4"), new Guid("714a8d4d-bc3c-42cb-bc6a-d40a7479228e") },
                    { new Guid("f7a9ad02-e81d-4b7a-8a2b-c522dc48fe10"), new Guid("89951b52-acc7-4a6d-9a7b-9d1dc35c5b8d") },
                    { new Guid("b1449d44-0c8b-43ca-9d6e-0e43f32fb256"), new Guid("eb377288-d030-4221-ba2d-be505c57f9da") }
                });
        }
    }
}
