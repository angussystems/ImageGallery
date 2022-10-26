using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MRI.IdentityServer.Migrations
{
    public partial class IdentityServerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Password", "Subject", "UserName" },
                values: new object[] { new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), true, "61f4580e-9905-4c87-9d97-53c46d9b61c8", "password", "d860efca-22d9-47fd-8249-791ba61b07c7", "tom" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "ConcurrencyStamp", "Password", "Subject", "UserName" },
                values: new object[] { new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), true, "95223194-c4c6-4794-87d9-d116caffb520", "password", "b7539694-97e7-4dfe-84da-b4256e1ff5c7", "emma" });

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("2181ef66-8e63-47df-95c6-57045d6c7937"), "4418ebd6-a1d6-4f65-a5d1-efe66f934eda", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Hanks" },
                    { new Guid("2383795a-d5de-4550-9578-adc5ef396a4e"), "d9bc8f69-e899-4e96-93b6-79ef4abb1ce3", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "canada" },
                    { new Guid("263e3a96-a7ee-46ee-a523-0f9babd3d917"), "bcaf8a4a-7481-445a-bf8b-9616a8f35f7f", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Tom" },
                    { new Guid("4c48385e-15e8-4d39-8860-670f5cf4a41e"), "acc383a8-a5a6-408f-9e54-bc3a14047058", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "USA" },
                    { new Guid("54b7f9cd-d102-4e57-99f6-16f20dc96e0c"), "8793b53a-d3ba-476c-a617-e489d270d95e", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("8f7ffb63-96bf-4451-a6a7-3e6ce8b7b9d2"), "dc14163f-5227-4c25-a054-68f7ffc3600a", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("aafb34f1-c7af-4c00-ae8f-90b199271fa9"), "50d7ae64-3596-43fd-af54-7d583a4ed05b", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("cfbaa436-b624-415c-9dc6-b666f7ff7724"), "cab28055-7b15-4a26-b964-5d06a868f4d9", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Subject",
                table: "Users",
                column: "Subject",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
