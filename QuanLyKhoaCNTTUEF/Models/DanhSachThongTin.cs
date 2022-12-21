using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class DanhSachThongTin
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public int IDNhom { get; set; }
        [Column(TypeName = "varchar(50)")]
        public int UserID { get; set; }
        [Column(TypeName = "varchar(50)")]
        public int IDTask { get; set; }
        [Column(TypeName = "varchar(50)")]
        public int IDSinhVien { get; set; }
        [Column(TypeName = "varchar(50)")]
        public int IDGiaoVien { get; set; }
        [Column(TypeName = "varchar(50)")]
        public int IDKhoa { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? HoVaTen { get; set; }
        public DateTime NgaySinh { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [EmailAddress(ErrorMessage="Vui long nhap dung dinh dang!")]
        public string? Email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? DiaChiHienTai { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string? SoDienThoai { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Nganh { get; set; }

    }
}
