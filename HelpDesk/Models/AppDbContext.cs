using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using HelpDesk.Models;

namespace HelpDesk.Models
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration;

        //public DbSet<AddressEntity> Address { get; set; }
        public DbSet<BranchEntity> Branch { get; set; }
        public DbSet<BranchTypeEntity> BranchType { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<CompanyEntity> Company { get; set; }
        public DbSet<KitEntity> Kit { get; set; }
        public DbSet<PersonEntity> Person { get; set; }
        public DbSet<ProductAssignmentEntity> ProductAssignment { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<ProductStatusEntity> ProductStatus { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<UserEntity> User { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string stringConnection;

            stringConnection = configuration.GetConnectionString("DefaultConnection");
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=Demo02;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("workstation id=StorageAndQr.mssql.somee.com;packet size=4096;user id=vmartinez84_SQLLogin_3;pwd=bgcs8xmwrb;data source=StorageAndQr.mssql.somee.com;persist security info=False;initial catalog=StorageAndQr ");
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
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

            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity { Id = 1, Name = "Software", DateRegistration = DateTime.Now, IsActive = true },
                new CategoryEntity { Id = 2, Name = "Hardware", DateRegistration = DateTime.Now, IsActive = true },
                new CategoryEntity { Id = 3, Name = "Comunicación", DateRegistration = DateTime.Now, IsActive = true }
            );

            modelBuilder.Entity<BranchTypeEntity>().HasData(
                 new BranchTypeEntity { Id = 1, Name = "Matriz", DateRegistration = DateTime.Now, IsActive = true },
                 new BranchTypeEntity { Id = 2, Name = "Sucursal", DateRegistration = DateTime.Now, IsActive = true }
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
                    RolId = 1,
                    UserName = "administrador",
                    DateRegistration = DateTime.Now,
                    IsActive = true
                }
            );

            modelBuilder.Entity<CompanyEntity>().HasData(
                new CompanyEntity { Id = 1, Name = "Compañia A", IsActive = true, DateRegistration = DateTime.Now, Note = "Prueba", Street = "Domicilio conocido" }
            );

            modelBuilder.Entity<BranchEntity>().HasData(
                new BranchEntity
                {
                    Id = 1,
                    Street = "Domicilio conocido",
                    Note = "Sin observaciones",
                    DateRegistration = DateTime.Now,
                    IsActive = true,
                    CompanyId = 1,
                    Email = "correo@dominio.com",
                    BranchTypeId = 1,
                    Name = "Sucursal",
                    Phone = "55 5658 1111"
                }
            );

            modelBuilder.Entity<PersonEntity>().HasData(
                new PersonEntity
                {
                    Id = 1,
                    DateRegistration = DateTime.Now,
                    Email = "ahal_tocob@hotmail.com",
                    BranchId = 1,
                    IsActive = true,
                    Name = "Víctor",
                    LastName = "Mtz",
                    Phone = "55 3273 7357"
                }
            );

            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity
                {
                    Id = 1,
                    DateStart = DateTime.Now,
                    DateStop = DateTime.Now.AddYears(1),
                    DateRegistration = DateTime.Now,
                    Description = "Posicion 1/3",
                    CategoryId = 1,
                    ProductStatusId = 1,
                    IsActive = true,
                    Name = "Oficce 360",
                    SerieNumber = "148318"
                },
                 new ProductEntity
                 {
                     Id = 2,
                     DateStart = DateTime.Now,
                     DateStop = DateTime.Now.AddYears(1),
                     DateRegistration = DateTime.Now,
                     Description = "Posicion 2/3",
                     CategoryId = 1,
                     ProductStatusId = 1,
                     IsActive = true,
                     Name = "Oficce 360",
                     SerieNumber = "148318"
                 },
                  new ProductEntity
                  {
                      Id = 3,
                      DateStart = DateTime.Now,
                      DateStop = DateTime.Now.AddYears(1),
                      DateRegistration = DateTime.Now,
                      Description = "Posicion 3/3",
                      CategoryId = 1,
                      ProductStatusId = 1,
                      IsActive = true,
                      Name = "Oficce 360",
                      SerieNumber = "148318"
                  },
                   new ProductEntity
                   {
                       Id = 4,
                       DateRegistration = DateTime.Now,
                       Description = "Camara axis 1020",
                       CategoryId = 3,
                       ProductStatusId = 1,
                       IsActive = true,
                       Name = "Camara IP",
                       SerieNumber = "148318"
                   },
                    new ProductEntity
                    {
                        Id = 5,
                        DateRegistration = DateTime.Now,
                        Description = "8GB Ram, ICore5, SSD 250GB",
                        CategoryId = 3,
                        ProductStatusId = 1,
                        IsActive = true,
                        Name = "PC 2000",
                        SerieNumber = "148318"
                    },
                    new ProductEntity
                    {
                        Id = 6,
                        DateRegistration = DateTime.Now,
                        Description = "Logitech",
                        CategoryId = 3,
                        ProductStatusId = 1,
                        IsActive = true,
                        Name = "Maus y teclado",
                        SerieNumber = "148318"
                    },
                    new ProductEntity
                    {
                        Id = 7,
                        DateRegistration = DateTime.Now,
                        Description = "LG",
                        CategoryId = 3,
                        ProductStatusId = 1,
                        IsActive = true,
                        Name = "Monitor 21",
                        SerieNumber = "148318"
                    }
            );
        }
    }
}
