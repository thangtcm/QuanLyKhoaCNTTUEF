using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class Nhom
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string? IDNhom { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? IDSuKien { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? TenNhom { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string? MoTa { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
    }
}
