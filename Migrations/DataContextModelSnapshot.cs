﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication9.Helpers;

namespace WebApplication9.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication9.Entities.Admin", b =>
                {
                    b.Property<int>("AId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AdminUserRef")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AId");

                    b.HasIndex("AdminUserRef")
                        .IsUnique();

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("WebApplication9.Entities.Class", b =>
                {
                    b.Property<int>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearId")
                        .HasColumnType("int");

                    b.HasKey("CId");

                    b.HasIndex("YearId");

                    b.ToTable("ClassInfo");
                });

            modelBuilder.Entity("WebApplication9.Entities.Notification", b =>
                {
                    b.Property<int>("NId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NUserId")
                        .HasColumnType("int");

                    b.Property<string>("Readstatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NId");

                    b.HasIndex("NUserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("WebApplication9.Entities.SchoolYear", b =>
                {
                    b.Property<int>("YearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("YearId");

                    b.ToTable("SchoolYears");
                });

            modelBuilder.Entity("WebApplication9.Entities.Student", b =>
                {
                    b.Property<int>("SId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("StudentUserRef")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SId");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentUserRef")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WebApplication9.Entities.Teacher", b =>
                {
                    b.Property<int>("TId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherUserRef")
                        .HasColumnType("int");

                    b.HasKey("TId");

                    b.HasIndex("TeacherUserRef")
                        .IsUnique();

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("WebApplication9.Entities.TeacherClass", b =>
                {
                    b.Property<int>("TId")
                        .HasColumnType("int");

                    b.Property<int>("CId")
                        .HasColumnType("int");

                    b.HasKey("TId", "CId");

                    b.HasIndex("CId");

                    b.ToTable("TeacherClasses");
                });

            modelBuilder.Entity("WebApplication9.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication9.Entities.Admin", b =>
                {
                    b.HasOne("WebApplication9.Entities.User", "User")
                        .WithOne("Admin")
                        .HasForeignKey("WebApplication9.Entities.Admin", "AdminUserRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication9.Entities.Class", b =>
                {
                    b.HasOne("WebApplication9.Entities.SchoolYear", "SchoolYear")
                        .WithMany("Classes")
                        .HasForeignKey("YearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication9.Entities.Notification", b =>
                {
                    b.HasOne("WebApplication9.Entities.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("NUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication9.Entities.Student", b =>
                {
                    b.HasOne("WebApplication9.Entities.Class", "Classes")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication9.Entities.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("WebApplication9.Entities.Student", "StudentUserRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication9.Entities.Teacher", b =>
                {
                    b.HasOne("WebApplication9.Entities.User", "User")
                        .WithOne("Teacher")
                        .HasForeignKey("WebApplication9.Entities.Teacher", "TeacherUserRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication9.Entities.TeacherClass", b =>
                {
                    b.HasOne("WebApplication9.Entities.Class", "ClassInfo")
                        .WithMany("TeacherClasses")
                        .HasForeignKey("CId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication9.Entities.Teacher", "Teacher")
                        .WithMany("TeacherClasses")
                        .HasForeignKey("TId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
