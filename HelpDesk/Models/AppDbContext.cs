using Microsoft.EntityFrameworkCore;
using System;

namespace HelpDesk.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<BranchEntity> Branch { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<CompanyEntity> Company { get; set; }
        public DbSet<PersonEntity> Person { get; set; }
        public DbSet<ProductAssignmentEntity> ProductAssignment { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<ProductStatusEntity> ProductStatus { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<TypeBranchEntity> TypeBranch { get; set; }
        public DbSet<UserEntity> User { get; set; }

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=Demo02;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("workstation id=StorageAndQr.mssql.somee.com;packet size=4096;user id=vmartinez84_SQLLogin_3;pwd=bgcs8xmwrb;data source=StorageAndQr.mssql.somee.com;persist security info=False;initial catalog=StorageAndQr ");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductStatusEntity>().HasData(
                new ProductStatusEntity
                {
                    Id = 1,
                    Name = "Activo",
                    IsActive = true,
                    DateRegistration = DateTime.Now
                },
                new ProductStatusEntity
                {
                    Id = 2,
                    Name = "Asignado",
                    IsActive = true,
                    DateRegistration = DateTime.Now
                },
                new ProductStatusEntity
                {
                     Id = 3,
                     Name = "Merma",
                     IsActive = true,
                     DateRegistration = DateTime.Now
                },
                new ProductStatusEntity
                {
                    Id = 4,
                    Name = "Baja por daño",
                    IsActive = true,
                    DateRegistration = DateTime.Now
                },
                new ProductStatusEntity
                {
                    Id = 5,
                    Name = "Recuperado",
                    IsActive = true,
                    DateRegistration = DateTime.Now
                }
            );

            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { Id = 2, Name = "Operador", DateRegistration = DateTime.Now, IsActive = true },
                new RoleEntity { Id = 1, Name = "Administrador", DateRegistration = DateTime.Now, IsActive = true }
            );

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = 1,
                    Name = "Administrador",
                    LastName = string.Empty,
                    Password = "123456",
                    IdRol = 1,
                    UserName = "administrador",
                    DateRegistration = DateTime.Now,
                    IsActive = true
                }
            );
        }
    }
}
