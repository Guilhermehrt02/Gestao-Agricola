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
                    { new Guid("3aaa8bf1-3a67-4ca5-bc10-407fe3ba1a1c"), "efb081a6-2a0a-4995-9754-7b9502706a80", "Admin", "ADMIN" },
                    { new Guid("bccd86a8-40d6-46e7-9925-7a25156a314c"), "c7caa6c9-efe2-4705-89b3-55a3e857c4c7", "Owner", "OWNER" },
                    { new Guid("cc0ab4ae-8167-49cc-8d11-7c04cdb72249"), "57e50c58-e009-4592-a03b-a96b924bd23c", "Consultant", "CONSULTANT" },
                    { new Guid("d5fc5cd0-2e07-4a83-ae05-d12367f546fa"), "7d9912c9-6f6f-4e1c-9d1d-fbe3b8aef024", "Collaborator", "COLLABORATOR" },
                    { new Guid("efd4bbcb-386c-4840-b096-b962e6271ec0"), "da42e55e-74b9-4f57-8522-bb3289a30a5a", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("00104ec7-2530-4be8-87f6-db8e9139b598"), 0, "55a5d6d7-49ed-4c97-9e71-f51f93e33f34", new DateTime(2025, 11, 12, 23, 7, 49, 385, DateTimeKind.Local).AddTicks(7490), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$2vL0A4ILE/aLEjUvB1Hr3.6nATQ9LAHfEH8jiCSHJX7vKLmP0WNMC", "(99) 99999-9991", false, "5d1a0db4-eb95-45fd-b4bd-fb1f0a0ba01c", 0, false, new DateTime(2025, 11, 12, 23, 7, 49, 385, DateTimeKind.Local).AddTicks(5114), "john" },
                    { new Guid("26a06b51-b139-4fe9-bab4-06785079dc67"), 0, "b2c5321f-26c2-44d0-8fca-d59551dfb88b", new DateTime(2025, 11, 12, 23, 7, 49, 385, DateTimeKind.Local).AddTicks(7821), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$WW.Azd51L7.BG7IsdOsnn.BeXCTmz4nCBrAe/OiSF/ZtJNOGh/N9.", "(99) 99999-9992", false, "a64b535a-e1ac-494a-96aa-213ec137d29a", 0, false, new DateTime(2025, 11, 12, 23, 7, 49, 385, DateTimeKind.Local).AddTicks(7797), "jane" },
                    { new Guid("27956259-f47e-4dd6-a0a9-f738f57c0fc4"), 0, "8aa8947b-5536-4729-9e14-87046fe609d9", new DateTime(2025, 11, 12, 23, 7, 49, 385, DateTimeKind.Local).AddTicks(7844), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$fByFzcEVInzE.QUzzI3PR.BVsX2hPYaWScJjrr5etFr4Pm0y7t/06", "(99) 99999-9995", false, "ed26dc9d-c05c-4e20-a58b-57f1a10cdf9a", 0, false, new DateTime(2025, 11, 12, 23, 7, 49, 385, DateTimeKind.Local).AddTicks(7835), "charlie" },
                    { new Guid("9c5adc79-1b1a-4d48-8da0-9431bbd8052b"), 0, "4f3bfc94-a0a9-4c23-a680-8aaf51ceae8f", new DateTime(2025, 11, 12, 23, 7, 49, 385, DateTimeKind.Local).AddTicks(7834), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$jGKpKkqEBke55YP7nUpCXegjrbeRt463Ui4UB6/wsS2SgdxAZAotK", "(99) 99999-9994", false, "917514d2-3d80-43b2-bb2e-cf0d3121d41c", 0, false, new DateTime(2025, 11, 12, 23, 7, 49, 385, DateTimeKind.Local).AddTicks(7827), "bob" },
                    { new Guid("c189756e-97c6-4abd-8d8e-a2c230c77351"), 0, "50a52501-1359-45a7-b963-e0e744bd99c9", new DateTime(2025, 11, 12, 23, 7, 49, 385, DateTimeKind.Local).AddTicks(7826), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$XboRtXC6przZbOPBcDmKyuDMbeSFjlLH2FqwFCAE2kBAy9qEGbxX.", "(99) 99999-9993", false, "52b7a270-cd96-4452-ab55-e596488a98b1", 0, false, new DateTime(2025, 11, 12, 23, 7, 49, 385, DateTimeKind.Local).AddTicks(7822), "alice" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3aaa8bf1-3a67-4ca5-bc10-407fe3ba1a1c"), new Guid("00104ec7-2530-4be8-87f6-db8e9139b598") },
                    { new Guid("bccd86a8-40d6-46e7-9925-7a25156a314c"), new Guid("26a06b51-b139-4fe9-bab4-06785079dc67") },
                    { new Guid("d5fc5cd0-2e07-4a83-ae05-d12367f546fa"), new Guid("27956259-f47e-4dd6-a0a9-f738f57c0fc4") },
                    { new Guid("efd4bbcb-386c-4840-b096-b962e6271ec0"), new Guid("9c5adc79-1b1a-4d48-8da0-9431bbd8052b") },
                    { new Guid("cc0ab4ae-8167-49cc-8d11-7c04cdb72249"), new Guid("c189756e-97c6-4abd-8d8e-a2c230c77351") }
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
                keyValues: new object[] { new Guid("3aaa8bf1-3a67-4ca5-bc10-407fe3ba1a1c"), new Guid("00104ec7-2530-4be8-87f6-db8e9139b598") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bccd86a8-40d6-46e7-9925-7a25156a314c"), new Guid("26a06b51-b139-4fe9-bab4-06785079dc67") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d5fc5cd0-2e07-4a83-ae05-d12367f546fa"), new Guid("27956259-f47e-4dd6-a0a9-f738f57c0fc4") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("efd4bbcb-386c-4840-b096-b962e6271ec0"), new Guid("9c5adc79-1b1a-4d48-8da0-9431bbd8052b") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cc0ab4ae-8167-49cc-8d11-7c04cdb72249"), new Guid("c189756e-97c6-4abd-8d8e-a2c230c77351") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3aaa8bf1-3a67-4ca5-bc10-407fe3ba1a1c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bccd86a8-40d6-46e7-9925-7a25156a314c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cc0ab4ae-8167-49cc-8d11-7c04cdb72249"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d5fc5cd0-2e07-4a83-ae05-d12367f546fa"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("efd4bbcb-386c-4840-b096-b962e6271ec0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00104ec7-2530-4be8-87f6-db8e9139b598"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("26a06b51-b139-4fe9-bab4-06785079dc67"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("27956259-f47e-4dd6-a0a9-f738f57c0fc4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9c5adc79-1b1a-4d48-8da0-9431bbd8052b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c189756e-97c6-4abd-8d8e-a2c230c77351"));

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "LocationShapes");

            migrationBuilder.DropColumn(
                name: "PlotId",
                table: "LocationShapes");

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
