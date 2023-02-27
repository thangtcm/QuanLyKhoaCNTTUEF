using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyKhoaCNTTUEF.Core;
using QuanLyKhoaCNTTUEF.Data.Migrations;
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
            builder.Entity<MembersGroups>().HasKey(am => new
            {
                am.UserID,
                am.GroupID,
            });
            builder.Entity<MembersGroups>().HasOne(am => am.Group).WithMany(am => am.MembersGroups).HasForeignKey(am => am.GroupID);
            builder.Entity<MembersGroups>().HasOne(am => am.ApplicationUser).WithMany(am => am.MembersGroups).HasForeignKey(am => am.UserID);

            base.OnModelCreating(builder);
            SeedRoles(builder);
            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }
        public DbSet<Event>? Event { get; set; }
        public DbSet<Plan>? Plan { get; set; }
        public DbSet<Group>? Group { get; set; }
        public DbSet<Tasks>? Task { get; set; }
        public DbSet<DetailTask>? DetailTask { get; set; }
        public DbSet<DanhSachThongTin>? DanhSachThongTin { get; set; }
        public DbSet<PdfFile>? PdfFile { get; set; }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
            (
                new IdentityRole() { Name = Constants.Roles.Administrator, NormalizedName = Constants.Roles.Administrator },
                new IdentityRole() { Name = Constants.Roles.Manager, NormalizedName = Constants.Roles.Manager },
                new IdentityRole() { Name = Constants.Roles.Teacher, NormalizedName = Constants.Roles.Teacher },
                new IdentityRole() { Name = Constants.Roles.Staff, NormalizedName = Constants.Roles.Staff },
                new IdentityRole() { Name = Constants.Roles.Student, NormalizedName = Constants.Roles.Student }
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