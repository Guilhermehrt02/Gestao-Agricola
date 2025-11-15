using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatefarmandplotwithlocationShapes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4f80ff37-cf53-4f49-af3e-9f611d7e7330"), new Guid("5b9b8f70-99cc-4f28-9eca-f47ec83f057e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("59cdc955-f5c6-489a-8348-bff27410613d"), new Guid("6532d97e-6e87-4033-bd36-4fa873b471db") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("14368e8c-2a24-4fe9-999a-024086dd73e1"), new Guid("c2e7440e-d11d-4622-a90f-a90b66a66e3b") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("65ac8382-6e61-4734-9d95-5738966560a2"), new Guid("dcc30bfd-feb8-421b-a928-7db9bcf45696") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9026237a-1dfc-48e8-897e-c84c78feb1f5"), new Guid("e8bd43cf-53c8-41f0-b88a-636bc17c8c4d") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("14368e8c-2a24-4fe9-999a-024086dd73e1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4f80ff37-cf53-4f49-af3e-9f611d7e7330"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("59cdc955-f5c6-489a-8348-bff27410613d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65ac8382-6e61-4734-9d95-5738966560a2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9026237a-1dfc-48e8-897e-c84c78feb1f5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5b9b8f70-99cc-4f28-9eca-f47ec83f057e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6532d97e-6e87-4033-bd36-4fa873b471db"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c2e7440e-d11d-4622-a90f-a90b66a66e3b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dcc30bfd-feb8-421b-a928-7db9bcf45696"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e8bd43cf-53c8-41f0-b88a-636bc17c8c4d"));

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "LocationShapes",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Label",
                table: "LocationShapes",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "DiagnosisId",
                table: "LocationShapes",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "FarmId",
                table: "LocationShapes",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "PlotId",
                table: "LocationShapes",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("049222e9-d1e4-42cd-b8dc-7710ebf7bc1c"), "53ceefa1-9110-4db2-a775-8da2d2fb446f", "Consultant", "CONSULTANT" },
                    { new Guid("746ba73c-9755-4859-8ecf-fc10697a678b"), "8ed6e67f-8dff-43d2-8e95-2fc801c35978", "Collaborator", "COLLABORATOR" },
                    { new Guid("a3be1252-bad1-42de-9eb6-094eb988cafa"), "55897452-e0a0-4f83-9dd2-a1a62decdc71", "Owner", "OWNER" },
                    { new Guid("b0820221-8f58-4ef2-b180-f9cdff8bf20c"), "79edcaa9-3ec4-4daa-ba18-669d0f683fbf", "Admin", "ADMIN" },
                    { new Guid("e2c71dca-ab73-4779-b126-b0ad535a0d15"), "795a315c-9c3a-42c1-a9ff-e7da773c5880", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("2b37329b-c879-4098-99e6-fe33ab72e8d3"), 0, "b6ddd80d-bd14-4e21-8a30-65ecf38d0cc1", new DateTime(2025, 11, 14, 9, 2, 37, 409, DateTimeKind.Local).AddTicks(2887), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$snvWsic0CdZfuBB0SKW3yuDab8LX9DY.bcQLoftHHUY.lJJ7lA/te", "(99) 99999-9995", false, "426548ab-eba3-4405-9edb-54bec72922c9", 0, false, new DateTime(2025, 11, 14, 9, 2, 37, 409, DateTimeKind.Local).AddTicks(2881), "charlie" },
                    { new Guid("48f46e6c-676c-49db-9e45-796fb4a593e2"), 0, "c191e3da-e3df-41bc-9514-d88cf44ec3ec", new DateTime(2025, 11, 14, 9, 2, 37, 409, DateTimeKind.Local).AddTicks(2855), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$0frIP4Vignlj8ZNvJ4UnFODTMTlkIy9Ay086KkPliesPlZ4kOpvcq", "(99) 99999-9992", false, "7a9224ab-00ce-42be-a713-5e5b8c77b908", 0, false, new DateTime(2025, 11, 14, 9, 2, 37, 409, DateTimeKind.Local).AddTicks(2677), "jane" },
                    { new Guid("61a7429f-9584-408d-84ef-34774ad4c72a"), 0, "f7a26f9e-d9bf-405a-8bfe-059cbf1410ee", new DateTime(2025, 11, 14, 9, 2, 37, 409, DateTimeKind.Local).AddTicks(2197), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$1yqveDiR95gyXYUrQGvzk.1sA4WoDYGraP2a.XnvRFljv/NijD8hW", "(99) 99999-9991", false, "ff22d795-a6a8-47ae-b5bb-bdbcd1527f81", 0, false, new DateTime(2025, 11, 14, 9, 2, 37, 408, DateTimeKind.Local).AddTicks(8835), "john" },
                    { new Guid("71b03928-5144-4b04-97dc-974be2a1ffa4"), 0, "998a1617-70be-49fd-a0d7-e4934fa5b7ca", new DateTime(2025, 11, 14, 9, 2, 37, 409, DateTimeKind.Local).AddTicks(2880), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$LFvITd2fg24agkI9wU7xQOLVsrn9ttcTAzAFFfq3yR3NYqeq6ftCK", "(99) 99999-9994", false, "c2ec167f-7a4c-408a-a652-a88f4789c052", 0, false, new DateTime(2025, 11, 14, 9, 2, 37, 409, DateTimeKind.Local).AddTicks(2866), "bob" },
                    { new Guid("82c89fff-4c25-4bb2-8a3c-5643c637ee23"), 0, "2af7443f-76a8-4b4d-b7df-f07e50241fb4", new DateTime(2025, 11, 14, 9, 2, 37, 409, DateTimeKind.Local).AddTicks(2864), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$gwEzq71BcCNcIvygbPZ4j.FgZyaLQdxz.qZYiTcf9dXZqoXHsXzqu", "(99) 99999-9993", false, "d6f124a9-1bf7-48a9-9688-238e65853543", 0, false, new DateTime(2025, 11, 14, 9, 2, 37, 409, DateTimeKind.Local).AddTicks(2858), "alice" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("746ba73c-9755-4859-8ecf-fc10697a678b"), new Guid("2b37329b-c879-4098-99e6-fe33ab72e8d3") },
                    { new Guid("a3be1252-bad1-42de-9eb6-094eb988cafa"), new Guid("48f46e6c-676c-49db-9e45-796fb4a593e2") },
                    { new Guid("b0820221-8f58-4ef2-b180-f9cdff8bf20c"), new Guid("61a7429f-9584-408d-84ef-34774ad4c72a") },
                    { new Guid("e2c71dca-ab73-4779-b126-b0ad535a0d15"), new Guid("71b03928-5144-4b04-97dc-974be2a1ffa4") },
                    { new Guid("049222e9-d1e4-42cd-b8dc-7710ebf7bc1c"), new Guid("82c89fff-4c25-4bb2-8a3c-5643c637ee23") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationShapes_FarmId",
                table: "LocationShapes",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationShapes_PlotId",
                table: "LocationShapes",
                column: "PlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationShapes_Farms_FarmId",
                table: "LocationShapes",
                column: "FarmId",
                principalTable: "Farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationShapes_Plots_PlotId",
                table: "LocationShapes",
                column: "PlotId",
                principalTable: "Plots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationShapes_Farms_FarmId",
                table: "LocationShapes");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationShapes_Plots_PlotId",
                table: "LocationShapes");

            migrationBuilder.DropIndex(
                name: "IX_LocationShapes_FarmId",
                table: "LocationShapes");

            migrationBuilder.DropIndex(
                name: "IX_LocationShapes_PlotId",
                table: "LocationShapes");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("746ba73c-9755-4859-8ecf-fc10697a678b"), new Guid("2b37329b-c879-4098-99e6-fe33ab72e8d3") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a3be1252-bad1-42de-9eb6-094eb988cafa"), new Guid("48f46e6c-676c-49db-9e45-796fb4a593e2") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b0820221-8f58-4ef2-b180-f9cdff8bf20c"), new Guid("61a7429f-9584-408d-84ef-34774ad4c72a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e2c71dca-ab73-4779-b126-b0ad535a0d15"), new Guid("71b03928-5144-4b04-97dc-974be2a1ffa4") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("049222e9-d1e4-42cd-b8dc-7710ebf7bc1c"), new Guid("82c89fff-4c25-4bb2-8a3c-5643c637ee23") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("049222e9-d1e4-42cd-b8dc-7710ebf7bc1c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("746ba73c-9755-4859-8ecf-fc10697a678b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a3be1252-bad1-42de-9eb6-094eb988cafa"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b0820221-8f58-4ef2-b180-f9cdff8bf20c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2c71dca-ab73-4779-b126-b0ad535a0d15"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2b37329b-c879-4098-99e6-fe33ab72e8d3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("48f46e6c-676c-49db-9e45-796fb4a593e2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("61a7429f-9584-408d-84ef-34774ad4c72a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("71b03928-5144-4b04-97dc-974be2a1ffa4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("82c89fff-4c25-4bb2-8a3c-5643c637ee23"));

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "LocationShapes");

            migrationBuilder.DropColumn(
                name: "PlotId",
                table: "LocationShapes");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "LocationShapes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Label",
                table: "LocationShapes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "DiagnosisId",
                table: "LocationShapes",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("14368e8c-2a24-4fe9-999a-024086dd73e1"), "82442b94-4efe-452f-8581-b665f50efdcf", "Admin", "ADMIN" },
                    { new Guid("4f80ff37-cf53-4f49-af3e-9f611d7e7330"), "6002afb8-3ba7-4736-a1d1-ac56a02854b7", "Owner", "OWNER" },
                    { new Guid("59cdc955-f5c6-489a-8348-bff27410613d"), "651ee883-df2b-4904-8f3d-785991f946a2", "Manager", "MANAGER" },
                    { new Guid("65ac8382-6e61-4734-9d95-5738966560a2"), "f6d8d3cb-d9b7-4330-b577-6dffc26c3e54", "Collaborator", "COLLABORATOR" },
                    { new Guid("9026237a-1dfc-48e8-897e-c84c78feb1f5"), "52438a19-ca21-4a3a-b55d-3d9161fe9f91", "Consultant", "CONSULTANT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("5b9b8f70-99cc-4f28-9eca-f47ec83f057e"), 0, "44f44886-36cc-4809-87c8-f2ea7958cf69", new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1835), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$KovIEQee1DlTs/eLvQd5E.xQ1ppA9A3Dl7Xwf8hHKWaAR2jHZzfpe", "(99) 99999-9992", false, "8c3017e5-f3d2-4522-8b6b-a2e4c295305c", 0, false, new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1815), "jane" },
                    { new Guid("6532d97e-6e87-4033-bd36-4fa873b471db"), 0, "7c51c246-640a-41f8-a195-d818915130cf", new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1848), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$yWf7N/ZC5dsV0QI9U1wKDuc6fPBwY3Ps6uEWVtV02tEjpIcx2toFW", "(99) 99999-9994", false, "e07871e9-0956-4882-acdf-6af22cc70962", 0, false, new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1845), "bob" },
                    { new Guid("c2e7440e-d11d-4622-a90f-a90b66a66e3b"), 0, "861cc077-8119-4592-8a2a-516e2fa1b3d0", new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1419), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$IDAadJTAUJ8DQAjuvteW.eehSnf1P7Vch88CnoVPpGRpuIq.ErAjS", "(99) 99999-9991", false, "614ea983-ec30-4c97-824a-5a4769620351", 0, false, new DateTime(2025, 9, 23, 17, 55, 25, 465, DateTimeKind.Local).AddTicks(9369), "john" },
                    { new Guid("dcc30bfd-feb8-421b-a928-7db9bcf45696"), 0, "6b4fc12a-404f-4df8-b54a-97f98eeffebb", new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1860), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$JQsX7J/y9DvlCmjAshQAlOV/ackGkJq6/ayNQb2gFQJz73VodogIq", "(99) 99999-9995", false, "7c072e77-2cef-4e87-be70-80e9b868d7e8", 0, false, new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1849), "charlie" },
                    { new Guid("e8bd43cf-53c8-41f0-b88a-636bc17c8c4d"), 0, "fcd3e3c8-db4d-4988-9063-a2b39c356f6c", new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1844), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$ZPMmuS9nSrgtdFL6TDP/xOltc4MC6IyrdR8ujqnTdinGAT6n7SzAa", "(99) 99999-9993", false, "013c6755-6236-4769-8a15-5a09dc7d107c", 0, false, new DateTime(2025, 9, 23, 17, 55, 25, 466, DateTimeKind.Local).AddTicks(1836), "alice" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4f80ff37-cf53-4f49-af3e-9f611d7e7330"), new Guid("5b9b8f70-99cc-4f28-9eca-f47ec83f057e") },
                    { new Guid("59cdc955-f5c6-489a-8348-bff27410613d"), new Guid("6532d97e-6e87-4033-bd36-4fa873b471db") },
                    { new Guid("14368e8c-2a24-4fe9-999a-024086dd73e1"), new Guid("c2e7440e-d11d-4622-a90f-a90b66a66e3b") },
                    { new Guid("65ac8382-6e61-4734-9d95-5738966560a2"), new Guid("dcc30bfd-feb8-421b-a928-7db9bcf45696") },
                    { new Guid("9026237a-1dfc-48e8-897e-c84c78feb1f5"), new Guid("e8bd43cf-53c8-41f0-b88a-636bc17c8c4d") }
                });
        }
    }
}
