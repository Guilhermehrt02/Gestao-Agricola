using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class location_migration_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("43e1299b-6afb-4d34-a130-03de61499168"), new Guid("07695f77-d354-46b2-ad96-30368f0c8476") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bdd1c5f1-f713-4e3c-bcd9-2f7c72ce3b86"), new Guid("07bc1908-15da-45a3-8a23-0f460eeb6864") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ee2cb403-574e-4fa1-91a8-eb041f3f11a9"), new Guid("590ad72d-7aee-4bcd-a51d-5f6a9e0a2c69") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fb09195a-5a98-431a-94f0-19863d283482"), new Guid("cb1b2dfe-20f2-44ee-9c2d-5ba0a23eb7cb") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9d5be222-3889-482f-a319-e4bc1ac37dff"), new Guid("d4ebe3a5-7b63-4515-bf89-b3d41a819a86") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("43e1299b-6afb-4d34-a130-03de61499168"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9d5be222-3889-482f-a319-e4bc1ac37dff"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bdd1c5f1-f713-4e3c-bcd9-2f7c72ce3b86"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ee2cb403-574e-4fa1-91a8-eb041f3f11a9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fb09195a-5a98-431a-94f0-19863d283482"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("07695f77-d354-46b2-ad96-30368f0c8476"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("07bc1908-15da-45a3-8a23-0f460eeb6864"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("590ad72d-7aee-4bcd-a51d-5f6a9e0a2c69"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb1b2dfe-20f2-44ee-9c2d-5ba0a23eb7cb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4ebe3a5-7b63-4515-bf89-b3d41a819a86"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("43e1299b-6afb-4d34-a130-03de61499168"), "48dcdbd0-5417-405f-92e1-0b03a2dd6cbe", "Admin", "ADMIN" },
                    { new Guid("9d5be222-3889-482f-a319-e4bc1ac37dff"), "07185681-f761-4d19-a6c6-5c2b03e35be1", "Consultant", "CONSULTANT" },
                    { new Guid("bdd1c5f1-f713-4e3c-bcd9-2f7c72ce3b86"), "0e878d2d-7bcd-4df7-ac12-fe9b27526286", "Collaborator", "COLLABORATOR" },
                    { new Guid("ee2cb403-574e-4fa1-91a8-eb041f3f11a9"), "49fc836d-1762-4579-add8-488ef4e72867", "Owner", "OWNER" },
                    { new Guid("fb09195a-5a98-431a-94f0-19863d283482"), "ecdcf9ba-7ef2-43df-b429-7a9c4350f6a0", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("07695f77-d354-46b2-ad96-30368f0c8476"), 0, "9fa8380c-9815-41da-b931-c39679ce4f50", new DateTime(2025, 8, 11, 20, 44, 10, 124, DateTimeKind.Local).AddTicks(1139), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$DkZvA859uP5dlzwkG5sv1eSn50vUlUHvO6QdHbpKs1/l5WH49YtQ6", "(99) 99999-9991", false, "040419f3-76bb-49f1-888a-14710acef368", 0, false, new DateTime(2025, 8, 11, 20, 44, 10, 123, DateTimeKind.Local).AddTicks(8669), "john" },
                    { new Guid("07bc1908-15da-45a3-8a23-0f460eeb6864"), 0, "d19a76b6-dd0c-451d-be1e-8b461ba45b01", new DateTime(2025, 8, 11, 20, 44, 10, 124, DateTimeKind.Local).AddTicks(1515), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$uPsY2s40fi0P2rOcW673mOOsZoHYfG/PnAzwKNoTMe1mxEuoCEjte", "(99) 99999-9995", false, "a988a2f3-e56f-4a67-bf5d-69a53dcde134", 0, false, new DateTime(2025, 8, 11, 20, 44, 10, 124, DateTimeKind.Local).AddTicks(1512), "charlie" },
                    { new Guid("590ad72d-7aee-4bcd-a51d-5f6a9e0a2c69"), 0, "ffe75ce5-ebc4-41fd-a7aa-d8f8b32ef5c5", new DateTime(2025, 8, 11, 20, 44, 10, 124, DateTimeKind.Local).AddTicks(1494), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$Gcx.Hlnts.kmR7gBMVe92ukqQt8SJon/npzVJcEztIRPOosriqrOa", "(99) 99999-9992", false, "1e5fbfda-0def-43d5-b8c3-acafc06ee192", 0, false, new DateTime(2025, 8, 11, 20, 44, 10, 124, DateTimeKind.Local).AddTicks(1470), "jane" },
                    { new Guid("cb1b2dfe-20f2-44ee-9c2d-5ba0a23eb7cb"), 0, "036a79e6-375c-425d-b7ba-8f28cef49fc5", new DateTime(2025, 8, 11, 20, 44, 10, 124, DateTimeKind.Local).AddTicks(1511), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$GQuiVkvGT51ffUJDw0wtgOycCE9GQMf/XP7BSfd4vCgmuxgWmMIvm", "(99) 99999-9994", false, "4a3a7330-9855-43d8-b927-8d9b4044083d", 0, false, new DateTime(2025, 8, 11, 20, 44, 10, 124, DateTimeKind.Local).AddTicks(1501), "bob" },
                    { new Guid("d4ebe3a5-7b63-4515-bf89-b3d41a819a86"), 0, "05b497c0-6369-439d-bad9-93429e49ef53", new DateTime(2025, 8, 11, 20, 44, 10, 124, DateTimeKind.Local).AddTicks(1500), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$Qqser.9Tu0kD8zAVGHA75.XJbQ6.yPxDpa6HT0fHyM2xTgas17b6S", "(99) 99999-9993", false, "18912dfa-c66c-49a7-8a11-0f0515b21da8", 0, false, new DateTime(2025, 8, 11, 20, 44, 10, 124, DateTimeKind.Local).AddTicks(1495), "alice" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("43e1299b-6afb-4d34-a130-03de61499168"), new Guid("07695f77-d354-46b2-ad96-30368f0c8476") },
                    { new Guid("bdd1c5f1-f713-4e3c-bcd9-2f7c72ce3b86"), new Guid("07bc1908-15da-45a3-8a23-0f460eeb6864") },
                    { new Guid("ee2cb403-574e-4fa1-91a8-eb041f3f11a9"), new Guid("590ad72d-7aee-4bcd-a51d-5f6a9e0a2c69") },
                    { new Guid("fb09195a-5a98-431a-94f0-19863d283482"), new Guid("cb1b2dfe-20f2-44ee-9c2d-5ba0a23eb7cb") },
                    { new Guid("9d5be222-3889-482f-a319-e4bc1ac37dff"), new Guid("d4ebe3a5-7b63-4515-bf89-b3d41a819a86") }
                });
        }
    }
}
