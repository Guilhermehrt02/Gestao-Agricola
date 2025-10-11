using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class diseaseentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageSimilarity_DiagnosisResults_DiagnosisResultId1",
                table: "ImageSimilarity");

            migrationBuilder.DropIndex(
                name: "IX_ImageSimilarity_DiagnosisResultId1",
                table: "ImageSimilarity");

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

            migrationBuilder.RenameColumn(
                name: "DiagnosisResultId1",
                table: "ImageSimilarity",
                newName: "DiseaseId");

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Class = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    ReferenceImageUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_ImageSimilarity_DiseaseId",
                table: "ImageSimilarity",
                column: "DiseaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageSimilarity_Diseases_DiseaseId",
                table: "ImageSimilarity",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageSimilarity_Diseases_DiseaseId",
                table: "ImageSimilarity");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropIndex(
                name: "IX_ImageSimilarity_DiseaseId",
                table: "ImageSimilarity");

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

            migrationBuilder.RenameColumn(
                name: "DiseaseId",
                table: "ImageSimilarity",
                newName: "DiagnosisResultId1");

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
                name: "IX_ImageSimilarity_DiagnosisResultId1",
                table: "ImageSimilarity",
                column: "DiagnosisResultId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageSimilarity_DiagnosisResults_DiagnosisResultId1",
                table: "ImageSimilarity",
                column: "DiagnosisResultId1",
                principalTable: "DiagnosisResults",
                principalColumn: "Id");
        }
    }
}
