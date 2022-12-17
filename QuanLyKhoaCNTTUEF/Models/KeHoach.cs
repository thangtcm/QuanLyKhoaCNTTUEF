using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhoaCNTTUEF.Models
{
    public class KeHoach
    {
        [Key]
        [Column(TypeName = "varchar(20)")]
        public int IDSuKien { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string TenKeHoach { get; set; }
        public DateTime NgayTrinh { get; set; }
        public DateTime NgayDuyet { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string NguoiTrinh { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string NguoiDuyet { get; set; }
    }
}
