// <auto-generated />
using System;
using Activities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Activities.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220412171036_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("UserId")
                        .IsRequired()
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
                            DateRegistration = new DateTime(2022, 4, 12, 12, 10, 36, 301, DateTimeKind.Local).AddTicks(4129),
                            IsActive = true,
                            Name = "Por hacer"
                        },
                        new
                        {
                            Id = 2,
                            DateRegistration = new DateTime(2022, 4, 12, 12, 10, 36, 304, DateTimeKind.Local).AddTicks(3302),
                            IsActive = true,
                            Name = "Haciendo"
                        },
                        new
                        {
                            Id = 3,
                            DateRegistration = new DateTime(2022, 4, 12, 12, 10, 36, 304, DateTimeKind.Local).AddTicks(3428),
                            IsActive = true,
                            Name = "Hecho"
                        });
                });

            modelBuilder.Entity("Activities.Models.ChatEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UserIdDestiny")
                        .HasColumnType("int");

                    b.Property<int>("UserIdSource")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Chat");
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

                    b.Property<int>("RowId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RowId");

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

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            DateRegistration = new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(6216),
                            IsActive = true,
                            Name = "Lider de equipo"
                        },
                        new
                        {
                            Id = 2,
                            DateRegistration = new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(6231),
                            IsActive = true,
                            Name = "Colaborador"
                        },
                        new
                        {
                            Id = 1,
                            DateRegistration = new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(6235),
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

                    b.Property<int?>("ActivityId")
                        .IsRequired()
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

                    b.HasIndex("ActivityId");

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
                            DateRegistration = new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(5166),
                            IsActive = true,
                            Name = "Listo"
                        },
                        new
                        {
                            Id = 2,
                            DateRegistration = new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(5203),
                            IsActive = true,
                            Name = "En proceso"
                        },
                        new
                        {
                            Id = 3,
                            DateRegistration = new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(5207),
                            IsActive = true,
                            Name = "Estancado"
                        },
                        new
                        {
                            Id = 4,
                            DateRegistration = new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(5210),
                            IsActive = true,
                            Name = "Por hacer"
                        });
                });

            modelBuilder.Entity("Activities.Models.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateRegistration = new DateTime(2022, 4, 12, 12, 10, 36, 305, DateTimeKind.Local).AddTicks(8248),
                            Email = "",
                            IsActive = true,
                            LastName = "",
                            Name = "Administrador",
                            Password = "123456",
                            Phone = "",
                            RoleId = 1,
                            UserName = "administrador"
                        });
                });

            modelBuilder.Entity("Activities.Models.UserOnlineEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserOnline");
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

                    b.Property<int?>("RowId")
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
                    b.HasOne("Activities.Models.RowEntity", "Row")
                        .WithMany("ListComments")
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

            modelBuilder.Entity("Activities.Models.FileEntity", b =>
                {
                    b.HasOne("Activities.Models.RowEntity", "Row")
                        .WithMany("ListFiles")
                        .HasForeignKey("RowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Activities.Models.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Row");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Activities.Models.RowEntity", b =>
                {
                    b.HasOne("Activities.Models.ActivityEntity", "Activity")
                        .WithMany("ListRows")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

                    b.Navigation("Activity");

                    b.Navigation("RowStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Activities.Models.UserEntity", b =>
                {
                    b.HasOne("Activities.Models.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Activities.Models.UserOnlineEntity", b =>
                {
                    b.HasOne("Activities.Models.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Activities.Models.UsersInRowEntity", b =>
                {
                    b.HasOne("Activities.Models.RowEntity", "Row")
                        .WithMany("ListUsersInRow")
                        .HasForeignKey("RowId");

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

                    b.Navigation("ListFiles");

                    b.Navigation("ListUsersInRow");
                });
#pragma warning restore 612, 618
        }
    }
}
