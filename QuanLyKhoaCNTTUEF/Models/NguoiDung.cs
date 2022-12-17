using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class NguoiDung
    {
        [Key]
        [Column(TypeName = "varchar(50)")]
        public int MSSV { get; set; }
        [Column(TypeName = "varchar(50)")]
        public int UserID { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [EmailAddress(ErrorMessage = "Vui long nhap dung dinh dang!")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string HoVaTen { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ChucVu { get; set; }
     

    }
}
