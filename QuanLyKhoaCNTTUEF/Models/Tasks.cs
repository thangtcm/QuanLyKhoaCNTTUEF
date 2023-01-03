using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class Tasks
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public int IDSuKien { get; set; }
        [Column(TypeName = "varchar(50)")]
        public int IDTask { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? TenTask { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string? MoTa { get; set; }
        public DateTime NgayBD { get; set; }
        public DateTime NgayKT { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public int TrangThai { get; set; }
    }
}
