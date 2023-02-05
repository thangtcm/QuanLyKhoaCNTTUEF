using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyKhoaCNTTUEF.Models;

namespace QuanLyKhoaCNTTUEF.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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

            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }
        public DbSet<Event>? Event { get; set; }
        public DbSet<Plan>? Plan { get; set; }
        public DbSet<Group>? Group { get; set; }
        public DbSet<Tasks>? Task { get; set; }
        public DbSet<DetailTask>? DetailTask { get; set; }
        public DbSet<DanhSachThongTin>? DanhSachThongTin { get; set; }
    }

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.City).HasMaxLength(255);
        }

    }
}