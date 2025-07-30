using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatediagnosis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "Result",
                keyValue: null,
                column: "Result",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "Diagnoses",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Diagnoses",
                keyColumn: "PhotoUrl",
                keyValue: null,
                column: "PhotoUrl",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Diagnoses",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_FarmId",
                table: "Diagnoses",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_HarvestId",
                table: "Diagnoses",
                column: "HarvestId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_PlotId",
                table: "Diagnoses",
                column: "PlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Farms_FarmId",
                table: "Diagnoses",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Harvests_HarvestId",
                table: "Diagnoses",
                column: "HarvestId",
                principalTable: "Harvests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Plots_PlotId",
                table: "Diagnoses",
                column: "PlotId",
                principalTable: "Plots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Farms_FarmId",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Harvests_HarvestId",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Plots_PlotId",
                table: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_FarmId",
                table: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_HarvestId",
                table: "Diagnoses");

            migrationBuilder.DropIndex(
                name: "IX_Diagnoses_PlotId",
                table: "Diagnoses");

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

            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "Diagnoses",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Diagnoses",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true,
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
    }
}
