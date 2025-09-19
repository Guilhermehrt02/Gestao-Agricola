using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class adduserFarm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("37321cda-2830-45e6-97b4-2e2eef8201cb"), new Guid("0e522a9b-236c-414d-aeba-70ea24a8e659") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cd9c50ed-c25a-4fd7-b6b8-84f330edd302"), new Guid("b63339d1-89aa-4aa3-b100-c0b1a965fda8") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8bccd356-5af4-41aa-891d-f8bb42370ac8"), new Guid("bd61794a-a064-4611-89dc-22e425f9c030") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("057b80c9-fdfe-4c91-80f8-45fe98c34947"), new Guid("cc28939f-dfdd-486f-b832-9221f20ca855") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5acbdedc-01c5-48f9-bfba-a35584627da1"), new Guid("cce43b07-b30d-4858-9343-df0e4584bfce") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("057b80c9-fdfe-4c91-80f8-45fe98c34947"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("37321cda-2830-45e6-97b4-2e2eef8201cb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5acbdedc-01c5-48f9-bfba-a35584627da1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8bccd356-5af4-41aa-891d-f8bb42370ac8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cd9c50ed-c25a-4fd7-b6b8-84f330edd302"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0e522a9b-236c-414d-aeba-70ea24a8e659"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b63339d1-89aa-4aa3-b100-c0b1a965fda8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bd61794a-a064-4611-89dc-22e425f9c030"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cc28939f-dfdd-486f-b832-9221f20ca855"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cce43b07-b30d-4858-9343-df0e4584bfce"));

            migrationBuilder.CreateTable(
                name: "UserFarms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FarmId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserRole = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFarms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFarms_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFarms_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserFarms_FarmId",
                table: "UserFarms",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFarms_UserId",
                table: "UserFarms",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFarms");

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
                    { new Guid("057b80c9-fdfe-4c91-80f8-45fe98c34947"), "bc66ca72-cbba-487a-bba5-1889a0f4464b", "Owner", "OWNER" },
                    { new Guid("37321cda-2830-45e6-97b4-2e2eef8201cb"), "fe0492f1-5bc8-488c-824c-51def65e4393", "Consultant", "CONSULTANT" },
                    { new Guid("5acbdedc-01c5-48f9-bfba-a35584627da1"), "97a4a446-caaa-4b53-b3a9-3992b1eb1a82", "Manager", "MANAGER" },
                    { new Guid("8bccd356-5af4-41aa-891d-f8bb42370ac8"), "b16184cc-09fe-485a-8836-eebc8aa6f33a", "Collaborator", "COLLABORATOR" },
                    { new Guid("cd9c50ed-c25a-4fd7-b6b8-84f330edd302"), "ece85f8d-481c-4e58-8ab1-5d8ba73f6ed6", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("0e522a9b-236c-414d-aeba-70ea24a8e659"), 0, "60fc0405-b0e0-4af3-a72b-b8c59e24a87d", new DateTime(2025, 8, 11, 21, 44, 38, 823, DateTimeKind.Local).AddTicks(6766), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$hEhGjittxH0t9mQJBmjvge/TPZZOjrm/pW04LHqKMwZy7c14DJtsW", "(99) 99999-9993", false, "5362a738-a8a2-4606-93a5-a911193513be", 0, false, new DateTime(2025, 8, 11, 21, 44, 38, 823, DateTimeKind.Local).AddTicks(6754), "alice" },
                    { new Guid("b63339d1-89aa-4aa3-b100-c0b1a965fda8"), 0, "140e721e-3735-4953-9c31-069a339a0bbe", new DateTime(2025, 8, 11, 21, 44, 38, 823, DateTimeKind.Local).AddTicks(6419), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$7obCtsdnOGu3njjWk/TVlOTIHizPJTgDRdweOB.Wx32YoZQJNN3iq", "(99) 99999-9991", false, "ff66aeef-acfa-48da-b40e-1a5e10e5342f", 0, false, new DateTime(2025, 8, 11, 21, 44, 38, 823, DateTimeKind.Local).AddTicks(2760), "john" },
                    { new Guid("bd61794a-a064-4611-89dc-22e425f9c030"), 0, "3a7c1eb2-3f9c-4dd9-bfc6-53fe582f39d9", new DateTime(2025, 8, 11, 21, 44, 38, 823, DateTimeKind.Local).AddTicks(6781), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$HrsPCRvX6nHn9rfRuCeKxeLHRVBiE/bCgmjhbCWFG1fRri1FFM0wK", "(99) 99999-9995", false, "94331fe3-55f2-4277-ba5f-61defde156c2", 0, false, new DateTime(2025, 8, 11, 21, 44, 38, 823, DateTimeKind.Local).AddTicks(6772), "charlie" },
                    { new Guid("cc28939f-dfdd-486f-b832-9221f20ca855"), 0, "ca54e9b6-c758-420a-b5fb-74c038893e0e", new DateTime(2025, 8, 11, 21, 44, 38, 823, DateTimeKind.Local).AddTicks(6753), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$.w1aJltFFERaDQx.7B3C2u0KQLM1NykPhOwxpREJPEmjjx3RB4LI6", "(99) 99999-9992", false, "21880664-31bd-48fd-acb0-0f2d5f0d91af", 0, false, new DateTime(2025, 8, 11, 21, 44, 38, 823, DateTimeKind.Local).AddTicks(6725), "jane" },
                    { new Guid("cce43b07-b30d-4858-9343-df0e4584bfce"), 0, "b25006d9-a8a7-4372-bdd2-37cbebb08726", new DateTime(2025, 8, 11, 21, 44, 38, 823, DateTimeKind.Local).AddTicks(6771), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$TYmjNqpnRy9gM11Fm4PU3ebUrSDmLSJNTstpEf1D0xI8AMQFUcVYG", "(99) 99999-9994", false, "5c8dfb36-afd3-430d-a77c-fb18d9b3440e", 0, false, new DateTime(2025, 8, 11, 21, 44, 38, 823, DateTimeKind.Local).AddTicks(6767), "bob" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("37321cda-2830-45e6-97b4-2e2eef8201cb"), new Guid("0e522a9b-236c-414d-aeba-70ea24a8e659") },
                    { new Guid("cd9c50ed-c25a-4fd7-b6b8-84f330edd302"), new Guid("b63339d1-89aa-4aa3-b100-c0b1a965fda8") },
                    { new Guid("8bccd356-5af4-41aa-891d-f8bb42370ac8"), new Guid("bd61794a-a064-4611-89dc-22e425f9c030") },
                    { new Guid("057b80c9-fdfe-4c91-80f8-45fe98c34947"), new Guid("cc28939f-dfdd-486f-b832-9221f20ca855") },
                    { new Guid("5acbdedc-01c5-48f9-bfba-a35584627da1"), new Guid("cce43b07-b30d-4858-9343-df0e4584bfce") }
                });
        }
    }
}
