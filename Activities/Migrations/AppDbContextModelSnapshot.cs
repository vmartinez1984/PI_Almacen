﻿// <auto-generated />
using System;
using Activities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Activities.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Activities.Models.ActivityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivityStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("Activities.Models.ActivityStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ActivityStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateRegistration = new DateTime(2022, 2, 11, 22, 12, 42, 345, DateTimeKind.Local).AddTicks(4555),
                            IsActive = true,
                            Name = "Por hacer"
                        },
                        new
                        {
                            Id = 2,
                            DateRegistration = new DateTime(2022, 2, 11, 22, 12, 42, 357, DateTimeKind.Local).AddTicks(566),
                            IsActive = true,
                            Name = "Haciendo"
                        },
                        new
                        {
                            Id = 3,
                            DateRegistration = new DateTime(2022, 2, 11, 22, 12, 42, 357, DateTimeKind.Local).AddTicks(655),
                            IsActive = true,
                            Name = "Hecho"
                        });
                });

            modelBuilder.Entity("Activities.Models.CommentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("RowEntityId")
                        .HasColumnType("int");

                    b.Property<int>("RowId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RowEntityId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("Activities.Models.FileEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RowId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RowId");

                    b.HasIndex("UserId");

                    b.ToTable("File");
                });

            modelBuilder.Entity("Activities.Models.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            DateRegistration = new DateTime(2022, 2, 11, 22, 12, 42, 359, DateTimeKind.Local).AddTicks(3846),
                            IsActive = true,
                            Name = "Operador"
                        },
                        new
                        {
                            Id = 1,
                            DateRegistration = new DateTime(2022, 2, 11, 22, 12, 42, 359, DateTimeKind.Local).AddTicks(3873),
                            IsActive = true,
                            Name = "Administrador"
                        });
                });

            modelBuilder.Entity("Activities.Models.RowEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivityEntityId")
                        .HasColumnType("int");

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStop")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RowStatusId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivityEntityId");

                    b.HasIndex("RowStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Row");
                });

            modelBuilder.Entity("Activities.Models.RowStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("RowStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateRegistration = new DateTime(2022, 2, 11, 22, 12, 42, 359, DateTimeKind.Local).AddTicks(2185),
                            IsActive = true,
                            Name = "Listo"
                        },
                        new
                        {
                            Id = 2,
                            DateRegistration = new DateTime(2022, 2, 11, 22, 12, 42, 359, DateTimeKind.Local).AddTicks(2221),
                            IsActive = true,
                            Name = "En proceso"
                        },
                        new
                        {
                            Id = 3,
                            DateRegistration = new DateTime(2022, 2, 11, 22, 12, 42, 359, DateTimeKind.Local).AddTicks(2226),
                            IsActive = true,
                            Name = "Estancado"
                        });
                });

            modelBuilder.Entity("Activities.Models.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConfirmPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateRegistration = new DateTime(2022, 2, 11, 22, 12, 42, 359, DateTimeKind.Local).AddTicks(7432),
                            IsActive = true,
                            LastName = "",
                            Name = "Administrador",
                            Password = "123456",
                            RolId = 1,
                            UserName = "administrador"
                        });
                });

            modelBuilder.Entity("Activities.Models.UsersInRowEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("RowId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RowId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersInRow");
                });

            modelBuilder.Entity("Activities.Models.ActivityEntity", b =>
                {
                    b.HasOne("Activities.Models.ActivityStatusEntity", "ActivityStatus")
                        .WithMany()
                        .HasForeignKey("ActivityStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Activities.Models.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActivityStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Activities.Models.CommentEntity", b =>
                {
                    b.HasOne("Activities.Models.RowEntity", null)
                        .WithMany("ListComments")
                        .HasForeignKey("RowEntityId");

                    b.HasOne("Activities.Models.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Activities.Models.FileEntity", b =>
                {
                    b.HasOne("Activities.Models.RowEntity", "Row")
                        .WithMany()
                        .HasForeignKey("RowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Activities.Models.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Row");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Activities.Models.RoleEntity", b =>
                {
                    b.HasOne("Activities.Models.UserEntity", null)
                        .WithMany("Role")
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("Activities.Models.RowEntity", b =>
                {
                    b.HasOne("Activities.Models.ActivityEntity", null)
                        .WithMany("ListRows")
                        .HasForeignKey("ActivityEntityId");

                    b.HasOne("Activities.Models.RowStatusEntity", "RowStatus")
                        .WithMany()
                        .HasForeignKey("RowStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Activities.Models.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RowStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Activities.Models.UsersInRowEntity", b =>
                {
                    b.HasOne("Activities.Models.RowEntity", "Row")
                        .WithMany()
                        .HasForeignKey("RowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Activities.Models.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Row");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Activities.Models.ActivityEntity", b =>
                {
                    b.Navigation("ListRows");
                });

            modelBuilder.Entity("Activities.Models.RowEntity", b =>
                {
                    b.Navigation("ListComments");
                });

            modelBuilder.Entity("Activities.Models.UserEntity", b =>
                {
                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
