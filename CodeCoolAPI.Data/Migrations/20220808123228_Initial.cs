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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CredentialsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Admins_CredentialsContainers_CredentialsId",
                        column: x => x.CredentialsId,
                        principalTable: "CredentialsContainers",
                        principalColumn: "CredentialsId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CredentialsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Users_CredentialsContainers_CredentialsId",
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    AdminName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Admins_AdminName",
                        column: x => x.AdminName,
                        principalTable: "Admins",
                        principalColumn: "Name");
                    table.ForeignKey(
                        name: "FK_Reviews_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserName",
                        column: x => x.UserName,
                        principalTable: "Users",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CredentialsContainers",
                columns: new[] { "CredentialsId", "Login", "Password", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("ac0b5af3-7368-414a-b40c-ccb9c97adeae"), "admin", "admin", new byte[] { 191, 110, 172, 67, 69, 98, 85, 107, 66, 227, 115, 167, 200, 170, 151, 56, 7, 27, 50, 231, 126, 34, 51, 71, 40, 63, 31, 72, 66, 144, 54, 149, 53, 80, 32, 76, 114, 93, 149, 193, 7, 167, 96, 254, 208, 75, 251, 67, 114, 172, 248, 227, 158, 83, 31, 5, 176, 93, 186, 47, 86, 169, 225, 156 }, new byte[] { 188, 68, 85, 250, 95, 131, 16, 157, 42, 204, 201, 149, 124, 208, 195, 53, 237, 167, 171, 174, 202, 143, 97, 28, 28, 52, 205, 112, 52, 96, 241, 142, 50, 174, 178, 140, 253, 103, 239, 62, 175, 211, 174, 53, 64, 84, 15, 159, 246, 146, 24, 153, 38, 189, 194, 198, 211, 78, 175, 42, 157, 122, 206, 242, 8, 238, 22, 130, 136, 1, 88, 180, 43, 134, 227, 174, 199, 16, 29, 65, 113, 64, 11, 20, 47, 15, 21, 68, 214, 179, 229, 80, 202, 199, 200, 94, 213, 56, 132, 99, 240, 217, 71, 207, 159, 153, 156, 40, 213, 88, 188, 134, 42, 168, 127, 52, 171, 238, 96, 190, 215, 167, 58, 73, 55, 252, 230, 105 } });

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
                name: "IX_Admins_CredentialsId",
                table: "Admins",
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
                name: "IX_Reviews_AdminName",
                table: "Reviews",
                column: "AdminName");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MaterialId",
                table: "Reviews",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserName",
                table: "Reviews",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CredentialsId",
                table: "Users",
                column: "CredentialsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "MaterialTypes");

            migrationBuilder.DropTable(
                name: "CredentialsContainers");
        }
    }
}
