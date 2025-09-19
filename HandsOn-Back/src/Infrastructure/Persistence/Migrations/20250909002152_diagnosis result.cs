using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class diagnosisresult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Diagnoses");

            migrationBuilder.CreateTable(
                name: "DiagnosisResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DiagnosisId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiagnosisResults_Diagnoses_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnoses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ImageSimilarity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DiagnosisResultId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ImageBook = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Similarity = table.Column<double>(type: "double", nullable: false),
                    DiagnosisResultId1 = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageSimilarity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageSimilarity_DiagnosisResults_DiagnosisResultId",
                        column: x => x.DiagnosisResultId,
                        principalTable: "DiagnosisResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageSimilarity_DiagnosisResults_DiagnosisResultId1",
                        column: x => x.DiagnosisResultId1,
                        principalTable: "DiagnosisResults",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("11e5ca33-943c-4492-887f-b58d18437fad"), "e572ad7e-52cc-4f27-832a-10ec298e3080", "Manager", "MANAGER" },
                    { new Guid("52180c39-d5ca-45c8-8cda-db4c976f7d16"), "5e3c9570-33e0-4446-b04b-69d0236a7eda", "Collaborator", "COLLABORATOR" },
                    { new Guid("79c202ea-7ad6-4aa1-ac81-824e50827783"), "9ff06b60-9000-4fd5-a8c3-808c082783bc", "Consultant", "CONSULTANT" },
                    { new Guid("d453d591-1365-4363-9903-22bd1edb395f"), "64dfb93a-ed26-4927-9b10-87c925cb40ef", "Owner", "OWNER" },
                    { new Guid("df6f7d79-9652-472c-bdf2-faf88d74fc70"), "b3322f39-ab8c-4a4a-9cb0-8e00f045356c", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("1a578f22-6617-4f42-9e3c-017454fe474e"), 0, "236dc680-34f7-483e-a79e-35ab6eb38f79", new DateTime(2025, 9, 8, 21, 21, 49, 971, DateTimeKind.Local).AddTicks(5924), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$dtkuNspc2Jg0EM5pL56qpuUi3ObU7sYuOHorcms9wXCawwg3FiY/m", "(99) 99999-9991", false, "4266f2cd-d41d-42ed-a501-f93df879ef0e", 0, false, new DateTime(2025, 9, 8, 21, 21, 49, 971, DateTimeKind.Local).AddTicks(3423), "john" },
                    { new Guid("8d015060-bd48-49b0-a47f-f7bd9ef024ee"), 0, "47659519-0991-4ecb-bf97-6947ec956f43", new DateTime(2025, 9, 8, 21, 21, 49, 971, DateTimeKind.Local).AddTicks(6309), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$o4bQMy8F8vPThwYs/dq7g.JSmJeuPAxgU7pR/jIvH5hDTYWX9EV8K", "(99) 99999-9994", false, "eb72e009-c347-4513-aff2-49e398897b51", 0, false, new DateTime(2025, 9, 8, 21, 21, 49, 971, DateTimeKind.Local).AddTicks(6305), "bob" },
                    { new Guid("a06e545a-14e1-4e7d-95d4-16e51ed66cf0"), 0, "fdefcdd3-8f18-495a-9b87-0037fe007da5", new DateTime(2025, 9, 8, 21, 21, 49, 971, DateTimeKind.Local).AddTicks(6318), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$K.U0e4bCQUuUiiDVyOCMuenGXZsMSeaPlX63EG8.Ys5elgKoyRwKy", "(99) 99999-9995", false, "cce20d35-e69d-4ce1-b38a-6b46d235afc3", 0, false, new DateTime(2025, 9, 8, 21, 21, 49, 971, DateTimeKind.Local).AddTicks(6310), "charlie" },
                    { new Guid("b62eac0f-e7fd-4501-97cf-acabfa8c519d"), 0, "518e1dd6-f1b8-4461-b90e-a9c526b8a2d5", new DateTime(2025, 9, 8, 21, 21, 49, 971, DateTimeKind.Local).AddTicks(6296), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$n.LVgl5AMYoSWJpKFKU0LuMrJhcX68si6cFWd75xpBAd7sjgslZG.", "(99) 99999-9992", false, "56f0e0f1-3aa9-4d44-a86e-3b95dad9c98d", 0, false, new DateTime(2025, 9, 8, 21, 21, 49, 971, DateTimeKind.Local).AddTicks(6258), "jane" },
                    { new Guid("dc835b63-58c9-43d9-a753-f68fe47ea1a5"), 0, "fc8466d0-0132-4a97-a0c5-0ef5c39bb203", new DateTime(2025, 9, 8, 21, 21, 49, 971, DateTimeKind.Local).AddTicks(6303), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$tVQqV1yaHGkO40HtCCLAa.xw0kQ65CaWFqFR2jM1YSv4Om3N/.Taa", "(99) 99999-9993", false, "b9c62b05-704f-4289-a739-113fa70b5302", 0, false, new DateTime(2025, 9, 8, 21, 21, 49, 971, DateTimeKind.Local).AddTicks(6298), "alice" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("df6f7d79-9652-472c-bdf2-faf88d74fc70"), new Guid("1a578f22-6617-4f42-9e3c-017454fe474e") },
                    { new Guid("11e5ca33-943c-4492-887f-b58d18437fad"), new Guid("8d015060-bd48-49b0-a47f-f7bd9ef024ee") },
                    { new Guid("52180c39-d5ca-45c8-8cda-db4c976f7d16"), new Guid("a06e545a-14e1-4e7d-95d4-16e51ed66cf0") },
                    { new Guid("d453d591-1365-4363-9903-22bd1edb395f"), new Guid("b62eac0f-e7fd-4501-97cf-acabfa8c519d") },
                    { new Guid("79c202ea-7ad6-4aa1-ac81-824e50827783"), new Guid("dc835b63-58c9-43d9-a753-f68fe47ea1a5") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisResults_DiagnosisId",
                table: "DiagnosisResults",
                column: "DiagnosisId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageSimilarity_DiagnosisResultId",
                table: "ImageSimilarity",
                column: "DiagnosisResultId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageSimilarity_DiagnosisResultId1",
                table: "ImageSimilarity",
                column: "DiagnosisResultId1",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageSimilarity");

            migrationBuilder.DropTable(
                name: "DiagnosisResults");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("df6f7d79-9652-472c-bdf2-faf88d74fc70"), new Guid("1a578f22-6617-4f42-9e3c-017454fe474e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("11e5ca33-943c-4492-887f-b58d18437fad"), new Guid("8d015060-bd48-49b0-a47f-f7bd9ef024ee") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("52180c39-d5ca-45c8-8cda-db4c976f7d16"), new Guid("a06e545a-14e1-4e7d-95d4-16e51ed66cf0") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d453d591-1365-4363-9903-22bd1edb395f"), new Guid("b62eac0f-e7fd-4501-97cf-acabfa8c519d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("79c202ea-7ad6-4aa1-ac81-824e50827783"), new Guid("dc835b63-58c9-43d9-a753-f68fe47ea1a5") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("11e5ca33-943c-4492-887f-b58d18437fad"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("52180c39-d5ca-45c8-8cda-db4c976f7d16"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("79c202ea-7ad6-4aa1-ac81-824e50827783"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d453d591-1365-4363-9903-22bd1edb395f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("df6f7d79-9652-472c-bdf2-faf88d74fc70"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1a578f22-6617-4f42-9e3c-017454fe474e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8d015060-bd48-49b0-a47f-f7bd9ef024ee"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a06e545a-14e1-4e7d-95d4-16e51ed66cf0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b62eac0f-e7fd-4501-97cf-acabfa8c519d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dc835b63-58c9-43d9-a753-f68fe47ea1a5"));

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Diagnoses",
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
    }
}
