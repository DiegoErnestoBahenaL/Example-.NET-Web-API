using Microsoft.EntityFrameworkCore;
using WebGlobalProduct.Data.Entities;

namespace WebGlobalProduct.Data
{
    public class TaskManagerSystemDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }

        
        public TaskManagerSystemDbContext(DbContextOptions<TaskManagerSystemDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>()
                .Property(x => x.Roles)
                .HasConversion<string>();

            modelBuilder.Entity<TaskEntity>()
                .Property(x => x.State)
                .HasConversion<string>();

            modelBuilder.Entity<UserEntity>()
                .HasData(new UserEntity("defaulAdmin", "user", "admin@example.com", "root" ,RolesEnum.Admin)
                {
                    Id = 1
                });
        }
    }
}
