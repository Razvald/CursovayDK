using Microsoft.EntityFrameworkCore;
using rlf.Data.Models;

namespace rlf.Data
{
    public class AppDBContent(DbContextOptions<AppDBContent> options) : DbContext(options)
    {
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Устанавливаем первичные ключи
            modelBuilder.Entity<Role>().HasKey(r => r.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<UserProfile>().HasKey(up => up.Id);
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);

            modelBuilder.AddInitialData();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static ModelBuilder AddInitialData(this ModelBuilder modelBuilder)
        {
            List<Role> roles =
            [
                new() { Id = 1, Name = "Admin" },
                new() { Id = 2, Name = "User" }
            ];

            List<Category> categories =
            [
                new() { Id = 1, CategoryName = "Доходы", Desc = "Получил" },
                new() { Id = 2, CategoryName = "Расходы", Desc = "Потратил" }
            ];

            List<User> users =
            [
                new() { Id = 1, Email = "admin@admin", Login = "admin", Password = "1".ToHash(), RoleId = 1},
                new() { Id = 2, Email = "user@user", Login = "user", Password = "1".ToHash(), RoleId = 2}
            ];

            List<Transaction> transactions =
            [
                new() { Id = 1, Name = "Траты в ###", Desc = "что-то", Sum = 3000, CategoryID = 1, UserId = 1 },
                new() { Id = 2, Name = "Траты в ###", Desc = "что-то", Sum = 11100, CategoryID = 2, UserId = 2 },
                new() { Id = 3, Name = "Траты в ###", Desc = "что-то", Sum = 15300, CategoryID = 1, UserId = 1 },
                new() { Id = 4, Name = "Траты в ###", Desc = "что-то", Sum = 12300, CategoryID = 2, UserId = 2 },
                new() { Id = 5, Name = "Траты в ###", Desc = "что-то", Sum = 1500, CategoryID = 1, UserId = 2 },
                new() { Id = 6, Name = "Траты в ###", Desc = "что-то", Sum = 10200, CategoryID = 2, UserId = 1 }
            ];

            List<UserProfile> userProfiles =
            [
                new() { Id = 1, Name = "Admin Name", NickName = "AdminNick", Phone = "123456789", PlaceOfResidence = "Admin's Residence", TimeZone = "MSK+4", UserId = 1},
                new() { Id = 2, Name = "User Name", NickName = "UserNick", Phone = "987654321", PlaceOfResidence = "User's Residence", TimeZone = "MSK+5",UserId = 2}
            ];

            modelBuilder.Entity<Role>().HasData(roles);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<UserProfile>().HasData(userProfiles);
            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Transaction>().HasData(transactions);

            return modelBuilder;
        }
    }
}
