using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class location_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a3bac92f-08ba-4c5f-8185-1f1f887901b5"), new Guid("168aaefc-3aa6-433d-9bf1-b626a35fe4a7") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("06385110-86de-4b64-ad95-dca73cc373f2"), new Guid("713ad41c-b189-4fa4-946f-007d018a2276") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("abb04f58-da3f-4d0c-bc54-7d4d1cab0921"), new Guid("7d12904d-4836-4e9a-84f4-03f4a34fa39c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0a62827d-c675-4485-a43d-f55c174541eb"), new Guid("daad8ba2-44b4-431e-bbef-bc808df5025e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bef1c61b-912c-403e-be31-577aabb7b38c"), new Guid("efc80247-0dab-4798-a86d-8a7507bfc42a") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("06385110-86de-4b64-ad95-dca73cc373f2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0a62827d-c675-4485-a43d-f55c174541eb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a3bac92f-08ba-4c5f-8185-1f1f887901b5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("abb04f58-da3f-4d0c-bc54-7d4d1cab0921"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bef1c61b-912c-403e-be31-577aabb7b38c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("168aaefc-3aa6-433d-9bf1-b626a35fe4a7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("713ad41c-b189-4fa4-946f-007d018a2276"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7d12904d-4836-4e9a-84f4-03f4a34fa39c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("daad8ba2-44b4-431e-bbef-bc808df5025e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("efc80247-0dab-4798-a86d-8a7507bfc42a"));

            migrationBuilder.CreateTable(
                name: "LocationShapes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DiagnosisId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Label = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationShapes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationShapes_Diagnoses_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnoses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Coordinate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Lat = table.Column<double>(type: "double", nullable: false),
                    Lng = table.Column<double>(type: "double", nullable: false),
                    LocationShapeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coordinate_LocationShapes_LocationShapeId",
                        column: x => x.LocationShapeId,
                        principalTable: "LocationShapes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_Coordinate_LocationShapeId",
                table: "Coordinate",
                column: "LocationShapeId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationShapes_DiagnosisId",
                table: "LocationShapes",
                column: "DiagnosisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coordinate");

            migrationBuilder.DropTable(
                name: "LocationShapes");

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
                    { new Guid("06385110-86de-4b64-ad95-dca73cc373f2"), "8e732804-277f-44d9-8284-f8e8d9c6df8a", "Manager", "MANAGER" },
                    { new Guid("0a62827d-c675-4485-a43d-f55c174541eb"), "35c9e38c-ad53-4a45-b6ea-436734b50e16", "Collaborator", "COLLABORATOR" },
                    { new Guid("a3bac92f-08ba-4c5f-8185-1f1f887901b5"), "7dfca6d2-2337-4837-9f6d-0e83e82fd922", "Owner", "OWNER" },
                    { new Guid("abb04f58-da3f-4d0c-bc54-7d4d1cab0921"), "deb4259c-84e5-401e-8a1e-555d848c9bce", "Consultant", "CONSULTANT" },
                    { new Guid("bef1c61b-912c-403e-be31-577aabb7b38c"), "3e6d61cd-cd68-4424-9eb9-bcff08abddbd", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("168aaefc-3aa6-433d-9bf1-b626a35fe4a7"), 0, "d46d6d7e-b8a8-4519-a969-00589b264b78", new DateTime(2025, 7, 29, 22, 42, 11, 286, DateTimeKind.Local).AddTicks(7947), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$i0oLgCy4BkqB/yl81TG/euRNib7TybdaLVwWzAyEhDbSHKsFw22Aa", "(99) 99999-9992", false, "54c59ed8-9129-4683-bb93-bc850ec6b428", 0, false, new DateTime(2025, 7, 29, 22, 42, 11, 286, DateTimeKind.Local).AddTicks(7928), "jane" },
                    { new Guid("713ad41c-b189-4fa4-946f-007d018a2276"), 0, "f0b22361-37c5-4a2b-833a-24ae163c379b", new DateTime(2025, 7, 29, 22, 42, 11, 286, DateTimeKind.Local).AddTicks(7956), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$9NANjBozEnybHcseg.QU9eCdZhpRWC84FfBPXKj7KjqNIEn.mS.Ay", "(99) 99999-9994", false, "d49b36d4-cafa-4773-8219-f8884f47ee6c", 0, false, new DateTime(2025, 7, 29, 22, 42, 11, 286, DateTimeKind.Local).AddTicks(7953), "bob" },
                    { new Guid("7d12904d-4836-4e9a-84f4-03f4a34fa39c"), 0, "8320ed3f-07ce-48ba-bc92-e1d2e8896790", new DateTime(2025, 7, 29, 22, 42, 11, 286, DateTimeKind.Local).AddTicks(7952), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$UuXLE.L69uK4BM9oKYs/Eu7bE0ZddwIF.u.PzCSlSm2sO1UsoV5MO", "(99) 99999-9993", false, "782d4d68-0c50-4be6-9ffa-2a400e99e192", 0, false, new DateTime(2025, 7, 29, 22, 42, 11, 286, DateTimeKind.Local).AddTicks(7949), "alice" },
                    { new Guid("daad8ba2-44b4-431e-bbef-bc808df5025e"), 0, "122ab5e9-84b6-4006-a012-b7c98a8edc4b", new DateTime(2025, 7, 29, 22, 42, 11, 286, DateTimeKind.Local).AddTicks(7965), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$YvR/CJ4oQh7TplVFlytFeeYP4rmA.5fczd27RE.aYXb05MMUBX3bG", "(99) 99999-9995", false, "bff222a0-744e-4477-b41e-c0dbd709803b", 0, false, new DateTime(2025, 7, 29, 22, 42, 11, 286, DateTimeKind.Local).AddTicks(7957), "charlie" },
                    { new Guid("efc80247-0dab-4798-a86d-8a7507bfc42a"), 0, "a648e9f5-ebab-48e2-b58a-3ce348fbe09a", new DateTime(2025, 7, 29, 22, 42, 11, 286, DateTimeKind.Local).AddTicks(7653), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$wb2OQYvemGrWej48zv/lX.c9Z6H1hbVanMepAxwolO2j6zvbGkalG", "(99) 99999-9991", false, "b14a17f3-e5a3-4a34-a245-4cf690011fb4", 0, false, new DateTime(2025, 7, 29, 22, 42, 11, 286, DateTimeKind.Local).AddTicks(5595), "john" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("a3bac92f-08ba-4c5f-8185-1f1f887901b5"), new Guid("168aaefc-3aa6-433d-9bf1-b626a35fe4a7") },
                    { new Guid("06385110-86de-4b64-ad95-dca73cc373f2"), new Guid("713ad41c-b189-4fa4-946f-007d018a2276") },
                    { new Guid("abb04f58-da3f-4d0c-bc54-7d4d1cab0921"), new Guid("7d12904d-4836-4e9a-84f4-03f4a34fa39c") },
                    { new Guid("0a62827d-c675-4485-a43d-f55c174541eb"), new Guid("daad8ba2-44b4-431e-bbef-bc808df5025e") },
                    { new Guid("bef1c61b-912c-403e-be31-577aabb7b38c"), new Guid("efc80247-0dab-4798-a86d-8a7507bfc42a") }
                });
        }
    }
}
