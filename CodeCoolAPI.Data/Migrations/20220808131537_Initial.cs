using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeCoolAPI.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "CredentialsContainers",
                columns: table => new
                {
                    CredentialsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CredentialsContainers", x => x.CredentialsId);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "BaseUsers",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CredentialsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseUsers", x => x.Name);
                    table.ForeignKey(
                        name: "FK_BaseUsers_CredentialsContainers_CredentialsId",
                        column: x => x.CredentialsId,
                        principalTable: "CredentialsContainers",
                        principalColumn: "CredentialsId");
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "date", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    MaterialTypeTypeId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Materials_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialTypes_MaterialTypeTypeId",
                        column: x => x.MaterialTypeTypeId,
                        principalTable: "MaterialTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    BaseUserName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_BaseUsers_BaseUserName",
                        column: x => x.BaseUserName,
                        principalTable: "BaseUsers",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Reviews_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CredentialsContainers",
                columns: new[] { "CredentialsId", "Login", "Password", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("ac0b5af3-7368-414a-b40c-ccb9c97adeae"), "admin", "admin", new byte[] { 148, 233, 57, 106, 84, 186, 76, 152, 204, 72, 71, 12, 174, 70, 69, 163, 237, 105, 192, 5, 74, 225, 148, 102, 207, 104, 72, 32, 126, 37, 44, 62, 8, 63, 35, 97, 94, 10, 191, 30, 77, 149, 15, 241, 9, 145, 79, 115, 234, 174, 139, 247, 179, 189, 128, 117, 96, 5, 105, 13, 90, 89, 151, 223 }, new byte[] { 163, 230, 214, 114, 53, 176, 159, 62, 15, 106, 123, 240, 229, 141, 168, 31, 200, 112, 171, 241, 87, 24, 95, 207, 195, 60, 62, 187, 255, 240, 228, 104, 49, 104, 178, 180, 193, 241, 139, 57, 169, 208, 161, 132, 45, 117, 176, 223, 64, 200, 78, 58, 151, 233, 158, 250, 230, 245, 77, 236, 121, 99, 53, 88, 187, 240, 84, 117, 240, 209, 0, 195, 61, 138, 110, 129, 132, 205, 30, 51, 12, 30, 249, 176, 248, 215, 43, 136, 171, 23, 241, 227, 128, 180, 67, 198, 186, 122, 229, 152, 82, 131, 71, 43, 241, 213, 48, 9, 47, 89, 120, 38, 101, 19, 63, 251, 22, 217, 223, 253, 35, 168, 211, 190, 38, 19, 68, 239 } });

            migrationBuilder.InsertData(
                table: "MaterialTypes",
                columns: new[] { "TypeId", "Description", "Type" },
                values: new object[,]
                {
                    { 1, "Outline of definition in .pdf type file", "Pdf file" },
                    { 2, "Ebook-materil with lectures read by the author", "Ebook" },
                    { 3, "Video-tutorial with developed step-by-step examples", "Video" },
                    { 4, "WorkBook with definitions, samples, excersices, answers", "WorkBook" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseUsers_CredentialsId",
                table: "BaseUsers",
                column: "CredentialsId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_AuthorId",
                table: "Materials",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialTypeTypeId",
                table: "Materials",
                column: "MaterialTypeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BaseUserName",
                table: "Reviews",
                column: "BaseUserName");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MaterialId",
                table: "Reviews",
                column: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "BaseUsers");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "CredentialsContainers");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "MaterialTypes");
        }
    }
}
