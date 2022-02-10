﻿// <auto-generated />
using System;
using HelpDesk.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HelpDesk.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220210020724_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HelpDesk.Models.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Address");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AddressEntity");
                });

            modelBuilder.Entity("HelpDesk.Models.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("HelpDesk.Models.PersonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("IdBranch")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("HelpDesk.Models.ProductAssignmentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAssignment")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductAssignment");
                });

            modelBuilder.Entity("HelpDesk.Models.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateStop")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ProductStatusId")
                        .HasColumnType("int");

                    b.Property<string>("SerieNumber")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("HelpDesk.Models.ProductStatusEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("ProductStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateRegistration = new DateTime(2022, 2, 9, 20, 7, 23, 644, DateTimeKind.Local).AddTicks(1857),
                            IsActive = true,
                            Name = "Activo"
                        },
                        new
                        {
                            Id = 2,
                            DateRegistration = new DateTime(2022, 2, 9, 20, 7, 23, 653, DateTimeKind.Local).AddTicks(2724),
                            IsActive = true,
                            Name = "Asignado"
                        },
                        new
                        {
                            Id = 3,
                            DateRegistration = new DateTime(2022, 2, 9, 20, 7, 23, 653, DateTimeKind.Local).AddTicks(3284),
                            IsActive = true,
                            Name = "Merma"
                        },
                        new
                        {
                            Id = 4,
                            DateRegistration = new DateTime(2022, 2, 9, 20, 7, 23, 653, DateTimeKind.Local).AddTicks(3291),
                            IsActive = true,
                            Name = "Baja por daño"
                        },
                        new
                        {
                            Id = 5,
                            DateRegistration = new DateTime(2022, 2, 9, 20, 7, 23, 653, DateTimeKind.Local).AddTicks(3295),
                            IsActive = true,
                            Name = "Recuperado"
                        });
                });

            modelBuilder.Entity("HelpDesk.Models.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            DateRegistration = new DateTime(2022, 2, 9, 20, 7, 23, 655, DateTimeKind.Local).AddTicks(3030),
                            IsActive = true,
                            Name = "Operador"
                        },
                        new
                        {
                            Id = 1,
                            DateRegistration = new DateTime(2022, 2, 9, 20, 7, 23, 655, DateTimeKind.Local).AddTicks(3068),
                            IsActive = true,
                            Name = "Administrador"
                        });
                });

            modelBuilder.Entity("HelpDesk.Models.TypeBranchEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BranchEntityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("BranchEntityId");

                    b.ToTable("TypeBranch");
                });

            modelBuilder.Entity("HelpDesk.Models.UserEntity", b =>
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

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

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
                            DateRegistration = new DateTime(2022, 2, 9, 20, 7, 23, 655, DateTimeKind.Local).AddTicks(6354),
                            IdRol = 1,
                            IsActive = true,
                            LastName = "",
                            Name = "Administrador",
                            Password = "123456",
                            UserName = "administrador"
                        });
                });

            modelBuilder.Entity("HelpDesk.Models.BranchEntity", b =>
                {
                    b.HasBaseType("HelpDesk.Models.AddressEntity");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.Property<int>("IdTypeBranch")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Note")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasIndex("AddressId");

                    b.HasDiscriminator().HasValue("BranchEntity");
                });

            modelBuilder.Entity("HelpDesk.Models.CompanyEntity", b =>
                {
                    b.HasBaseType("HelpDesk.Models.AddressEntity");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int")
                        .HasColumnName("CompanyEntity_AddressId");

                    b.Property<int?>("BranchEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("CompanyEntity_Name");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("CompanyEntity_Note");

                    b.HasIndex("AddressId");

                    b.HasIndex("BranchEntityId");

                    b.HasDiscriminator().HasValue("CompanyEntity");
                });

            modelBuilder.Entity("HelpDesk.Models.RoleEntity", b =>
                {
                    b.HasOne("HelpDesk.Models.UserEntity", null)
                        .WithMany("Role")
                        .HasForeignKey("UserEntityId");
                });

            modelBuilder.Entity("HelpDesk.Models.TypeBranchEntity", b =>
                {
                    b.HasOne("HelpDesk.Models.BranchEntity", null)
                        .WithMany("ListTypeBranchs")
                        .HasForeignKey("BranchEntityId");
                });

            modelBuilder.Entity("HelpDesk.Models.BranchEntity", b =>
                {
                    b.HasOne("HelpDesk.Models.AddressEntity", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("HelpDesk.Models.CompanyEntity", b =>
                {
                    b.HasOne("HelpDesk.Models.AddressEntity", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("HelpDesk.Models.BranchEntity", null)
                        .WithMany("ListCompanies")
                        .HasForeignKey("BranchEntityId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("HelpDesk.Models.UserEntity", b =>
                {
                    b.Navigation("Role");
                });

            modelBuilder.Entity("HelpDesk.Models.BranchEntity", b =>
                {
                    b.Navigation("ListCompanies");

                    b.Navigation("ListTypeBranchs");
                });
#pragma warning restore 612, 618
        }
    }
}