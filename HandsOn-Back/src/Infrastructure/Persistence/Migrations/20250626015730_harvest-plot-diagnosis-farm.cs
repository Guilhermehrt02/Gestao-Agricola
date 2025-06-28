using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class harvestplotdiagnosisfarm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0dd9bdd4-3cf4-4643-9f58-dab5798fa414"), new Guid("33c54e4d-1a66-4241-bb2a-173acf08a43c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("240d28ea-5a5b-4787-afa9-1edc839ff664"), new Guid("4371a608-5090-48e9-922f-dd73f301af7b") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("46e0844f-dc49-4e2b-887d-8980a3fbf9d7"), new Guid("b05df9b0-c6bf-4db9-b281-bd219b45640c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("be0b823b-fa83-4421-b825-0ed842166bf3"), new Guid("dbac9f8f-9525-425f-af61-9e6176f9c20f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6cbc0f2e-d797-49f0-8fbb-c42abf6befea"), new Guid("fab7976e-17b9-4e53-9b97-3122058f5677") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0dd9bdd4-3cf4-4643-9f58-dab5798fa414"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("240d28ea-5a5b-4787-afa9-1edc839ff664"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("46e0844f-dc49-4e2b-887d-8980a3fbf9d7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6cbc0f2e-d797-49f0-8fbb-c42abf6befea"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("be0b823b-fa83-4421-b825-0ed842166bf3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33c54e4d-1a66-4241-bb2a-173acf08a43c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4371a608-5090-48e9-922f-dd73f301af7b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b05df9b0-c6bf-4db9-b281-bd219b45640c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dbac9f8f-9525-425f-af61-9e6176f9c20f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fab7976e-17b9-4e53-9b97-3122058f5677"));

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FarmId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    HarvestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PlotId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UploadType = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    PhotoUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Result = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Latitude = table.Column<double>(type: "double", precision: 10, scale: 8, nullable: true),
                    Longitude = table.Column<double>(type: "double", precision: 11, scale: 8, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Harvests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FarmId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harvests", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Plots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FarmId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Area = table.Column<double>(type: "double", nullable: false),
                    Latitude = table.Column<double>(type: "double", precision: 10, scale: 8, nullable: true),
                    Longitude = table.Column<double>(type: "double", precision: 11, scale: 8, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plots", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("521aad9d-ff05-4177-b671-bbe7b4b92313"), "93c780fe-61ed-4bfe-bb58-a8da573a78a2", "Owner", "OWNER" },
                    { new Guid("6e55838b-0e14-4094-88f3-a996333955ff"), "4f921072-dc6b-403e-8ab4-66b3990dd08b", "Consultant", "CONSULTANT" },
                    { new Guid("b97156a6-d73d-4fb3-bb93-8946d0b3d9e1"), "82c8b572-7a4c-4ed5-9bbd-05f43a48e872", "Collaborator", "COLLABORATOR" },
                    { new Guid("dce68d9f-345c-4ab9-b0f2-39e203b437d3"), "f54c7386-7520-4d95-b8df-dc3e82a64a70", "Manager", "MANAGER" },
                    { new Guid("f4e04c9d-ee45-4e97-9048-bb45f35657eb"), "7f578716-fade-46a9-900b-31c568f67547", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("0572205b-080d-4eb6-8c1f-c5f7aa839ca8"), 0, "c642cb18-0fd9-49e6-bbd6-0e64762ae28f", new DateTime(2025, 6, 25, 22, 57, 28, 635, DateTimeKind.Local).AddTicks(6111), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$QXCDLxHVpMmdsElti81owuaF0sMJDRaK78b6JbXO1XGTlPYIX5lY6", "(99) 99999-9991", false, "1ad37ee0-7146-4ec7-a6e8-08eaa6eb68b9", 0, false, new DateTime(2025, 6, 25, 22, 57, 28, 635, DateTimeKind.Local).AddTicks(4212), "john" },
                    { new Guid("11db7535-e5a2-4720-9b81-5ab66a98bd52"), 0, "d474fe4b-bf66-49e8-bf06-77ac6f678e8b", new DateTime(2025, 6, 25, 22, 57, 28, 635, DateTimeKind.Local).AddTicks(6394), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$3dhUjrciut7k/tq9VO9NH.wEBhLVMC1G4lHZA3zjofnYFmUiU1c5G", "(99) 99999-9994", false, "adf6e7b5-d945-48a5-9421-0373905e3d0b", 0, false, new DateTime(2025, 6, 25, 22, 57, 28, 635, DateTimeKind.Local).AddTicks(6390), "bob" },
                    { new Guid("1771244f-6b8b-4e97-ab6a-a8cf3727d003"), 0, "3b94dc2d-3a54-49e9-a4a0-e7315da61769", new DateTime(2025, 6, 25, 22, 57, 28, 635, DateTimeKind.Local).AddTicks(6384), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$Vyvj.4pSq9ZsqS3EY5kMJu.CvomZ5UIeoAf7xk5zxSxNYfjCjMS7O", "(99) 99999-9992", false, "49c682b2-9a81-4652-b226-fce12eb2763a", 0, false, new DateTime(2025, 6, 25, 22, 57, 28, 635, DateTimeKind.Local).AddTicks(6366), "jane" },
                    { new Guid("2e403352-ef34-4c41-a443-eb7a0a87a1d5"), 0, "758cf077-9c9e-4d1e-89b9-0e288db1567d", new DateTime(2025, 6, 25, 22, 57, 28, 635, DateTimeKind.Local).AddTicks(6389), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$yfLTMXApVbbWtsG2MzQiTeQOrrBu6IXF/oNeSvAmlYoBSpUbMaKDS", "(99) 99999-9993", false, "3f3f09d8-107c-42fd-95e9-3d2e0ea103ff", 0, false, new DateTime(2025, 6, 25, 22, 57, 28, 635, DateTimeKind.Local).AddTicks(6385), "alice" },
                    { new Guid("c818665f-5c61-4bcc-b347-b318ad0e1441"), 0, "dbcef813-b580-4185-a1ad-ad2c7c2f7979", new DateTime(2025, 6, 25, 22, 57, 28, 635, DateTimeKind.Local).AddTicks(6401), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$9/lrPX3EZyUQYnpEs/8eNew11D2WB/9jtnUSXt0RS6BHHDhRrOZoC", "(99) 99999-9995", false, "df24d925-05d4-4720-b346-785bfc495c4f", 0, false, new DateTime(2025, 6, 25, 22, 57, 28, 635, DateTimeKind.Local).AddTicks(6394), "charlie" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f4e04c9d-ee45-4e97-9048-bb45f35657eb"), new Guid("0572205b-080d-4eb6-8c1f-c5f7aa839ca8") },
                    { new Guid("dce68d9f-345c-4ab9-b0f2-39e203b437d3"), new Guid("11db7535-e5a2-4720-9b81-5ab66a98bd52") },
                    { new Guid("521aad9d-ff05-4177-b671-bbe7b4b92313"), new Guid("1771244f-6b8b-4e97-ab6a-a8cf3727d003") },
                    { new Guid("6e55838b-0e14-4094-88f3-a996333955ff"), new Guid("2e403352-ef34-4c41-a443-eb7a0a87a1d5") },
                    { new Guid("b97156a6-d73d-4fb3-bb93-8946d0b3d9e1"), new Guid("c818665f-5c61-4bcc-b347-b318ad0e1441") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "Farms");

            migrationBuilder.DropTable(
                name: "Harvests");

            migrationBuilder.DropTable(
                name: "Plots");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f4e04c9d-ee45-4e97-9048-bb45f35657eb"), new Guid("0572205b-080d-4eb6-8c1f-c5f7aa839ca8") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("dce68d9f-345c-4ab9-b0f2-39e203b437d3"), new Guid("11db7535-e5a2-4720-9b81-5ab66a98bd52") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("521aad9d-ff05-4177-b671-bbe7b4b92313"), new Guid("1771244f-6b8b-4e97-ab6a-a8cf3727d003") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6e55838b-0e14-4094-88f3-a996333955ff"), new Guid("2e403352-ef34-4c41-a443-eb7a0a87a1d5") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b97156a6-d73d-4fb3-bb93-8946d0b3d9e1"), new Guid("c818665f-5c61-4bcc-b347-b318ad0e1441") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("521aad9d-ff05-4177-b671-bbe7b4b92313"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6e55838b-0e14-4094-88f3-a996333955ff"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b97156a6-d73d-4fb3-bb93-8946d0b3d9e1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dce68d9f-345c-4ab9-b0f2-39e203b437d3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f4e04c9d-ee45-4e97-9048-bb45f35657eb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0572205b-080d-4eb6-8c1f-c5f7aa839ca8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("11db7535-e5a2-4720-9b81-5ab66a98bd52"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1771244f-6b8b-4e97-ab6a-a8cf3727d003"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2e403352-ef34-4c41-a443-eb7a0a87a1d5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c818665f-5c61-4bcc-b347-b318ad0e1441"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0dd9bdd4-3cf4-4643-9f58-dab5798fa414"), "1cbdef94-b8f7-45ba-890e-6b93b9a32455", "Collaborator", "COLLABORATOR" },
                    { new Guid("240d28ea-5a5b-4787-afa9-1edc839ff664"), "40bba595-576b-4389-a333-efcfa9eddb35", "Consultant", "CONSULTANT" },
                    { new Guid("46e0844f-dc49-4e2b-887d-8980a3fbf9d7"), "5882c063-5373-4cc1-a274-61fd692e310d", "Owner", "OWNER" },
                    { new Guid("6cbc0f2e-d797-49f0-8fbb-c42abf6befea"), "8d5b058d-9aa2-4bc1-940e-d6222475368f", "Admin", "ADMIN" },
                    { new Guid("be0b823b-fa83-4421-b825-0ed842166bf3"), "68946a16-4f83-4dd3-8e63-17a8410a55d5", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("33c54e4d-1a66-4241-bb2a-173acf08a43c"), 0, "59a0983e-4499-421e-bd36-d5c97e178aa6", new DateTime(2025, 3, 30, 10, 44, 3, 210, DateTimeKind.Local).AddTicks(389), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$XuTRnaO0OkHt9oOCxKt1gOJUj477/ywqJWmS1Ix3yMjpUDKgSQ/hy", "(99) 99999-9995", false, "e11578cc-416a-4c78-bece-b84a62925a10", 0, false, new DateTime(2025, 3, 30, 10, 44, 3, 210, DateTimeKind.Local).AddTicks(381), "charlie" },
                    { new Guid("4371a608-5090-48e9-922f-dd73f301af7b"), 0, "23b6850d-de23-47e6-b1ac-c6ca66ac0104", new DateTime(2025, 3, 30, 10, 44, 3, 210, DateTimeKind.Local).AddTicks(335), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$EAFqRElS3NP1ZAi6P2bKSOzmf7WfNX78Y2z7/u5b7ucnHitTays/u", "(99) 99999-9993", false, "4e6b793a-ee0e-4be0-b0c6-89cfe558807a", 0, false, new DateTime(2025, 3, 30, 10, 44, 3, 210, DateTimeKind.Local).AddTicks(327), "alice" },
                    { new Guid("b05df9b0-c6bf-4db9-b281-bd219b45640c"), 0, "db04a3a4-7f40-4558-816c-cd3e5bffaf2b", new DateTime(2025, 3, 30, 10, 44, 3, 210, DateTimeKind.Local).AddTicks(324), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$OsierzzB3DTuJ4J5x38s3OLrRzMWtM8bJ3XDxKbCOA0icGi6SHuJO", "(99) 99999-9992", false, "1c35862b-385b-4a47-9829-0f777c800be3", 0, false, new DateTime(2025, 3, 30, 10, 44, 3, 210, DateTimeKind.Local).AddTicks(279), "jane" },
                    { new Guid("dbac9f8f-9525-425f-af61-9e6176f9c20f"), 0, "d67fffd6-4769-4094-b9a7-3752ee2a2bbb", new DateTime(2025, 3, 30, 10, 44, 3, 210, DateTimeKind.Local).AddTicks(380), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$SzjdxdFOKtFfQ9RtSFnq/OMaaY8gaacIGimlA/5cG8I8jW6BMQbym", "(99) 99999-9994", false, "09103fa5-53e8-4cb3-88ec-f467e43786b9", 0, false, new DateTime(2025, 3, 30, 10, 44, 3, 210, DateTimeKind.Local).AddTicks(362), "bob" },
                    { new Guid("fab7976e-17b9-4e53-9b97-3122058f5677"), 0, "bd84ac41-13de-47f9-93ed-3f04c519e408", new DateTime(2025, 3, 30, 10, 44, 3, 209, DateTimeKind.Local).AddTicks(9699), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$JFcFd1zHhg9QTP95Wweib.Pwaowid8rY2wNJbRJqr5ZPqZsRboOPC", "(99) 99999-9991", false, "58d902a7-1ecf-453c-858a-25e2063f9748", 0, false, new DateTime(2025, 3, 30, 10, 44, 3, 209, DateTimeKind.Local).AddTicks(5453), "john" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0dd9bdd4-3cf4-4643-9f58-dab5798fa414"), new Guid("33c54e4d-1a66-4241-bb2a-173acf08a43c") },
                    { new Guid("240d28ea-5a5b-4787-afa9-1edc839ff664"), new Guid("4371a608-5090-48e9-922f-dd73f301af7b") },
                    { new Guid("46e0844f-dc49-4e2b-887d-8980a3fbf9d7"), new Guid("b05df9b0-c6bf-4db9-b281-bd219b45640c") },
                    { new Guid("be0b823b-fa83-4421-b825-0ed842166bf3"), new Guid("dbac9f8f-9525-425f-af61-9e6176f9c20f") },
                    { new Guid("6cbc0f2e-d797-49f0-8fbb-c42abf6befea"), new Guid("fab7976e-17b9-4e53-9b97-3122058f5677") }
                });
        }
    }
}
