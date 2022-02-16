using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Activities.Dtos;

namespace Activities.Models
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<ActivityEntity> Activity { get; set; }
        public DbSet<ActivityStatusEntity> ActivityStatus { get; set; }
        public DbSet<CommentEntity> Comment { get; set; }
        public DbSet<FileEntity> File { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<RowEntity> Row { get; set; }
        public DbSet<RowStatusEntity> RowStatus { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<UsersInRowEntity> UsersInRow { get; set; }


        public AppDbContext(Microsoft.Extensions.Configuration.IConfiguration configuration)
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
                //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database=Demo03;Trusted_Connection=True;");
                //optionsBuilder.UseSqlServer("workstation id=ProyectoDeIntegracion.mssql.somee.com;packet size=4096;user id=erickudl_SQLLogin_1;pwd=575clhbt2z;data source=ProyectoDeIntegracion.mssql.somee.com;persist security info=False;initial catalog=ProyectoDeIntegracion");
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityStatusEntity>().HasData(
                new ActivityStatusEntity { Id = 1, Name = "Por hacer", DateRegistration = DateTime.Now, IsActive = true },
                new ActivityStatusEntity { Id = 2, Name = "Haciendo", DateRegistration = DateTime.Now, IsActive = true },
                new ActivityStatusEntity { Id = 3, Name = "Hecho", DateRegistration = DateTime.Now, IsActive = true }
            );

            modelBuilder.Entity<RowStatusEntity>().HasData(
                new RowStatusEntity { Id = 1, Name = "Listo", DateRegistration = DateTime.Now, IsActive = true },
                new RowStatusEntity { Id = 2, Name = "En proceso", DateRegistration = DateTime.Now, IsActive = true },
                new RowStatusEntity { Id = 3, Name = "Estancado", DateRegistration = DateTime.Now, IsActive = true }
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
                    RoleId = 1,
                    UserName = "administrador",
                    DateRegistration = DateTime.Now,
                    IsActive = true,
                    Email = string.Empty,
                    Phone = string.Empty
                }
            );
        }        

    }//end class
}
