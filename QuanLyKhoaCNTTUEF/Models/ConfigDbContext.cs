using Microsoft.EntityFrameworkCore;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class ConfigDbContext:DbContext
    {
        public ConfigDbContext(DbContextOptions<ConfigDbContext> options):base(options)
        {
        }
        public DbSet<SuKien>? SuKien { get; set; }
        public DbSet<KeHoach>? KeHoach { get; set; }
        public DbSet<Nhom>? Nhom { get; set; }
        public DbSet<Task>? Task { get; set; }
        public DbSet<ChiTietTask>? ChiTietTask { get; set; }
        public DbSet<DanhSachThongTin>? DanhSachThongTin { get; set; }
    }
}
