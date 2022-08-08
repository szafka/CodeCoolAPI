﻿// <auto-generated />
using System;
using CodeCoolAPI.Data.Model.API_Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeCoolAPI.Data.Migrations
{
    [DbContext(typeof(API_Context))]
    [Migration("20220808123228_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CodeCoolAPI.Data.Model.CodecoolDataModel.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("CodeCoolAPI.Data.Model.CodecoolDataModel.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaterialId"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaterialTypeTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("MaterialId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("MaterialTypeTypeId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("CodeCoolAPI.Data.Model.CodecoolDataModel.MaterialType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("MaterialTypes");

                    b.HasData(
                        new
                        {
                            TypeId = 1,
                            Description = "Outline of definition in .pdf type file",
                            Type = "Pdf file"
                        },
                        new
                        {
                            TypeId = 2,
                            Description = "Ebook-materil with lectures read by the author",
                            Type = "Ebook"
                        },
                        new
                        {
                            TypeId = 3,
                            Description = "Video-tutorial with developed step-by-step examples",
                            Type = "Video"
                        },
                        new
                        {
                            TypeId = 4,
                            Description = "WorkBook with definitions, samples, excersices, answers",
                            Type = "WorkBook"
                        });
                });

            modelBuilder.Entity("CodeCoolAPI.Data.Model.CodecoolDataModel.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"), 1L, 1);

                    b.Property<string>("AdminName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReviewId");

                    b.HasIndex("AdminName");

                    b.HasIndex("MaterialId");

                    b.HasIndex("UserName");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("CodeCoolAPI.Data.Model.UsersModel.Admin", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("CredentialsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.HasIndex("CredentialsId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("CodeCoolAPI.Data.Model.UsersModel.CredentialsContainer", b =>
                {
                    b.Property<Guid>("CredentialsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("CredentialsId");

                    b.ToTable("CredentialsContainers");

                    b.HasData(
                        new
                        {
                            CredentialsId = new Guid("ac0b5af3-7368-414a-b40c-ccb9c97adeae"),
                            Login = "admin",
                            Password = "admin",
                            PasswordHash = new byte[] { 191, 110, 172, 67, 69, 98, 85, 107, 66, 227, 115, 167, 200, 170, 151, 56, 7, 27, 50, 231, 126, 34, 51, 71, 40, 63, 31, 72, 66, 144, 54, 149, 53, 80, 32, 76, 114, 93, 149, 193, 7, 167, 96, 254, 208, 75, 251, 67, 114, 172, 248, 227, 158, 83, 31, 5, 176, 93, 186, 47, 86, 169, 225, 156 },
                            PasswordSalt = new byte[] { 188, 68, 85, 250, 95, 131, 16, 157, 42, 204, 201, 149, 124, 208, 195, 53, 237, 167, 171, 174, 202, 143, 97, 28, 28, 52, 205, 112, 52, 96, 241, 142, 50, 174, 178, 140, 253, 103, 239, 62, 175, 211, 174, 53, 64, 84, 15, 159, 246, 146, 24, 153, 38, 189, 194, 198, 211, 78, 175, 42, 157, 122, 206, 242, 8, 238, 22, 130, 136, 1, 88, 180, 43, 134, 227, 174, 199, 16, 29, 65, 113, 64, 11, 20, 47, 15, 21, 68, 214, 179, 229, 80, 202, 199, 200, 94, 213, 56, 132, 99, 240, 217, 71, 207, 159, 153, 156, 40, 213, 88, 188, 134, 42, 168, 127, 52, 171, 238, 96, 190, 215, 167, 58, 73, 55, 252, 230, 105 }
                        });
                });

            modelBuilder.Entity("CodeCoolAPI.Data.Model.UsersModel.User", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("CredentialsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.HasIndex("CredentialsId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CodeCoolAPI.Data.Model.CodecoolDataModel.Material", b =>
                {
                    b.HasOne("CodeCoolAPI.Data.Model.CodecoolDataModel.Author", "Author")
                        .WithMany("Materials")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeCoolAPI.Data.Model.CodecoolDataModel.MaterialType", "MaterialType")
                        .WithMany("Materials")
                        .HasForeignKey("MaterialTypeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("MaterialType");
                });

            modelBuilder.Entity("CodeCoolAPI.Data.Model.CodecoolDataModel.Review", b =>
                {
                    b.HasOne("CodeCoolAPI.Data.Model.UsersModel.Admin", null)
                        .WithMany("Reviews")
                        .HasForeignKey("AdminName");

                    b.HasOne("CodeCoolAPI.Data.Model.CodecoolDataModel.Material", "Material")
                        .WithMany("Reviews")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeCoolAPI.Data.Model.UsersModel.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CodeCoolAPI.Data.Model.UsersModel.Admin", b =>
                {
                    b.HasOne("CodeCoolAPI.Data.Model.UsersModel.CredentialsContainer", "Credentials")
                        .WithMany()
                        .HasForeignKey("CredentialsId");

                    b.Navigation("Credentials");
                });

            modelBuilder.Entity("CodeCoolAPI.Data.Model.UsersModel.User", b =>
                {
                    b.HasOne("CodeCoolAPI.Data.Model.UsersModel.CredentialsContainer", "Credentials")
                        .WithMany()
                        .HasForeignKey("CredentialsId");

                    b.Navigation("Credentials");
                });

            modelBuilder.Entity("CodeCoolAPI.Data.Model.CodecoolDataModel.Author", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("CodeCoolAPI.Data.Model.CodecoolDataModel.Material", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("CodeCoolAPI.Data.Model.CodecoolDataModel.MaterialType", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("CodeCoolAPI.Data.Model.UsersModel.Admin", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("CodeCoolAPI.Data.Model.UsersModel.User", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}