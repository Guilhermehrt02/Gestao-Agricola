using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class userFarmEntity : Migration
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
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FarmId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserRole = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFarms", x => new { x.UserId, x.FarmId });
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
                    { new Guid("7315e528-aa05-480a-ab39-0d8baf45be56"), "6558187a-349f-473a-8042-ab07c572f0b5", "Manager", "MANAGER" },
                    { new Guid("91b09b9c-8d26-4719-bfc6-ff94abda685a"), "a35c4424-16f1-49cc-bf74-ab3793ace763", "Admin", "ADMIN" },
                    { new Guid("dc9ab0ec-5c29-4b6f-ad5c-670f6307bcc1"), "7aae22ec-70c1-4aec-b349-c7e66812a62f", "Owner", "OWNER" },
                    { new Guid("e123e47d-bf78-4460-bcda-a8250eb9c3b8"), "fad31182-9c06-4c09-a945-5d4c56daec51", "Consultant", "CONSULTANT" },
                    { new Guid("e1ce927b-6ce9-41bc-a234-706fcfb92750"), "75830766-77e0-4c91-a2e2-f72da72ec872", "Collaborator", "COLLABORATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("66909c67-b5f3-468f-afbf-7ba917c3a31d"), 0, "ff531598-6314-4b6d-a69d-021b8577bcd2", new DateTime(2025, 8, 25, 20, 11, 22, 505, DateTimeKind.Local).AddTicks(2986), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$U93hcM7yURPTa07SIIDU6Opb4gSgunWkbkj/A2qJuoRntIForQWNy", "(99) 99999-9992", false, "cf5b32aa-a41b-4864-94bf-b2807c05eacd", 0, false, new DateTime(2025, 8, 25, 20, 11, 22, 505, DateTimeKind.Local).AddTicks(2965), "jane" },
                    { new Guid("6b0f2cbc-b6d9-434b-b899-61e64749fcd2"), 0, "e21aa38b-e7e3-44f9-91a8-3f7b729a6a7c", new DateTime(2025, 8, 25, 20, 11, 22, 505, DateTimeKind.Local).AddTicks(2991), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$fM/SWPkiP800eeJh8IZ9cOH1.ZOAWn4gdqmkmMQzklFJSFElU4ifu", "(99) 99999-9993", false, "c7f205f6-6490-4148-a6d1-bceb9653fa4b", 0, false, new DateTime(2025, 8, 25, 20, 11, 22, 505, DateTimeKind.Local).AddTicks(2987), "alice" },
                    { new Guid("9ffb0764-bfe8-4d31-a479-c9e671e6b762"), 0, "43111410-904e-4963-b764-d94edae438cd", new DateTime(2025, 8, 25, 20, 11, 22, 505, DateTimeKind.Local).AddTicks(2701), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$im2lE62USnbSmu4lHHz9ZehxwteP36OhdwL9cybYUPD8L6z7ekHYq", "(99) 99999-9991", false, "b7968b56-36ac-4842-9cf4-9d334eaf9e1d", 0, false, new DateTime(2025, 8, 25, 20, 11, 22, 505, DateTimeKind.Local).AddTicks(759), "john" },
                    { new Guid("ceb61b77-3082-4382-ab9a-267a58078ef6"), 0, "1129bd93-1420-4f6f-9cba-294157b066b1", new DateTime(2025, 8, 25, 20, 11, 22, 505, DateTimeKind.Local).AddTicks(3000), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$SgJa1Tcec3pp3VkQqfOyIer6TL8lZQd7DdsA5asMDd3na/XaDIfSm", "(99) 99999-9994", false, "204e0b14-91cc-4589-bd38-93b816034a4a", 0, false, new DateTime(2025, 8, 25, 20, 11, 22, 505, DateTimeKind.Local).AddTicks(2992), "bob" },
                    { new Guid("d32444b7-2ed8-4d66-b1b4-818e02434311"), 0, "e50d5c98-4bc4-42fb-8075-a6571b94404d", new DateTime(2025, 8, 25, 20, 11, 22, 505, DateTimeKind.Local).AddTicks(3010), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$FV./wb3ZV4thaQqWBGeCYe8WGeqAwFyuo/afMb4548f3O0P9P4guG", "(99) 99999-9995", false, "37db0972-c64d-43c1-8a0a-107d7fed54dd", 0, false, new DateTime(2025, 8, 25, 20, 11, 22, 505, DateTimeKind.Local).AddTicks(3001), "charlie" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("dc9ab0ec-5c29-4b6f-ad5c-670f6307bcc1"), new Guid("66909c67-b5f3-468f-afbf-7ba917c3a31d") },
                    { new Guid("e123e47d-bf78-4460-bcda-a8250eb9c3b8"), new Guid("6b0f2cbc-b6d9-434b-b899-61e64749fcd2") },
                    { new Guid("91b09b9c-8d26-4719-bfc6-ff94abda685a"), new Guid("9ffb0764-bfe8-4d31-a479-c9e671e6b762") },
                    { new Guid("7315e528-aa05-480a-ab39-0d8baf45be56"), new Guid("ceb61b77-3082-4382-ab9a-267a58078ef6") },
                    { new Guid("e1ce927b-6ce9-41bc-a234-706fcfb92750"), new Guid("d32444b7-2ed8-4d66-b1b4-818e02434311") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFarms_FarmId",
                table: "UserFarms",
                column: "FarmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFarms");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("dc9ab0ec-5c29-4b6f-ad5c-670f6307bcc1"), new Guid("66909c67-b5f3-468f-afbf-7ba917c3a31d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e123e47d-bf78-4460-bcda-a8250eb9c3b8"), new Guid("6b0f2cbc-b6d9-434b-b899-61e64749fcd2") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("91b09b9c-8d26-4719-bfc6-ff94abda685a"), new Guid("9ffb0764-bfe8-4d31-a479-c9e671e6b762") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7315e528-aa05-480a-ab39-0d8baf45be56"), new Guid("ceb61b77-3082-4382-ab9a-267a58078ef6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e1ce927b-6ce9-41bc-a234-706fcfb92750"), new Guid("d32444b7-2ed8-4d66-b1b4-818e02434311") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7315e528-aa05-480a-ab39-0d8baf45be56"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("91b09b9c-8d26-4719-bfc6-ff94abda685a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dc9ab0ec-5c29-4b6f-ad5c-670f6307bcc1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e123e47d-bf78-4460-bcda-a8250eb9c3b8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1ce927b-6ce9-41bc-a234-706fcfb92750"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66909c67-b5f3-468f-afbf-7ba917c3a31d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6b0f2cbc-b6d9-434b-b899-61e64749fcd2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9ffb0764-bfe8-4d31-a479-c9e671e6b762"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ceb61b77-3082-4382-ab9a-267a58078ef6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d32444b7-2ed8-4d66-b1b4-818e02434311"));

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
