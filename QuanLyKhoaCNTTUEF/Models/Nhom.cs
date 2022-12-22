using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class Nhom
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "ID Nhóm")]
        public string? IDNhom { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Display(Name = "ID Sự Kiện")]
        public string? IDSuKien { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Tên Nhóm")]
        public string? TenNhom { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Mô Tả")]
        public string? MoTa { get; set; }

        [Display(Name = "Ngày Tạo")]
        public DateTime NgayTao { get; set; }

        [Display(Name = "Ngày Cập Nhật")]
        public DateTime NgayCapNhat { get; set; }
    }
}
