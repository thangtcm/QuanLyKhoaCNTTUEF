using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyKhoaCNTTUEF.Core;
using QuanLyKhoaCNTTUEF.Models;
using QuanLyKhoaCNTTUEF.Models.Files;

namespace QuanLyKhoaCNTTUEF.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<MembersGroups>().HasOne(am => am.Group).WithMany(am => am.MembersGroups).HasForeignKey(am => am.GroupID);
            //builder.Entity<MembersGroups>().HasOne(am => am.ApplicationUser).WithMany(am => am.MembersGroups).HasForeignKey(am => am.UserID);
            base.OnModelCreating(builder);
            SeedRoles(builder);

            SeedUser(builder);

            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }
        public DbSet<Plan>? Plan { get; set; }
        public DbSet<PdfFile>? PdfFile { get; set; }
        public DbSet<Event>? Event { get; set; }
        public DbSet<Group>? Group { get; set; }
        public DbSet<Tasks>? Task { get; set; }
        public DbSet<MembersGroups>? MembersGroups { get; set; }
        //public DbSet<GroupTask>? GroupTasks { get; set; }
        public DbSet<TaskAssignments>? Task_Assignments { get; set; }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
            (
                new IdentityRole() { Name = Constants.Roles.Administrator, NormalizedName = Constants.Roles.Administrator, ConcurrencyStamp = null },
                new IdentityRole() { Name = Constants.Roles.Manager, NormalizedName = Constants.Roles.Manager, ConcurrencyStamp = null },
                new IdentityRole() { Name = Constants.Roles.Teacher, NormalizedName = Constants.Roles.Teacher, ConcurrencyStamp = null },
                new IdentityRole() { Name = Constants.Roles.Staff, NormalizedName = Constants.Roles.Staff , ConcurrencyStamp = null },
                new IdentityRole() { Name = Constants.Roles.Student, NormalizedName = Constants.Roles.Student, ConcurrencyStamp = null }
            );
        }

        private static void SeedUser(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1",
                    UserName = "admin",
                    NormalizedUserName = "USER1@EXAMPLE.COM",
                    Email = "user1@example.com",
                    NormalizedEmail = "USER1@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEJ5WZP5+Za5U6aQ2OYN5WQ2Jy+JHZZv7PzKj8k0rFhCtPmKd6JW+8K5UyNqU5MvLg==",
                    SecurityStamp = "ZD5UZJQK6Q5W6N7O6RBRF6DB2Q2G2AIJ",
                    ConcurrencyStamp = "b19f1b24-5ac9-4c8d-9b7c-5e5d5f5cfb1e",
                    FirstName = "Trần",
                    MiddleName = "Cao Minh",
                    LastName = "Thắng",
                    UrlAvartar = "/img/Admin.png",
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "2",
                    UserName = "user2@example.com",
                    NormalizedUserName = "USER2@EXAMPLE.COM",
                    Email = "user2@example.com",
                    NormalizedEmail = "USER2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEJ5WZP5+Za5U6aQ2OYN5WQ2Jy+JHZZv7PzKj8k0rFhCtPmKd6JW+8K5UyNqU5MvLg==",
                    SecurityStamp = "ZD5UZJQK6Q5W6N7O6RBRF6DB2Q2G2AIJ",
                    ConcurrencyStamp = "b19f1b24-5ac9-4c8d-9b7c-5e5d5f5cfb1e",
                    FirstName = "Lê",
                    MiddleName = "Thảo",
                    LastName = "Duyên",
                    UrlAvartar = "/img/Duyen.png",
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "4",
                    UserName = "user4@example.com",
                    NormalizedUserName = "USER4@EXAMPLE.COM",
                    Email = "user4@example.com",
                    NormalizedEmail = "USER4@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEJ5WZP5+Za5U6aQ2OYN5WQ2Jy+JHZZv7PzKj8k0rFhCtPmKd6JW+8K5UyNqU5MvLg==",
                    SecurityStamp = "ZD5UZJQK6Q5W6N7O6RBRF6DB2Q2G2AIJ",
                    ConcurrencyStamp = "b19f1b24-5ac9-4c8d-9b7c-5e5d5f5cfb1e",
                    FirstName = "Lê",
                    MiddleName = "Ngọc Đình",
                    LastName = "Đình",
                    UrlAvartar = "/img/DinhDinh.png",
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "5",
                    UserName = "user5@example.com",
                    NormalizedUserName = "USER5@EXAMPLE.COM",
                    Email = "user5@example.com",
                    NormalizedEmail = "USER5@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEJ5WZP5+Za5U6aQ2OYN5WQ2Jy+JHZZv7PzKj8k0rFhCtPmKd6JW+8K5UyNqU5MvLg==",
                    SecurityStamp = "ZD5UZJQK6Q5W6N7O6RBRF6DB2Q2G2AIJ",
                    ConcurrencyStamp = "b19f1b24-5ac9-4c8d-9b7c-5e5d5f5cfb1e",
                    FirstName = "Nguyễn",
                    MiddleName = "Tuấn",
                    LastName = "Khoa",
                    UrlAvartar = "/img/Khoa.png",
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                },
                new ApplicationUser
                {
                    Id = "3",
                    UserName = "user3@example.com",
                    NormalizedUserName = "USER3@EXAMPLE.COM",
                    Email = "user3@example.com",
                    NormalizedEmail = "USER2@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEJ5WZP5+Za5U6aQ2OYN5WQ2Jy+JHZZv7PzKj8k0rFhCtPmKd6JW+8K5UyNqU5MvLg==",
                    SecurityStamp = "ZD5UZJQK6Q5W6N7O6RBRF6DB2Q2G2AIJ",
                    ConcurrencyStamp = "b19f1b24-5ac9-4c8d-9b7c-5e5d5f5cfb1e",
                    FirstName = "Hồ",
                    MiddleName = "Lâm Gia",
                    LastName = "Khánh",
                    UrlAvartar = "/img/Khanh.png",
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0
                }
            );
        }
        
    }

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.City).HasMaxLength(255);
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.MiddleName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);
        }

    }
}